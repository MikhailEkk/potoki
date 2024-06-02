using lab2_patterns.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary1;

namespace lab2_patterns.Factory_method
{
  /// <summary>
  /// Фабричный метод для создания фабрики прототипов мебели для сидения 
  /// </summary>
  public class PrototypeFactoryMethod : AbstractSeatingFurnitureFactoryMethod
  {
    /// <summary>
    /// Скамья
    /// </summary>
    private Bench _bench;

    /// <summary>
    /// Табурет
    /// </summary>
    private Tabouret _tabouret;

    /// <summary>
    /// Конструктор фабричного метода прототипов мебели для сидения
    /// </summary>
    /// <param name="parBench">Скамья</param>
    /// <param name="parTabouret">Табурет</param>
    public PrototypeFactoryMethod(Bench parBench, Tabouret parTabouret)
    {
      _bench = parBench;
      _tabouret = parTabouret;
    }

    /// <summary>
    /// Создание фабрики прототипов мебели для сидения
    /// </summary>
    /// <returns>Экземпляр фабрики прототипов</returns>
    public override ISeatingFurnitureFactory CreateFactory()
    {
      return new PrototypeFactory(_bench, _tabouret);
    }
  }
}
