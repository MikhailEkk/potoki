using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLibrary1
{
  /// <summary>
  /// Скамья
  /// </summary>
  public class Bench : SeatingFurniture
  {
    /// <summary>
    /// Коэффициент покраски скамьи со спинкой
    /// </summary>
    private const double FACTOR_PAITING_WITH_BACKREST = 0.9;

    /// <summary>
    /// Коэффициент покраски скамьи без спинки
    /// </summary>
    private const double FACTOR_PAITING_WITHOUT_BACKREST = 0.6;

    /// <summary>
    /// Наличие спинки
    /// </summary>
    private bool _isBackrest;

    /// <summary>
    /// Свойство поля _isBackrest
    /// </summary>
    public bool IsBackrest
    {
      get { return _isBackrest; }
      set { _isBackrest = value; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMaterial">Материал</param>
    /// <param name="parSeatingCapacity">Количество мест</param>
    /// <param name="parCostMaterials">Стоимость материалов</param>
    /// <param name="parId">Идентификатор</param>
    /// <param name="parIsBackrest">Наличие спинки</param>
    public Bench(
      string parMaterial, 
      int parSeatingCapacity, 
      double parCostMaterials, 
      int parId, 
      bool parIsBackrest) : base(parMaterial, parSeatingCapacity, parCostMaterials, parId)
    {
      _isBackrest = parIsBackrest;
    }

    /// <summary>
    /// Расчет стоимости скамьи
    /// </summary>
    /// <returns>Цена скамьи</returns>
    public override double CalculateTotalPrice()
    {
      double totalPrice = 0;
      double costFactor = 1;
      if (_isBackrest)
      {
        costFactor = 1.2;
      }
      totalPrice = base.CostMaterials * costFactor;
      return totalPrice;
    }

    /// <summary>
    /// Стоимость покраски лавочки
    /// </summary>
    /// <param name="parCostPaint">Цена краски</param>
    /// <returns>Цена покраски</returns>
    public double CalculateCostPainting(double parCostPaint)
    {
      double costPaiting = 0;
      if (_isBackrest)
      {
        costPaiting = parCostPaint * FACTOR_PAITING_WITH_BACKREST;
      } else
      {
        costPaiting = parCostPaint * FACTOR_PAITING_WITHOUT_BACKREST;
      }
      return costPaiting; 
    }
  }
}
