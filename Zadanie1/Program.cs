using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.IO;
using Newtonsoft.Json;

//Mateusz Misiak
//Bartosz Myśliwiec
//30.10.2018
namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            // DataFiller dataFiller = new WypelnianieStalymi();      
            DataFiller dataFiller = new WypelnianieJson("dane.json");      

            DataContext dataContext = new DataContext();

            DataRepository dataRepository = new DataRepository(dataFiller)
            {
                DataContext = dataContext
            };
            dataRepository.Fill();

            foreach(var kj in dataRepository.GetAllVehicleEnumerable())
                System.Console.WriteLine(kj);
           // string json = JsonConvert.SerializeObject(dataContext);
            Console.ReadKey();
        }
    }
}
