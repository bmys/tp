using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

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
  
        public void Fill()
        {
            filler.Fill(dataContext);
        }


        // implementation method C.R.U.D for vehicle

        public void AddVehicle(Vehicle vehicle)
        {
            dataContext.dictionaryVehicles.Add(vehicle.Registration, vehicle);
        }

        public Vehicle GetVehicle(string rejestracja)
        {
            return dataContext.dictionaryVehicles[rejestracja];
            
        }

        public IEnumerable<Vehicle> GetAllVehicle()
        {
            return dataContext.dictionaryVehicles.Values;
        }

        public Dictionary<string,Vehicle> GetAllVehicleDictionary()
        {
            return dataContext.dictionaryVehicles;
        }

        public void UpdateVehicle(Vehicle oldVehicle, Vehicle newVehicle)
        {
            var rejestracja = oldVehicle.Registration;
            oldVehicle.Registration = newVehicle.Registration;
            oldVehicle.VehicleBrand = newVehicle.VehicleBrand;
            oldVehicle.VehicleModel = newVehicle.VehicleModel;

         
            DeleteVehicle(rejestracja);
            dataContext.dictionaryVehicles.Add(oldVehicle.Registration, oldVehicle);
        }

        public void DeleteVehicle(string rejestracja)
        {
            dataContext.dictionaryVehicles.Remove(rejestracja);
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            dataContext.dictionaryVehicles.Remove(vehicle.Registration);
        }

        //implementation C.R.U.D for CLient
        public void AddClient(Client client)
        {
            dataContext.listClients.Add(client);
        }

        public Client GetClient(string pesel)
        {
            Client client;
            client = dataContext.listClients.Find(oElement => oElement.Pesel == pesel);
            return client;
        }

        public IEnumerable<Client> GetAllCLients()
        {
            return dataContext.listClients;
        }

        public List<Client> GetAllCLientsList()
        {
            return dataContext.listClients;
        }

        public void UpdateClient(Client oldCLient, Client newClient)
        {

            var pesel = oldCLient.Pesel;
            oldCLient.Pesel = newClient.Pesel;
            oldCLient.FirstName = newClient.FirstName;
            oldCLient.LastName = newClient.LastName;
            oldCLient.Age = newClient.Age;

            DeleteClient(pesel);
            dataContext.listClients.Add(oldCLient);


        }

        public void DeleteClient(string pesel)
        {
            Client client = new Client();
            client = dataContext.listClients.Find(oElement => oElement.Pesel == pesel);
            dataContext.listClients.Remove(client);
        }

        public void DeleteClient(Client client)
        {
            dataContext.listClients.Remove(client);
        }

        // Implements methon C.R.U.D for VehicleState
        public void AddVehicleState(VehicleState vehicleState)
        {
            dataContext.listVehicleStates.Add(vehicleState);
        }

        public VehicleState GetVehicleState(Vehicle vehicle)
        {
            VehicleState vehicleState = new VehicleState();
            vehicleState = dataContext.listVehicleStates.Find(oElement => oElement.Vehicle == vehicle);
            return vehicleState;
        }

        public IEnumerable<VehicleState> GetAllVehicleStateIEnumerable()
        {
            return dataContext.listVehicleStates;
        }

        public List<VehicleState> GetAllVehicleStateList()
        {
            return dataContext.listVehicleStates;
        }

        public void UpdateVehicleState(VehicleState oldVehicleState, VehicleState newVehicleState)
        {
            var vehicle = newVehicleState.Vehicle;
            oldVehicleState.Vehicle = newVehicleState.Vehicle;
            oldVehicleState.RentalPrice = newVehicleState.RentalPrice;
            oldVehicleState.Avaiable = newVehicleState.Avaiable;

            DeleteVehicleState(vehicle);
            dataContext.listVehicleStates.Add(oldVehicleState);
            
        }

        public void DeleteVehicleState(VehicleState vehicleState)
        {
            dataContext.listVehicleStates.Remove(vehicleState);
        }

        public void DeleteVehicleState(Vehicle vehicle)
        {           
            dataContext.listVehicleStates.Remove(GetVehicleState(vehicle));
        }

        // implements method C.R.U.D for Event
        
        public void AddEvent(Event events)
        {
            dataContext.obsColEvents.Add(events);
        }

        public Event GetEvent(Client client)
        {
            Event events = new Event();
            return events = dataContext.obsColEvents.Single(oElement => oElement.Client == client);
        }

        public Event GetEvent(VehicleState vehicleState)
        {
            Event events = new Event();
            return events = dataContext.obsColEvents.Single(oElem => oElem.VehicleState == vehicleState);
        }

        public ObservableCollection<Event> GetAllEvent()
        {
            return dataContext.obsColEvents;
        }
    
        public void UpdateEvent(Event newEvents, Event oldEvent)
        {
            var client = oldEvent.Client;
            oldEvent.Client = newEvents.Client;
            oldEvent.VehicleState = newEvents.VehicleState;
            oldEvent.RentalOfDate = newEvents.RentalOfDate;
            oldEvent.ReturnOfDate = newEvents.ReturnOfDate;

            DeleteEvent(client);
            dataContext.obsColEvents.Add(oldEvent);
        }

        public void DeleteEvent(Client client)
        {
            dataContext.obsColEvents.Remove(GetEvent(client));
        }

        public void DeleteEvent(Event events)
        {
            dataContext.obsColEvents.Remove(events);
        }

        public void DeleteEvent(VehicleState vehicleState)
        {
            dataContext.obsColEvents.Remove(GetEvent(vehicleState));
        }
    }
}
