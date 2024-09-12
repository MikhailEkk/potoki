using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary1;

namespace lab2_patterns.Factory
{
  public class PrototypeFactory : AbstractSeatingFurnitureFactory
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
    /// Конструктор фабрики прототипов
    /// </summary>
    /// <param name="parBench">Скамья</param>
    /// <param name="parTaburet">Табурет</param>
    public PrototypeFactory(Bench parBench, Tabouret parTaburet) 
    {
      _bench = parBench;
      _tabouret = parTaburet;
    }

    /// <summary>
    /// Метод создания копии скамьи
    /// </summary>
    /// <returns>Копия скамьи</returns>
    public override Bench CreateBench()
    {
      return (Bench)_bench.Clone();
    }

    /// <summary>
    /// Метод создания копии табурета
    /// </summary>
    /// <returns></returns>
    public override Tabouret CreateTaburet()
    {
      return (Tabouret)_tabouret.Clone();
    }

    /// <summary>
    /// Представление названия фабрики прототипов
    /// </summary>
    /// <returns>Строка с названием фабрики</returns>
    public override string ToString()
    {
      return "Прототип";
    }
  }
}
