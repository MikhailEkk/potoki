using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfLibrary1;

namespace lab2
{
  /// <summary>
  /// Логика взаимодействия для FormBanquette.xaml
  /// </summary>
  public partial class FormBanquette : Window, IForm
  {
    /// <summary>
    /// Выбранные банкетки
    /// </summary>
    public Banquette Banquette { get; set; }

    /// <summary>
    /// Конструктор формы для работы с банкеткой
    /// </summary>
    /// <param name="parBanquette"></param>
    /// <param name="parIsAllowEdit"></param>
    /// <param name="parIsAllowCancel"></param>
    /// <param name="parAction"></param>
    public FormBanquette(Banquette parBanquette, bool parIsAllowEdit, bool parIsAllowCancel, FormAction parAction)
    {
      InitializeComponent();
      Banquette = new Banquette(parBanquette);
      DataContext = Banquette;
      Grid.IsEnabled = parIsAllowEdit;
      ButtonCancel.IsEnabled = parIsAllowCancel;
      ButtonAction.Content = ActionsManager.GetName(parAction);
    }

    /// <summary>
    /// Добавить
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonAction_Click(object sender, RoutedEventArgs e)
    {
      DialogResult = true;
      Close();
    }

    /// <summary>
    /// Отменить действие
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonCancel_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }

    /// <summary>
    /// Получить банкетку
    /// </summary>
    /// <returns></returns>
    public SeatingFurniture GetFurniture()
    {
      return Banquette;
    }

    /// <summary>
    /// Открыть форму
    /// </summary>
    /// <returns></returns>
    public bool Open()
    {
      return (bool)ShowDialog();
    }

    /// <summary>
    /// Обработчик пустого поля
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TextID_LostFocus(object sender, RoutedEventArgs e)
    {
      if (string.IsNullOrWhiteSpace(this.TextBoxID.Text))
      {
        MessageBox.Show("Поле не должно быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        this.TextBoxID.Text = "5";
        this.TextBoxID.Focus();
      }
    }

    /// <summary>
    /// Обработчик ввода целых чисел
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TextIntegerType_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {

      if (!(Char.IsDigit(e.Text, 0)))
      {
        e.Handled = true;
      }
    }

  }
}
