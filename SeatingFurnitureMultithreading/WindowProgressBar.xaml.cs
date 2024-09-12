using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SeatingFurnitureMultithreading
{
  /// <summary>
  /// Логика взаимодействия для WindowProgressBar.xaml
  /// </summary>
  public partial class WindowProgressBar : Window
  {
    /// <summary>
    /// Делегат функции создания объекта
    /// </summary>
    /// <returns></returns>
    public delegate object dAddOject();

    /// <summary>
    /// Делегат принудительного завершения генерации
    /// </summary>
    public delegate void dCancel();

    /// <summary>
    /// Делегат окончания генерации
    /// </summary>
    public delegate void dFinish(List<object> parList);

    /// <summary>
    /// Событие принудительного завершения генерации
    /// </summary>
    public event dCancel OnCancel;

    /// <summary>
    /// Событие окончания генерации
    /// </summary>
    public event dFinish OnFinish;

    /// <summary>
    /// Флаг окончания генерации
    /// </summary>
    private bool _isFinished = false;

    /// <summary>
    /// Флаг принудительного завершения генерации
    /// </summary>
    private bool _isCanceled = false;

    /// <summary>
    /// Флаг автозакрытия
    /// </summary>
    private bool _isAutoClosed = false;

    /// <summary>
    /// Созданные объекты
    /// </summary>
    private List<object> _createdObjects = new List<object>();

    /// <summary>
    /// Функция создания объекта
    /// </summary>
    private dAddOject addNewObject;

    /// <summary>
    /// Созданные объекты
    /// </summary>
    public List<object> CreatedObjects
    {
      get => _createdObjects;
      set => _createdObjects = value;
    }

    /// <summary>
    /// Флаг окончания генерации
    /// </summary>
    public bool IsFinished
    {
      get { return _isFinished; }
    }

    /// <summary>
    /// Флаг принудительного завершения генерации
    /// </summary>
    public bool IsCanceled
    {
      get { return _isCanceled; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parFurnituresCount">Количество мебели для создания</param>
    /// <param name="parIsAutoClosed">Флаг автозакрытия</param>
    /// <param name="dAddOject">Делегат функции создания объекта</param>
    /// <param name="parOnFinish">Делегат окончания генерации</param>
    public WindowProgressBar(int parFurnituresCount, bool parIsAutoClosed, dAddOject parAddObject, dFinish parOnFinish)
    {
      InitializeComponent();
      addNewObject = parAddObject;
      ProgressBar.Minimum = 0;
      ProgressBar.Maximum = parFurnituresCount;
      _isAutoClosed = parIsAutoClosed;
      Closing += Window_Close;
      OnCancel += SkipDevicesSaving;
      OnFinish += parOnFinish;
      GetPerformingThread(parFurnituresCount).Start();
      GetUpdateFormThread().Start();
    }

    /// <summary>
    /// Закрытие окна
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Window_Close(object sender, CancelEventArgs e)
    {
      if (!_isFinished)
      {
        _isCanceled = true;
        ButtonCancel.IsEnabled = false;
        OnCancel.Invoke();
      }
    }

    /// <summary>
    /// Очистка списка созданных объектов
    /// </summary>
    private void SkipDevicesSaving()
    {
      _createdObjects.Clear();
    }

    /// <summary>
    /// Создание потока выполнения
    /// </summary>
    /// <param name="parFurnituresCount">Количество мебели для создания</param>
    /// <returns></returns>
    private Thread GetPerformingThread(int parFurnituresCount)
    {
      return new Thread(() =>
      {
        for (int i = 0; i < parFurnituresCount && !this.IsCanceled && !this.IsFinished; i++)
        {
          _createdObjects.Add(addNewObject());
        }
      })
      {
        IsBackground = true
      };
    }

    /// <summary>
    /// Создание потока обновления формы
    /// </summary>
    /// <returns></returns>
    private Thread GetUpdateFormThread()
    {
      return new Thread(() =>
      {
        while (!this.IsFinished && !this.IsCanceled)
        {
          this.UpdateProgressBar(CreatedObjects.Count);
        }
      })
      {
        IsBackground = true
      };
    }

    /// <summary>
    /// Изменение прогресса создания объектов на форме
    /// </summary>
    /// <param name="parNewValue">Новое значение</param>
    public void UpdateProgressBar(int parNewValue)
    {
      try
      {
        Dispatcher.Invoke(() =>
        {
          ProgressBar.Value = parNewValue;
          if (ProgressBar.Value >= ProgressBar.Maximum - 1 && !_isFinished)
          {
            ButtonCancel.Content = "Закрыть";
            LabelProcess.Content = "Генерация случайных записей успешно завершена!";
            _isFinished = true;
            if (_isAutoClosed)
            {
              OnFinish.Invoke(CreatedObjects);
              Close();
            }
          }
        });
      }
      catch (Exception)
      {
        OnCancel.Invoke();
      }
    }

    /// <summary>
    /// Отмема создания случайных объектов или закрытие окна
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param> 
    private void ButtonCancel_Click(object sender, RoutedEventArgs e)
    {
      if (!_isFinished)
      {
        _isCanceled = true;
        ButtonCancel.IsEnabled = false;
        OnCancel.Invoke();
      }
      else
      {
        OnFinish.Invoke(CreatedObjects);
        Close();
      }
    }
  }
}
