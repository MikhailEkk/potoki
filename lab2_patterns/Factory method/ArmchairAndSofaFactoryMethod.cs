using lab2_patterns.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_patterns.Factory_method
{
  /// <summary>
  /// Фабричный метод для создания кресла и дивана
  /// </summary>
  public class ArmchairAndSofaFactoryMethod : AbstractSeatingFurnitureFactoryMethod
  {  
    /// <summary>
    /// Создание фабрики кресла и дивана
    /// </summary>
    /// <returns></returns>
    public override ISeatingFurnitureFactory CreateFactory()
    {
      return new ArmchairAndSofaFactory();
    }
  }
}
