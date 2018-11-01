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

            Console.WriteLine(dataRepository.GetAllVehicle().Count());
            Vehicle oldVehicle = new Vehicle();
            oldVehicle = dataRepository.GetVehicle("ELE T98C");

            Vehicle newVehicle = new Vehicle()
            {
                Registration = "WA 77777",
                VehicleBrand = "Lamborghini",
                VehicleModel = "Usus"
            };

            dataRepository.UpdateVehicle(oldVehicle,newVehicle);
            Console.WriteLine(dataRepository.GetVehicle("WA 77777").ToString());
            dataRepository.DeleteVehicle("EL KWR8Y");
            Console.WriteLine(dataRepository.GetAllVehicle().Count());

            Client nowClient = new Client();
            nowClient = dataRepository.GetClient("98052978391");
            Console.WriteLine(nowClient.ToString());

            Console.WriteLine("Dobrze zwraca? \n"+dataRepository.GetEvent(nowClient).ToString() +"No Dobrze :-)");

            Console.ReadKey();
        }
    }
}
