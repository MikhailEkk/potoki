using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary1;

namespace lab2_patterns.Factory
{
  /// <summary>
  /// Фабрика создания банкетки и стула
  /// </summary>
  public class ChairAndBanquetteFactory : AbstractSeatingFurnitureFactory
  {
    /// <summary>
    /// Создание банкетки
    /// </summary>
    /// <returns></returns>
    public override Bench CreateBench()
    {
      return new Banquette();
    }

    /// <summary>
    /// Создание стула
    /// </summary>
    /// <returns></returns>
    public override Tabouret CreateTaburet()
    {
      return new Chair();
    }

    /// <summary>
    /// Предоставление названия фабрики
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return "Банкетка и стул";
    }
  }
}
