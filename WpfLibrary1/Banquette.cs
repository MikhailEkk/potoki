using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLibrary1
{
  /// <summary>
  /// Банкетка
  /// </summary>
  public class Banquette : Bench
  {
    /// <summary>
    /// Наличие отсека для хранения
    /// </summary>
    private bool _storageCompartment;

    /// <summary>
    /// Свойство поля _storageCompartment
    /// </summary>
    public bool StorageCompartment
    {
      get { return _storageCompartment; }
      set { _storageCompartment = value;  }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMaterial">Материал</param>
    /// <param name="parSeatingCapacity">Количество мест</param>
    /// <param name="parCostMaterials">Стоимость материалов</param>
    /// <param name="parId">Идентификатор</param>
    /// <param name="parIsBackrest">Наличие спинки</param>
    /// <param name="parStorageCompartment">Наличие отсека для хранения</param>
    public Banquette(
      string parMaterial, 
      int parSeatingCapacity, 
      double parCostMaterials, 
      int parId, 
      bool parIsBackrest,
      bool parStorageCompartment) : base(parMaterial, parSeatingCapacity, parCostMaterials, parId, parIsBackrest)
    {
      _storageCompartment = parStorageCompartment;
    }

    /// <summary>
    /// Пустой конструктор
    /// </summary>
    public Banquette() { }

    /// <summary>
    /// Конструктор копирования
    /// </summary>
    /// <param name="parFurniture"></param>
    public Banquette(Banquette parFurniture) : base(parFurniture)
    {
      Copy(parFurniture);
    }

    /// <summary>
    /// Получить количество оставшихся свободных мест
    /// </summary>
    /// <param name="parNumberOccupiedPlaces">Количество занятых мест</param>
    /// <returns>Количество свободных мест</returns>
    public int GetCountRemainingSeats(int parCountOccupiedPlaces)
    {
      return base.SeatingCapacity - parCountOccupiedPlaces;
    }

    /// <summary>
    /// Копирование свойств предмета
    /// </summary>
    /// <param name="parFurniture">Копируемый предмет</param>
    public override void Copy(SeatingFurniture parFurniture)
    {
      base.Copy(parFurniture);
      StorageCompartment = ((Banquette)parFurniture).StorageCompartment;

    }
  }
}
