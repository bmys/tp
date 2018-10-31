using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// abstract class that fills the data
/// </summary>
namespace Zadanie1
{
    public abstract class DataFiller
    {
        /*
         * Przekazywanie poprzez odwołanie powoduje, że każda zmiana argumentu
         * w metodzie wywoływanej jest odzwierciedlana w wywoływania metody.
         */
        public abstract void Fill(ref DataContext dataContext);
    }
}
