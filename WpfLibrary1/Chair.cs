using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLibrary1
{
  /// <summary>
  /// Стул
  /// </summary>
  public class Chair : Tabouret
  { 
    /// <summary>
    /// Ширина
    /// </summary>
    private const int WIDTH = 41;

    /// <summary>
    /// Длина
    /// </summary>
    private const int LENGTH = 44;

    /// <summary>
    /// Наличие мягкого настила
    /// </summary>
    private bool _isSoft;

    /// <summary>
    /// Свойство поля _isSoft
    /// </summary>
    public bool IsSoft
    {
      get { return _isSoft; }
      set { _isSoft = value; }
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
    /// <param name="parIsSoft">Наличие мягкого настила</param>
    public Chair(
      string parMaterial, 
      int parSeatingCapacity, 
      double parCostMaterials, 
      int parId, 
      int parHeight, 
      int parlegSquare, 
      bool parIsSoft) : base(parMaterial, parSeatingCapacity, parCostMaterials, parId, parHeight, parlegSquare)
    {
      _isSoft = parIsSoft;
    }

    /// <summary>
    /// Рассчитать стоимость упаковочной пленки
    /// </summary>
    /// <param name="parCostFilm">Стоимость пленки</param>
    /// <returns>Стоимость упаковки</returns>
    public int CalculateCostPackagingFilm(int parCostFilm)
    {
      return WIDTH * LENGTH * parCostFilm * base.Height;
    }
  }
}
