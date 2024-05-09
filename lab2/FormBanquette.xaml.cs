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

    public FormBanquette(Banquette parBanquette, bool parIsAllowEdit, FormAction parAction)
    {
      InitializeComponent();
      Banquette = new Banquette(parBanquette);
      Grid.IsEnabled = parIsAllowEdit;
      ButtonAction.Content = ActionsManager.GetName(parAction);

      Binding IDBinding = new Binding("ID");
      IDBinding.Source = Banquette;
      TextBoxID.SetBinding(TextBox.TextProperty, IDBinding);

      Binding materialBinding = new Binding("Material");
      materialBinding.Source = Banquette;
      TextBoxMaterial.SetBinding(TextBox.TextProperty, materialBinding);

      Binding costMaterialBinding = new Binding("CostMaterials");
      costMaterialBinding.Source = Banquette;
      TextBoxCostMaterial.SetBinding(TextBox.TextProperty, costMaterialBinding);

      ComboBoxStorageCompartment.ItemsSource = new List<bool> { true, false };
      Binding storageCompartmentBinding = new Binding("StorageCompartment");
      storageCompartmentBinding.Source = Banquette;
      ComboBoxStorageCompartment.SetBinding(ComboBox.SelectedItemProperty, storageCompartmentBinding);

      Binding seatingCapacityBinding = new Binding("SeatingCapacity");
      seatingCapacityBinding.Source = Banquette;
      TextBoxSeatingCapacity.SetBinding(TextBox.TextProperty, seatingCapacityBinding);

      ComboBoxIsBackrest.ItemsSource = new List<bool> { true, false };
      Binding isBackrestBinding = new Binding("IsBackrest");
      isBackrestBinding.Source = Banquette;
      ComboBoxIsBackrest.SetBinding(ComboBox.SelectedItemProperty, isBackrestBinding);
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

  }
}
