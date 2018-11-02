using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace Zadanie1
{
    class DataService
    {
        private DataRepository dataRepository;

        public DataService(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public void PrintVehicle(IEnumerable<Vehicle> vehicles)
        {
            string vehicleString = "";

            foreach (Vehicle vehicle in vehicles)
            {
                vehicleString += vehicle;
            }

            //foreach (var item in vehicles)
            //{
            //    vehicleString += item.ToString();
            //}

        }

        public void PrintClient(IEnumerable<Client> client)
        {
            string clientString = "";
            foreach (var item in client)
            {
                clientString += item;
            }
        }

        public void PrintVehicleState(IEnumerable<VehicleState> vehicleState)
        {
            string vehicleStateString = "";
            foreach (var item in vehicleState)
            {
                vehicleStateString += item; 
            }
        }

        public void PrintEvent(IEnumerable<Event> events)
        {
            string eventString = "";
            foreach (var item in events)
            {
                eventString += item;
            }
        }

        public string PrintAll()
        {
            string printAll = "";
            IEnumerable<Vehicle> enumerableVehicle = this.dataRepository.GetAllVehicleEnumerable();
            IEnumerable<Client> enumerableClient = this.dataRepository.GetAllCLientsEnumerable();
            IEnumerable<VehicleState> enumerableVehicleState = this.dataRepository.GetAllVehicleStateIEnumerable();
            IEnumerable<Event> enumerableEvent = this.dataRepository.GetAllEventEnumerable();
            foreach (var item in enumerableClient)
            {
                printAll += item + "\n";
                foreach (var it in enumerableEvent)
                {
                    if (it.Client == item )
                    {
                        printAll += it + "\n";
                    }
                        
                }
            }
            return printAll;
        }
    }
}
