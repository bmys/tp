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

       
        /// <summary>
        /// Constructor set CollectionFilleAbstract, Constructor injection
        /// </summary>
        /// <param name="fill"></param>
        public DataRepository(DataFiller filler)
        {
            this.filler = filler;           
        }

        public DataContext DataContext {set => dataContext = value; }
        /// <summary>
        /// Załadowanie naszych danych
        /// </summary>
        public void Fill()
        {
            filler.Fill(dataContext);
        }


        // implementation method C.R.U.D for vehicle
        public void AddVehicle(Vehicle vehicle)
        {
            dataContext.dictionaryVehicles.Add(vehicle.Registration, vehicle);
        } //diagram

        public Vehicle GetVehicle(string rejestracja)
        {
            return dataContext.dictionaryVehicles[rejestracja];
            
        }//diagram

        public IEnumerable<Vehicle> GetAllVehicleEnumerable()
        {
            return dataContext.dictionaryVehicles.Values;
        }//diagram

        public Dictionary<string,Vehicle> GetAllVehicleDictionary()
        {
            return dataContext.dictionaryVehicles;
        }

        public void UpdateVehicle(Vehicle oldVehicle, Vehicle newVehicle)
        {
            var rejestracja = oldVehicle.Registration;
            if (newVehicle.Registration == null) { oldVehicle.Registration = oldVehicle.Registration; }
            else { oldVehicle.Registration = newVehicle.Registration; }

            if (newVehicle.VehicleBrand == null) { oldVehicle.VehicleBrand = oldVehicle.VehicleBrand; }
            else { oldVehicle.VehicleBrand = newVehicle.VehicleBrand; }

            if (newVehicle.VehicleModel == null) { oldVehicle.VehicleModel = oldVehicle.VehicleModel; }
            else { oldVehicle.VehicleModel = newVehicle.VehicleModel; }

         
            DeleteVehicle(rejestracja);
            dataContext.dictionaryVehicles.Add(oldVehicle.Registration, oldVehicle);
        }//diagram

        public void DeleteVehicle(string rejestracja)
        {
            dataContext.dictionaryVehicles.Remove(rejestracja);
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            dataContext.dictionaryVehicles.Remove(vehicle.Registration);
        } //diagram


        //implementation C.R.U.D for CLient
        public void AddClient(Client client)
        {
            dataContext.listClients.Add(client);
        }//diagram

        public Client GetClient(string pesel)
        {
            Client client;
            client = dataContext.listClients.Find(oElement => oElement.Pesel == pesel);
            return client;
        }

        public Client GetClient(int index)
        {
            return dataContext.listClients[index];
        }  // diagram

        public IEnumerable<Client> GetAllCLientsEnumerable()
        {
            return dataContext.listClients;
        }//diagram

        public List<Client> GetAllCLientsList()
        {
            return dataContext.listClients;
        }

        public void UpdateClient(Client oldCLient, Client newClient)
        {

            var pesel = oldCLient.Pesel;
            if (newClient.Pesel == null) { oldCLient.Pesel = oldCLient.Pesel;}
            else { oldCLient.Pesel = newClient.Pesel; }

            if (newClient.FirstName == null) { oldCLient.FirstName = oldCLient.FirstName; }
            else { oldCLient.FirstName = newClient.FirstName; }

            if (newClient.LastName == null) { oldCLient.LastName = oldCLient.LastName; }
            else { oldCLient.LastName = newClient.LastName; }

            if (newClient.Age == 0) { oldCLient.Age = oldCLient.Age; }
            else { oldCLient.Age = newClient.Age; }

            DeleteClient(pesel);
            dataContext.listClients.Add(oldCLient);


        }//diagram

        public void DeleteClient(string pesel)
        {
            Client client = new Client();
            client = dataContext.listClients.Find(oElement => oElement.Pesel == pesel);
            dataContext.listClients.Remove(client);
        }

        public void DeleteClient(Client client)
        {
            dataContext.listClients.Remove(client);
        }//diagram


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
            if (newVehicleState.Vehicle == null) { oldVehicleState.Vehicle = oldVehicleState.Vehicle; }
            else { oldVehicleState.Vehicle = newVehicleState.Vehicle; }

            if (newVehicleState.RentalPrice == 0) { oldVehicleState.RentalPrice = oldVehicleState.RentalPrice; }
            else { oldVehicleState.RentalPrice = newVehicleState.RentalPrice; }

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

        public IEnumerable<Event> GetAllEventEnumerable()
        {
            return dataContext.obsColEvents;
        }
    
        public void UpdateEvent(Event newEvents, Event oldEvent)
        {
            var client = oldEvent.Client;

            if (newEvents.Client == null) { oldEvent.Client = oldEvent.Client; }
            else { oldEvent.Client = newEvents.Client; }

            if (newEvents.VehicleState == null) { oldEvent.VehicleState = oldEvent.VehicleState; }
            else { oldEvent.VehicleState = newEvents.VehicleState; }

            if (newEvents.RentalOfDate == null) { oldEvent.RentalOfDate = oldEvent.RentalOfDate; }
            else { oldEvent.RentalOfDate = newEvents.RentalOfDate; }

            if (newEvents.ReturnOfDate == null) { oldEvent.ReturnOfDate = oldEvent.ReturnOfDate; }
            else { oldEvent.ReturnOfDate = newEvents.ReturnOfDate; }

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
