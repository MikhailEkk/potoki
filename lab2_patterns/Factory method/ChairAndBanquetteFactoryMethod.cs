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
  /// Фпбричный метод для создания стула и банкетки
  /// </summary>
  public class ChairAndBanquetteFactoryMethod : AbstractSeatingFurnitureFactoryMethod
  { 
    /// <summary>
    /// Создание фабрики стула и банкетки
    /// </summary>
    /// <returns></returns>
    public override ISeatingFurnitureFactory CreateFactory()
    {
      return new ChairAndBanquetteFactory();
    }
  }
}
