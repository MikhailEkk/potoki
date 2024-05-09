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
  /// Логика взаимодействия для FormArmchair.xaml
  /// </summary>
  public partial class FormArmchair : Window, IForm
  {
    /// <summary>
    /// Выбранный диван
    /// </summary>
    public Armchair Armchair { get; set; }

    /// <summary>
    /// Конструктор формы
    /// </summary>
    /// <param name="parArmchair"></param>
    /// <param name="parIsAllowEdit"></param>
    /// <param name="parAction"></param>
    public FormArmchair(Armchair parArmchair, bool parIsAllowEdit, FormAction parAction)
    {
      InitializeComponent();
      Armchair = new Armchair(parArmchair);
      Grid.IsEnabled = parIsAllowEdit;
      ButtonAction.Content = ActionsManager.GetName(parAction);

      Binding IDBinding = new Binding("ID");
      IDBinding.Source = Armchair;
      TextBoxID.SetBinding(TextBox.TextProperty, IDBinding);

      Binding materialBinding = new Binding("Material");
      materialBinding.Source = Armchair;
      TextBoxMaterial.SetBinding(TextBox.TextProperty, materialBinding);

      Binding costMaterialBinding = new Binding("CostMaterials");
      costMaterialBinding.Source = Armchair;
      TextBoxCostMaterials.SetBinding(TextBox.TextProperty, costMaterialBinding);

      Binding heightBinding = new Binding("Height");
      heightBinding.Source = Armchair;
      TextBoxHeight.SetBinding(TextBox.TextProperty, heightBinding);

      Binding wheelCountBinding = new Binding("WheelCount");
      wheelCountBinding.Source = Armchair;
      TextBoxWheelCount.SetBinding(TextBox.TextProperty, wheelCountBinding);

      Binding seatingCapacityBinding = new Binding("SeatingCapacity");
      seatingCapacityBinding.Source = Armchair;
      TextBoxSeatingCapacity.SetBinding(TextBox.TextProperty, seatingCapacityBinding);

      Binding legSquareBinding = new Binding("LegSquare");
      legSquareBinding.Source = Armchair;
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
      return Armchair;
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
