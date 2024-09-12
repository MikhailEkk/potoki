using System.Collections.ObjectModel;
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
using lab2_patterns.Factory;
using lab2_patterns.Factory_method;
using System.Numerics;
using SeatingFurnitureMultithreading;
using System.Drawing;



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
    /// Фабрики
    /// </summary>
    private ObservableCollection<ISeatingFurnitureFactory> _factories = new ObservableCollection<ISeatingFurnitureFactory>();

    /// <summary>
    /// Фабричный метод для кресла и дивана
    /// </summary>
    private ArmchairAndSofaFactoryMethod _armchairAndSofaFactoryMethod = new ArmchairAndSofaFactoryMethod();

    /// <summary>
    /// Фабричный метод для стула и банкетки
    /// </summary>
    private ChairAndBanquetteFactoryMethod _chairAndBanquetteFactoryMethod = new ChairAndBanquetteFactoryMethod();

    /// <summary>
    /// фабричный метод для прототипов
    /// </summary>
    private PrototypeFactoryMethod _prototypeFactoryMethod;

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
      DataGridFurniture.ItemsSource = Furniture;
      ComboBoxFactory.ItemsSource = _factories;
      InitializeFactories();
    }

    /// <summary>
    /// Инициализация фабрик
    /// </summary>
    private void InitializeFactories()
    {
      _factories.Add(_armchairAndSofaFactoryMethod.CreateFactory());
      _factories.Add(_chairAndBanquetteFactoryMethod.CreateFactory());
      InitializationPrototype();
      _factories.Add(_prototypeFactoryMethod.CreateFactory());
    }

    /// <summary>
    /// Инициализация прототипа
    /// </summary>
    private void InitializationPrototype()
    {
      Execute(new Sofa(), FormAction.CreatePrototype);
      Execute(new Chair(), FormAction.CreatePrototype);
      _prototypeFactoryMethod = new PrototypeFactoryMethod((Bench)_furniture[0], (Tabouret)_furniture[1]);
      _furniture.Clear();
    }

    /// <summary>
    /// Добавление табурета (его разновидности)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonAddArmchairAndSofa_Click(object sender, RoutedEventArgs e)
    {
      Tabouret tabouret = ((ISeatingFurnitureFactory)ComboBoxFactory.SelectedItem).CreateTaburet();
      Execute(tabouret, FormAction.Create);
    }

    /// <summary>
    /// Добавление скамьи (ее разновидности)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonAddChairAndBanquette_Click(object sender, RoutedEventArgs e)
    {
      Bench bench = ((ISeatingFurnitureFactory)ComboBoxFactory.SelectedItem).CreateBench();
      Execute(bench, FormAction.Create);
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
          form = new FormSofa(sofa, ActionsManager.IsAllowEdit(parAction), parAction, ActionsManager.IsAllowCancel(parAction));
          break;
        case Banquette banquette:
          form = new FormBanquette(banquette, ActionsManager.IsAllowEdit(parAction), ActionsManager.IsAllowCancel(parAction), parAction);
          break;
        case Armchair armchair:
          form = new FormArmchair(armchair, ActionsManager.IsAllowEdit(parAction), ActionsManager.IsAllowCancel(parAction), parAction);
          break;
        case Chair chair:
          form = new FormChair(chair, ActionsManager.IsAllowEdit(parAction), ActionsManager.IsAllowCancel(parAction), parAction);
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
          case FormAction.CreatePrototype:
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
    /// Создание случайной мебели
    /// </summary>
    /// <returns></returns>
    private SeatingFurniture GetRandomFurniture()
    {
      string[] material = { "Массив", "Фанера", "ДСП", "МДФ" };
      Random random = new Random();
      return random.Next(1, 5) switch
      {
        1 => new Sofa(material[random.Next(3)], random.Next(3, 10), random.Next(1, 50000), random.Next(1, 30), true, false, random.Next(1, 500)),
        2 => new Chair(material[random.Next(3)], 1, random.Next(1, 5000), random.Next(1, 30), random.Next(100, 300), random.Next(1, 100), true),
        3 => new Armchair(material[random.Next(3)], 1, random.Next(1, 10000), random.Next(1, 30), random.Next(100, 300), random.Next(100), random.Next(1, 8)),
        4 => new Banquette(material[random.Next(3)], random.Next(2, 4), random.Next(1, 5000), random.Next(1, 30), false, true),
      };
    }

    /// <summary>
    /// Добавление созданной мебели
    /// </summary>
    /// <param name="parFurniture">Список мебели</param>
    private void SaveFurniture(List<object> parFurniture)
    {
      parFurniture.ForEach(furniture => _furniture.Add((SeatingFurniture)furniture));
    }

    /// <summary>
    /// Добавление случайной мебели
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonSetRandomValues_Click(object sender, RoutedEventArgs e)
    {
      int number = int.Parse(TextBoxFurnituresCount.Text);
      WindowProgressBar windowProgressBar = new WindowProgressBar(number, CheckBoxCloseOnExit.IsChecked.Value, GetRandomFurniture, SaveFurniture);
      windowProgressBar.Show();
    }

    /// <summary>
    /// Очистка фильтров
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonRemoveFilter_Click(object sender, RoutedEventArgs e)
    {
      DataGridFurniture.ItemsSource = _furniture;
      ExpanderFilter.Header = "Фильтр";
      TextBoxName.Text = "";
      RadioButtonValue.IsChecked = true;
      TextBoxValue.Text = "";
      TextBoxRangeMin.Text = "";
      TextBoxRangeMax.Text = "";
    }

    /// <summary>
    /// Применение фильтров
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonFllter_Click(object sender, RoutedEventArgs e)
    {
      bool isName = TextBoxName.Text != "";
      bool isValue = RadioButtonValue.IsChecked == true && TextBoxValue.Text != "";
      bool isRange = !(TextBoxRangeMax.Text == "" && TextBoxRangeMin.Text == "");
      int min = 0;
      int max = 0;
      int value = 0;
      if (isValue)
      {
        value = int.Parse(TextBoxValue.Text);
      }
      else if (isRange)
      {
        min = TextBoxRangeMin.Text != "" ? int.Parse(TextBoxRangeMin.Text) : int.MinValue;
        max = TextBoxRangeMax.Text != "" ? int.Parse(TextBoxRangeMax.Text) : int.MaxValue;
      }
      CollectionViewSource filter = new CollectionViewSource() { Source = _furniture };
      SeatingFurniture furniture = (SeatingFurniture)DataGridFurniture.SelectedItem;
      filter.Filter += (sender, e) =>
      {
        if (e.Item is SeatingFurniture furniture)
        {
          e.Accepted = true;
          if (isName)
          {
            e.Accepted &= (furniture.Material.Contains(TextBoxName.Text));
          }
          if (isValue)
          {
            e.Accepted &= (furniture.CostMaterials == value);
          }
          else if (isRange)
          {
            e.Accepted &= (furniture.CostMaterials >= min
                  && furniture.CostMaterials <= max);
          }
        }
      };
      DataGridFurniture.ItemsSource = filter.View;
      DataGridFurniture.SelectedItem = furniture;
      DataGridFurniture.Focus();
      ExpanderFilter.Header = "Фильтры: " + (isName ? ("Наименование <" + TextBoxName.Text + "> ") : "")
          + (isValue ? "Высота = " + value : "")
          + (isRange ? "Высота с " + (min == int.MinValue ? "min" : min) + " по "
          + (max == int.MaxValue ? "max" : max) : ".") + " Количество записей: "
          + (DataGridFurniture.Items.Count - 1);
    }

    /// <summary>
    /// Проверка данных на валидность 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PreviewTextInputInt(object sender, TextCompositionEventArgs e)
    {
      e.Handled = !int.TryParse(e.Text, out _);
    }

    /// <summary>
    /// Проверка выбора диапозона
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void RadioButtonRange_Checked(object sender, RoutedEventArgs e)
    {
      if (RadioButtonRange.IsChecked == true)
      {
        TextBoxRangeMax.Visibility = Visibility.Visible;
        TextBoxRangeMin.Visibility = Visibility.Visible;
        TextBoxValue.Visibility = Visibility.Hidden;
      }
      else
      {
        TextBoxRangeMax.Visibility = Visibility.Hidden;
        TextBoxRangeMin.Visibility = Visibility.Hidden;
        TextBoxValue.Visibility = Visibility.Visible;
      }
    }
  }
}