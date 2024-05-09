using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLibrary1
{
  /// <summary>
  /// Табурет
  /// </summary>
  public class Tabouret : SeatingFurniture
  {
    /// <summary>
    /// Высота
    /// </summary>
    private int _height;

    /// <summary>
    /// Площадь ножки
    /// </summary>
    private int _legSquare;

    /// <summary>
    /// Свойство поля _height
    /// </summary>
    public int Height
    {
      get { return _height; }
      set { _height = value; }
    }

    /// <summary>
    /// Свойство поля _legSquare
    /// </summary>
    public int LegSquare
    {
      get { return _legSquare; }
      set { _legSquare = value; }
    }

    /// <summary>
    /// Пустой конструктор
    /// </summary>
    public Tabouret() { }

    /// <summary>
    /// Конструктор копирования
    /// </summary>
    /// <param name="parFurniture"></param>
    public Tabouret(Tabouret parFurniture) : base(parFurniture)
    {
      Copy(parFurniture);
    }

    /// <summary>
    /// Конструктор класса
    /// </summary>
    /// <param name="parMaterial">Материал</param>
    /// <param name="parSeatingCapacity">Количество мест</param>
    /// <param name="parCostMaterials">Стоимость материалов</param>
    /// <param name="parId">Идентификатор</param>
    /// <param name="parHeight">Высота</param>
    /// <param name="parlegSquare">Площадь ножки</param>
    public Tabouret(
      string parMaterial, 
      int parSeatingCapacity, 
      double parCostMaterials, 
      int parId, 
      int parHeight, 
      int parlegSquare) : base(parMaterial, parSeatingCapacity, parCostMaterials, parId)
    {
      _height = parHeight;
      _legSquare = parlegSquare;
    }

    /// <summary>
    /// Расчет стоимости табурета
    /// </summary>
    /// <returns>Стоимость</returns>
    public double CalculateTotalPrice()
    {
      return base.CostMaterials;
    }

    /// <summary>
    /// Расчет давления табурета на пол
    /// </summary>
    /// <param name="parWeight">Вес</param>
    /// <returns>Сила давления ножек на поверхность пола</returns>
    public double CalculatePressure(int parWeight) 
    {
      return parWeight / 4 * _legSquare;  
    }
  }
}
