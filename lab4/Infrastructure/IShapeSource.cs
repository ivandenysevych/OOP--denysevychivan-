using System.Collections.Generic;
using lab4.Domain;

namespace lab4.Infrastructure
{
    // Джерело фігур: дозволяє легко підмінити спосіб отримання (памʼять, файл, БД)
    public interface IShapeSource
    {
        IList<IArea> GetShapes();
    }
}
