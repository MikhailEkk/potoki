using WpfLibrary1;

namespace lab2_patterns.Factory
{
  /// <summary>
  /// Абстрактная фабрика
  /// </summary>
  public abstract class AbstractSeatingFurnitureFactory : ISeatingFurnitureFactory
  {
    /// <summary>
    /// Создание скамьи
    /// </summary>
    /// <returns></returns>
    public abstract Bench CreateBench();

    /// <summary>
    /// Создание табурета
    /// </summary>
    /// <returns></returns>
    public abstract Tabouret CreateTaburet();
  }
}
