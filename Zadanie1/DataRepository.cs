using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class DataRepository
    {
        private DataContext dataContext;
        private DataFiller filler;

        //Constructor injection
        /// <summary>
        /// Constructor set CollectionFilleAbstract, Constructor injection
        /// </summary>
        /// <param name="fill"></param>
        public DataRepository(DataFiller filler)
        {
            this.filler = filler;
            
        }

        public DataContext DataContext {set => dataContext = value; }
        //public DataFiller Filler { get => filler; set => filler = value; }

        public void Fill()
        {
            filler.Fill(dataContext);
        }

    }
}
