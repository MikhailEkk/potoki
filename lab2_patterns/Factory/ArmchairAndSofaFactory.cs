using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary1;

namespace lab2_patterns.Factory
{
  /// <summary>
  /// Фабрика создания кресла и дивана
  /// </summary>
  public class ArmchairAndSofaFactory : AbstractSeatingFurnitureFactory
  {
    /// <summary>
    /// Создание дивана
    /// </summary>
    /// <returns></returns>
    public override Bench CreateBench()
    {
      return new Sofa();
    }

    /// <summary>
    /// Создание кресла
    /// </summary>
    /// <returns></returns>
    public override Tabouret CreateTaburet()
    {
      return new Armchair();
    }

    /// <summary>
    /// Предоставление названия фабрики
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return "Кресло и диван";
    }
  }
}
