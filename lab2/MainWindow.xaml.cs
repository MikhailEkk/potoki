﻿using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfLibrary1;

namespace lab2
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    /// <summary>
    /// Список мебели
    /// </summary>
    private ObservableCollection<SeatingFurniture> _furniture = new ObservableCollection<SeatingFurniture>();

    /// <summary>
    /// Свойство поля _furniture
    /// </summary>
    public ObservableCollection<SeatingFurniture> Furniture
    {
      get { return _furniture; }
      set { _furniture = value; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public MainWindow()
    {
      InitializeComponent();
      DataGridFurniture.ItemsSource = _furniture;
    }

    /// <summary>
    /// Создать необходимую форму
    /// </summary>
    /// <param name="parFurniture"></param>
    /// <param name="parAction"></param>
    /// <returns></returns>
    private IForm GetForm(SeatingFurniture parFurniture, FormAction parAction)
    {
      IForm form = null;
      switch (parFurniture)
      {
        case Sofa sofa:
          form = new FormSofa(sofa, ActionsManager.IsAllowEdit(parAction), parAction);
          break;
        case Banquette banquette:
          form = new FormBanquette(banquette, ActionsManager.IsAllowEdit(parAction), parAction);
          break;
        case Armchair armchair:
          form = new FormArmchair(armchair, ActionsManager.IsAllowEdit(parAction), parAction);
          break;
        case Chair chair:
          form = new FormChair(chair, ActionsManager.IsAllowEdit(parAction), parAction);
          break;
      }
      return form;
    }

    /// <summary>
    /// Выполнить действие
    /// </summary>
    /// <param name="parFurniture"></param>
    /// <param name="parAction"></param>
    private void Execute(SeatingFurniture parFurniture, FormAction parAction)
    {
      if (parFurniture == null) return;
      IForm form = GetForm(parFurniture, parAction);
      if (form.Open())
      {
        switch (parAction)
        {
          case FormAction.Create:
            Furniture.Add(form.GetFurniture());
            break;
          case FormAction.Remove:
            Furniture.Remove(parFurniture);
            break;
          case FormAction.Edit:
            parFurniture.Copy(form.GetFurniture());
            break;
        }
      }

    }

    /// <summary>
    /// Добавление стула
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonAddChair_Click(object sender, RoutedEventArgs e)
    {
      Execute(new Chair(), FormAction.Create);
    }

    /// <summary>
    /// Добавление кресла
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonAddArmchair_Click(object sender, RoutedEventArgs e)
    {
      Execute(new Armchair(), FormAction.Create);
    }

    /// <summary>
    /// Добавление банкетки
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonAddBanquette_Click(object sender, RoutedEventArgs e)
    {
      Execute(new Banquette(), FormAction.Create);
    }

    /// <summary>
    /// Добавление дивана
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonAddSofa_Click(object sender, RoutedEventArgs e)
    {
      Execute(new Sofa(), FormAction.Create);
    }

    /// <summary>
    /// Изменение предмета
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonEdit_Click(object sender, RoutedEventArgs e)
    {
      Execute((SeatingFurniture)DataGridFurniture.SelectedItem, FormAction.Edit);
      DataGridFurniture.Items.Refresh();
    }

    /// <summary>
    /// Удаление предмета
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonDelete_Click(object sender, RoutedEventArgs e)
    {
      Execute((SeatingFurniture)DataGridFurniture.SelectedItem, FormAction.Remove);
    }

    /// <summary>
    /// Добавление случайной мебели
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonSetRandomValues_Click(object sender, RoutedEventArgs e)
    {
      string[] material = { "Массив", "Фанера", "ДСП", "МДФ" };
      Random random = new Random();
      _furniture.Add(new Sofa(material[random.Next(3)], random.Next(3, 10), random.Next(1, 50000), random.Next(1, 30), true, false, random.Next(1, 500)));
      _furniture.Add(new Chair(material[random.Next(3)], 1, random.Next(1, 5000), random.Next(1, 30), random.Next(100, 300), random.Next(1, 100), true));
      _furniture.Add(new Armchair(material[random.Next(3)], 1, random.Next(1, 10000), random.Next(1, 30), random.Next(100, 300), random.Next(100), random.Next(1, 8)));
      _furniture.Add(new Banquette(material[random.Next(3)], random.Next(2, 4), random.Next(1, 5000), random.Next(1, 30), false, true));
    }
  }
}