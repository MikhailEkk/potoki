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
  class Banquette : Bench
  {
    /// <summary>
    /// Наличие отсека для хранения
    /// </summary>
    private bool _storageCompartment;

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
    /// Получить количество оставшихся свободных мест
    /// </summary>
    /// <param name="parNumberOccupiedPlaces">Количество занятых мест</param>
    /// <returns>Количество свободных мест</returns>
    public int GetCountRemainingSeats(int parCountOccupiedPlaces)
    {
      return base.SeatingCapacity - parCountOccupiedPlaces;
    }
  }
}
