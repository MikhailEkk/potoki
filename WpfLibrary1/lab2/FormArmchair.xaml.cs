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
    /// <param name="parIsAllowCancel"></param>
    /// <param name="parAction"></param>
    public FormArmchair(Armchair parArmchair, bool parIsAllowEdit, bool parIsAllowCancel, FormAction parAction)
    {
      InitializeComponent();
      Armchair = new Armchair(parArmchair);
      DataContext = Armchair;
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
    /// Обработчик ввода чисел с плавающей точкой
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TextFloatType_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {

      if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".") && (!this.TextBoxCostMaterials.Text.Contains(".") && this.TextBoxCostMaterials.Text.Length != 0)))
      {
        e.Handled = true;
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
