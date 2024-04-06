using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLibrary1
{
  /// <summary>
  /// Кресло
  /// </summary>
  public class Armchair : Tabouret
  {
    /// <summary>
    /// Максимальная грузоподъемность одного колесика
    /// </summary>
    private const int MAX_WEIGHT_CAPACITY_WHEEL = 10;

    /// <summary>
    /// Количество колесиков
    /// </summary>
    private int _wheelCount;

    /// <summary>
    /// Свойство поля _wheelCount
    /// </summary>
    public int WheelCount
    {
      get { return _wheelCount; }
      set { _wheelCount = value; }
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
    /// <param name="parWheelCount">Количество колесиков</param>
    public Armchair(
      string parMaterial, 
      int parSeatingCapacity, 
      double parCostMaterials, 
      int parId, 
      int parHeight, 
      int parlegSquare, 
      int parWheelCount) : base(parMaterial, parSeatingCapacity, parCostMaterials, parId, parHeight, parlegSquare)
    {
      _wheelCount = parWheelCount;
    }

    /// <summary>
    /// Проверка грузоподъемности кресла
    /// </summary>
    /// <param name="parWeight">Вес, который нужно проверить</param>
    /// <returns>True, если стул может выдержать такой вес и False в противном случае</returns>
    public bool isLoadCapacity(int parWeight)
    {
      return parWeight <= (MAX_WEIGHT_CAPACITY_WHEEL * _wheelCount);
    }
  }
}
