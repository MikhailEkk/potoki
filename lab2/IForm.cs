using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary1;

namespace lab2
{
    public interface IForm
    {
      /// <summary>
      /// Получение устройства формы
      /// </summary>
      /// <returns></returns>
      SeatingFurniture GetFurniture();

      /// <summary>
      /// Открыть форму
      /// </summary>
      /// <returns></returns>
      bool Open();
    }
}
