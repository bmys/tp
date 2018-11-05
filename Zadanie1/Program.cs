using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

//Mateusz Misiak
//Bartosz Myśliwiec
//30.10.2018
namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            DataFiller dataFiller = new WypelnianieStalymi();      
            DataContext dataContext = new DataContext();

            DataRepository dataRepository = new DataRepository(dataFiller)
            {
                DataContext = dataContext
            };
            dataRepository.Fill();

          
            Console.ReadKey();
        }
    }
}
