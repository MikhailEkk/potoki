using lab2_patterns.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_patterns.Factory_method
{
  /// <summary>
  /// Абстрактный фабричный метод
  /// </summary>
  public abstract class AbstractSeatingFurnitureFactoryMethod : ISeatingFurnitureFactoryMethod
  {
    /// <summary>
    /// Создание фабрики
    /// </summary>
    /// <returns></returns>
    public abstract ISeatingFurnitureFactory CreateFactory();
  }
}
