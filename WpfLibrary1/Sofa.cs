using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLibrary1
{ 
  /// <summary>
  /// Диван
  /// </summary>
  public class Sofa : Bench
  {
    /// <summary>
    /// Стоимость транспортировки для короткой длины
    /// </summary>
    private const int COST_TRANSPORTATION_SHORT_CARGO = 70;

    /// <summary>
    /// Стоимость транспортировки для большой длины
    /// </summary>
    private const int COST_TRANSPORTATION_LONG_CARGO = 95;

    /// <summary>
    /// Локотники
    /// </summary>
    private bool _isElbow;

    /// <summary>
    /// Длинна
    /// </summary>
    private int _length;

    /// <summary>
    /// Свойство поля _isElbow
    /// </summary>
    public bool IsElbow
    {
      get { return _isElbow; }
      set { _isElbow = value; }
    }

    /// <summary>
    /// Свойство поля _length
    /// </summary>
    public int Length
    {
      get { return _length; }
      set { _length = value; }
    }

    /// <summary>
    /// Пустой конструктор
    /// </summary>
    public Sofa() { }

    /// <summary>
    /// Конструктор копирования
    /// </summary>
    /// <param name="parFurniture"></param>
    public Sofa(Sofa parFurniture) : base(parFurniture)
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
    /// <param name="parIsBackrest">Наличие спинки</param>
    /// <param name="parIsElbow">Наличие локотников</param>
    /// <param name="parLength">Длина</param>
    public Sofa(
      string parMaterial, 
      int parSeatingCapacity, 
      double parCostMaterials, 
      int parId, 
      bool parIsBackrest, 
      bool parIsElbow, 
      int parLength) : base(parMaterial, parSeatingCapacity, parCostMaterials, parId, parIsBackrest)
    {
      _isElbow = parIsElbow;
      _length = parLength;
    }

    /// <summary>
    /// Подсчет стоимости перевозки
    /// </summary>
    /// <param name="parDistance">Расстояние перевозки</param>
    /// <returns>Стоимость перевозки</returns>
    public int CostTransportation(int parDistance)
    {
      int costTransportation = 0;
      if (_length >= 1.5 )
      {
        costTransportation = parDistance * COST_TRANSPORTATION_LONG_CARGO;
      } else
      {
        costTransportation = parDistance * COST_TRANSPORTATION_SHORT_CARGO;
      } 
      return costTransportation;
    }

    /// <summary>
    /// Копирование свойств предмета
    /// </summary>
    /// <param name="parFurniture">Копируемый предмет</param>
    public override void Copy(SeatingFurniture parFurniture)
    {
      base.Copy(parFurniture);
      IsElbow = ((Sofa)parFurniture).IsElbow;
      IsBackrest = ((Sofa)parFurniture).IsBackrest;
    }

  }
}
