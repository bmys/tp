using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ClassLibrary;
using System.IO;

namespace Zadanie1
{
    public class WypelnianieJson : DataFiller
    {
        public override void Fill(DataContext dataContext)
        {
            using (StreamReader reader = new StreamReader("dane.json"))
            {
                string jsonString = reader.ReadToEnd();
                DataItem dataItems = JsonConvert.DeserializeObject<DataItem>(jsonString);

                foreach (Client client in dataItems.listClients)
                    dataContext.listClients.Add(client);

                foreach (var vehicle in dataItems.dictionaryVehicles)
                   // dataContext.dictionaryVehicles =  new Dictionary<string, Vehicle> { { vehicle.Key, vehicle.Value } };
                dataContext.dictionaryVehicles.Add( vehicle.Key, vehicle.Value);

                foreach (VehicleState vehicleState in dataItems.listVehicleStates)
                    dataContext.listVehicleStates.Add(vehicleState);

                foreach (Event _event in dataItems.obsColEvents)
                    dataContext.obsColEvents.Add(_event);

            }
 
        }
    }

    public class DataItem
    {
        public List<Client> listClients;
        public Dictionary<string, Vehicle> dictionaryVehicles;
        public List<VehicleState> listVehicleStates;
        public List<Event> obsColEvents;
    }
}
