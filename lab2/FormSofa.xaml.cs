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
  /// Логика взаимодействия для AddSofa.xaml
  /// </summary>
  public partial class FormSofa : Window, IForm
  { 
    /// <summary>
    /// Выбранный диван
    /// </summary>
    public Sofa Sofa { get; set; }

    /// <summary>
    /// Конструктор формы
    /// </summary>
    /// <param name="parSofa"></param>
    /// <param name="parIsAllowEdit"></param>
    /// <param name="parAction"></param>
    public FormSofa(Sofa parSofa, bool parIsAllowEdit, FormAction parAction)
    {
      InitializeComponent();
      Sofa = new Sofa(parSofa);
      Grid.IsEnabled = parIsAllowEdit;
      ButtonAction.Content = ActionsManager.GetName(parAction);

      Binding IDBinding = new Binding("ID");
      IDBinding.Source = Sofa;
      TextBoxID.SetBinding(TextBox.TextProperty, IDBinding);

      Binding materialBinding = new Binding("Material");
      materialBinding.Source = Sofa;
      TextBoxMaterial.SetBinding(TextBox.TextProperty, materialBinding);

      Binding costMaterialBinding = new Binding("CostMaterials");
      costMaterialBinding.Source = Sofa;
      TextBoxCostMaterials.SetBinding(TextBox.TextProperty, costMaterialBinding);

      Binding lengthBinding = new Binding("Length");
      lengthBinding.Source = Sofa;
      TextBoxLength.SetBinding(TextBox.TextProperty, lengthBinding);

      ComboBoxIsElbow.ItemsSource = new List<bool> { true, false };
      Binding isElbowBinding = new Binding("IsElbow");
      isElbowBinding.Source = Sofa;
      ComboBoxIsElbow.SetBinding(ComboBox.SelectedItemProperty, isElbowBinding);

      Binding seatingCapacityBinding = new Binding("SeatingCapacity");
      seatingCapacityBinding.Source = Sofa;
      TextBoxSeatingCapacity.SetBinding(TextBox.TextProperty, seatingCapacityBinding);

      ComboBoxIsBackrest.ItemsSource = new List<bool> { true, false };
      Binding isBackrestBinding = new Binding("IsBackrest");
      isBackrestBinding.Source = Sofa;
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
    /// Получить диван
    /// </summary>
    /// <returns></returns>
    public SeatingFurniture GetFurniture()
    {
      return Sofa;
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
