
using System.Xml.Linq;

namespace WpfLibrary1
{
  /// <summary>
  /// Мебель для сидения
  /// </summary>
  public abstract class SeatingFurniture
  {
    /// <summary>
    /// Материал мебели
    /// </summary>
    private string _material;

    /// <summary>
    /// Количество сидячих мест
    /// </summary>
    private int _seatingCapacity;

    /// <summary>
    /// Стоимость материалов
    /// </summary>
    private double _costMaterials;

    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    private int _id;

    /// <summary>
    /// Свойство объекта класса
    /// </summary>
    public SeatingFurniture ParSeatingFurniture { get;}

    /// <summary>
    /// Свойство поля _material
    /// </summary>
    public string Material
    {
      get { return _material; }
      set { _material = value; }
    }

    /// <summary>
    /// Свойство поля _costMaterials
    /// </summary>
    public double CostMaterials
    {
      get { return _costMaterials; }
      set { _costMaterials = value; }
    }

    /// <summary>
    /// Свойство поля _seatingCapacity
    /// </summary>
    public int SeatingCapacity
    {
      get { return _seatingCapacity; }
      set { _seatingCapacity = value; }
    }

    /// <summary>
    /// Свойство поля _id
    /// </summary>
    public int ID
    {
      get { return _id; }
      set { _id = value; }
    }

    /// <summary>
    /// Пустой конструктор
    /// </summary>
    public SeatingFurniture() { }

    /// <summary>
    /// Конструктор копирования
    /// </summary>
    /// <param name="parSeatingFurniture"></param>
    public SeatingFurniture(SeatingFurniture parSeatingFurniture)
    {
      ParSeatingFurniture = parSeatingFurniture;  
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMaterial">Материал</param>
    /// <param name="parSeatingCapacity">Количество мест</param>
    /// <param name="parCostMaterials">Стоимость материалов</param>
    /// <param name="parId">Уникальный идентификатор</param>
    public SeatingFurniture(string parMaterial, int parSeatingCapacity, double parCostMaterials, int parId)
      {
      _id = parId;
      _material = parMaterial;
      _seatingCapacity = parSeatingCapacity;
      _costMaterials = parCostMaterials;
      }

    /// <summary>
    /// Конструктор свойств предмета
    /// </summary>
    /// <param name="parFurniture"></param>
    public virtual void Copy(SeatingFurniture parFurniture)
    {
      Material = parFurniture.Material;
      CostMaterials = parFurniture.CostMaterials;
      ID = parFurniture.ID;
      SeatingCapacity = parFurniture.SeatingCapacity;
    }

    public abstract object Clone();
  }

}
