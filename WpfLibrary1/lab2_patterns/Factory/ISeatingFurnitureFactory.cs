using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary1;

namespace lab2_patterns.Factory
{ /// <summary>
  /// Интерфейс фабрики
  /// </summary>
  public interface ISeatingFurnitureFactory
  {
    /// <summary>
    /// Создание табурета
    /// </summary>
    /// <returns></returns>
    Tabouret CreateTaburet();

    /// <summary>
    /// Создание скамьи
    /// </summary>
    /// <returns></returns>
    Bench CreateBench(); 
  }
}
