
namespace WpfLibrary1
{
  /// <summary>
  /// ������ ��� �������
  /// </summary>
  public abstract class SeatingFurniture
  {
    /// <summary>
    /// �������� ������
    /// </summary>
    private string _material;

    /// <summary>
    /// ���������� ������� ����
    /// </summary>
    private int _seatingCapacity;

    /// <summary>
    /// ��������� ����������
    /// </summary>
    private double _costMaterials;

    /// <summary>
    /// ���������� �������������
    /// </summary>
    private int _id;

    /// <summary>
    /// �������� ���� _material
    /// </summary>
    public string Material
    {
      get { return _material; }
      set { _material = value; }
    }

    /// <summary>
    /// �������� ���� _costMaterials
    /// </summary>
    public double CostMaterials
    {
      get { return _costMaterials; }
      set { _costMaterials = value; }
    }

    /// <summary>
    /// �������� ���� _seatingCapacity
    /// </summary>
    public int SeatingCapacity
    {
      get { return _seatingCapacity; }
      set { _seatingCapacity = value; }
    }

    /// <summary>
    /// �������� ���� _id
    /// </summary>
    public int ID
    {
      get { return _id; }
      set { _id = value; }
    }

    /// <summary>
    /// �����������
    /// </summary>
    /// <param name="parMaterial">��������</param>
    /// <param name="parSeatingCapacity">���������� ����</param>
    /// <param name="parCostMaterials">��������� ����������</param>
    /// <param name="parId">���������� �������������</param>
    public SeatingFurniture(string parMaterial, int parSeatingCapacity, double parCostMaterials, int parId)
      {
      _id = parId;
      _material = parMaterial;
      _seatingCapacity = parSeatingCapacity;
      _costMaterials = parCostMaterials;
      }

    /// <summary>
    /// ������ ��������� ������
    /// </summary>
    /// <returns>���������</returns>
    public abstract double CalculateTotalPrice();
    }

}
