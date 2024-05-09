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
  /// Логика взаимодействия для FormChair.xaml
  /// </summary>
  public partial class FormChair : Window, IForm
  {
    /// <summary>
    /// Выбранный стул
    /// </summary>
    public Chair Chair { get; set; }

    /// <summary>
    /// Конструктор формы
    /// </summary>
    /// <param name="parChair"></param>
    /// <param name="parIsAllowEdit"></param>
    /// <param name="parAction"></param>
    public FormChair(Chair parChair, bool parIsAllowEdit, FormAction parAction)
    {
      InitializeComponent();
      Chair = new Chair(parChair);
      Grid.IsEnabled = parIsAllowEdit;
      ButtonAction.Content = ActionsManager.GetName(parAction);

      Binding IDBinding = new Binding("ID");
      IDBinding.Source = Chair;
      TextBoxID.SetBinding(TextBox.TextProperty, IDBinding);

      Binding materialBinding = new Binding("Material");
      materialBinding.Source = Chair;
      TextBoxMaterial.SetBinding(TextBox.TextProperty, materialBinding);

      Binding costMaterialBinding = new Binding("CostMaterials");
      costMaterialBinding.Source = Chair;
      TextBoxCostMaterials.SetBinding(TextBox.TextProperty, costMaterialBinding);

      Binding heightBinding = new Binding("Height");
      heightBinding.Source = Chair;
      TextBoxHeight.SetBinding(TextBox.TextProperty, heightBinding);

      ComboBoxIsSoft.ItemsSource = new List<bool> { true, false };
      Binding isSoftBinding = new Binding("IsSoft");
      isSoftBinding.Source = Chair;
      ComboBoxIsSoft.SetBinding(ComboBox.SelectedItemProperty, isSoftBinding);

      Binding seatingCapacityBinding = new Binding("SeatingCapacity");
      seatingCapacityBinding.Source = Chair;
      TextBoxSeatingCapacity.SetBinding(TextBox.TextProperty, seatingCapacityBinding);

      Binding legSquareBinding = new Binding("LegSquare");
      legSquareBinding.Source = Chair;
      TextBoxLegSquare.SetBinding(TextBox.TextProperty, legSquareBinding);
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
    /// Получить диван
    /// </summary>
    /// <returns></returns>
    public SeatingFurniture GetFurniture()
    {
      return Chair;
    }

    /// <summary>
    /// Открыть форму
    /// </summary>
    /// <returns></returns>
    public bool Open()
    {
      return (bool)ShowDialog();
    }
  }
}
