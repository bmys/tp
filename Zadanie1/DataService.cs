using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace Zadanie1
{
    /// <summary>
    /// Część zadania 4
    /// </summary>
    class DataService
    {
        private DataRepository dataRepository;

        public DataService(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }
        /// <summary>
        /// Zwraca informacje o pojeździe
        /// </summary>
        /// <param name="vehicles"></param>
        /// <returns></returns>
        public string PrintVehicle(IEnumerable<Vehicle> vehicles)
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
            return vehicleString;
        }
        /// <summary>
        /// Zwraca informacje o kliencie
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public String PrintClient(IEnumerable<Client> client)
        {
            string clientString = "";
            foreach (var item in client)
            {
                clientString += item;
            }
            return clientString;
        }
        /// <summary>
        /// Zwraca informacje o statusie pojazdu
        /// </summary>
        /// <param name="vehicleState"></param>
        public string PrintVehicleState(IEnumerable<VehicleState> vehicleState)
        {
            string vehicleStateString = "";
            foreach (var item in vehicleState)
            {
                vehicleStateString += item; 
            }
            return vehicleStateString;
        }
        /// <summary>
        /// Zwraca infoirmacje o Wypozyczeniu
        /// </summary>
        /// <param name="events"></param>
        public string PrintEvent(IEnumerable<Event> events)
        {
            string eventString = "";
            foreach (var item in events)
            {
                eventString += item;
            }
            return eventString;
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
        // Data service Vehicle
        /// <summary>
        /// Add Vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        public void AddVehicle(Vehicle vehicle)
        {
            if (!dataRepository.GetAllVehicleEnumerable().Contains(vehicle))
            {
                if (vehicle.Registration.Length <= 8)
                {
                    dataRepository.AddVehicle(vehicle);
                }
                else
                {
                    throw new ArgumentException("Zła liczba znaków rejesteacji");
                }
            }
            else
            {
                throw new ArgumentException("Pojazd już istenie");
            }

       
        }
        /// <summary>
        /// Delete vehicle
        /// </summary>
        /// <param name="rejestracja"></param>
        public void DeleteVehicle(String rejestracja)
        {
            if (dataRepository.GetAllVehicleEnumerable().Contains(dataRepository.GetVehicle(rejestracja)))
            {
                dataRepository.DeleteVehicle(rejestracja);
            }
            else
            {
                throw new ArgumentException("Brak Pujazdu w Repozytorium");
            }
        }
        /// <summary>
        /// Update Vehicle
        /// </summary>
        /// <param name="oldVehicle"></param>
        /// <param name="newVehicle"></param>
        public void UpdateVehicle(Vehicle oldVehicle, Vehicle newVehicle)
        {
            if (dataRepository.GetAllVehicleEnumerable().Contains(oldVehicle))
            {
                dataRepository.UpdateVehicle(oldVehicle, newVehicle);
            }
            else
            {
                throw new ArgumentException("Brak pojazdu który chcesz aktualizować");
            }
        }

        // Data service Client
        /// <summary>
        /// Add Client
        /// </summary>
        /// <param name="client"></param>
        public void AddClient(Client client)
        {
            if (!dataRepository.GetAllCLientsEnumerable().Contains(client))
            {
                if (client.Age >= 18)
                {
                    if(client.Pesel.Length == 11)
                    {
                        char plec = client.FirstName[client.FirstName.Length-1];
                        if(plec == 'A' || plec == 'a') // koncowa litera a oznacza kobietę
                        {
                            if((client.Pesel[client.Pesel.Length-2] % 2) == 0)
                            {
                                dataRepository.AddClient(client);
                            }
                            else
                            {
                                throw new ArgumentException("Pesel nie zgadza sie z imieniem, błędne dane, sprawdz czy 10 znak pesel sie zgadza");
                            }
                        }
                        else
                        {
                            if((client.Pesel[client.Pesel.Length - 2] % 2) != 0)
                            {
                                dataRepository.AddClient(client);
                            }
                            else
                            {
                                throw new ArgumentException("Pesel nie zgadza sie z imieniem, błędne dane, sprawdz czy 10 znak pesel sie zgadza");
                            }
                        }
                        
                        
                    }
                    else
                    {
                        throw new ArgumentException("Nieprawidłowy pesel");
                    }
                }
                else
                {
                    throw new ArgumentException("Niedozwolony wiek");
                }
            }
            else
            {
                throw new ArgumentException("Taki klient juz istnieje");
            }

        }
        /// <summary>
        /// Delete CLient
        /// </summary>
        /// <param name="pesel"></param>
        public void DeleteClient(string pesel)
        {
            if (dataRepository.GetAllCLientsEnumerable().Contains(dataRepository.GetClient(pesel)))
            {
                dataRepository.DeleteClient(pesel);
            }
            else
            {
                throw new ArgumentException("Taki klient nie istnieje");
            }
        }
        /// <summary>
        /// Update CLient
        /// </summary>
        /// <param name="oldClient"></param>
        /// <param name="newClient"></param>
        public void UpdateClient(Client oldClient, Client newClient)
        {
            if (dataRepository.GetAllCLientsEnumerable().Contains(oldClient))
            {
                if(newClient.Age >= 18 || newClient.Age == 0)
                {
                    if (newClient.Pesel.Length == 11 || newClient.Pesel == null)
                    {
                        dataRepository.UpdateClient(oldClient, newClient);
                    }
                    else
                    {
                        throw new ArgumentException("Nieprawidłowy pesel");
                    }
                }
                else
                {
                    throw new ArgumentException("Błędny wiek");
                }
            }
            else
            {
                throw new ArgumentException("Nie ma takiego klienta");
            }
        }

        //Data service Vehicle state
        /// <summary>
        /// Add Vehicle state
        /// </summary>
        /// <param name="vehicleState"></param>
        public void AddVehicleState(VehicleState vehicleState)
        {
            if (!dataRepository.GetAllVehicleStateIEnumerable().Contains(vehicleState))
            {               
                dataRepository.AddVehicleState(vehicleState);
            }
            else
            {
                throw new ArgumentException("Takie status pojazdu już istnieje");
            }
        }
        /// <summary>
        /// Delete Vehicle State
        /// </summary>
        /// <param name="vehiclestate"></param>
        public void DeleteVehicleState(VehicleState vehicleState)
        {
            if (dataRepository.GetAllVehicleStateIEnumerable().Contains(vehicleState))
            {
                dataRepository.DeleteVehicleState(vehicleState);
            }
            else
            {
                throw new ArgumentException("Takie status pojazdu nie juz nie istenieje");
            }
        }
        /// <summary>
        /// Update Vehicle state
        /// </summary>
        /// <param name="oldVehicleState"></param>
        /// <param name="newVehicleState"></param>
        public void UpdateVehicleState(VehicleState oldVehicleState, VehicleState newVehicleState)
        {
            if (dataRepository.GetAllVehicleStateIEnumerable().Contains(oldVehicleState))
            {
                dataRepository.UpdateVehicleState(oldVehicleState, newVehicleState);
            }
            else
            {
                throw new ArgumentException("takie status pojazdu nie istnieje");
            }
        }

        //Data service Event
        /// <summary>
        /// Add Event
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="vehicleState"></param>
        public void AddEvent(Client client, VehicleState vehicleState)
        {
            if (dataRepository.GetAllCLientsEnumerable().Contains(client) && vehicleState.Avaiable == false )
            {
                vehicleState.Avaiable = false;
                Event ev = new Event()
                {
                    Client = client,
                    RentalOfDate = DateTimeOffset.Now,
                    VehicleState = vehicleState                    
                };
                
                dataRepository.AddEvent(ev);
            }
            else
            {
                throw new ArgumentException("Takie wypożyczenie już istenije lub nie ma takiego klienta");
            }

        }
        /// <summary>
        /// Delete event
        /// </summary>
        /// <param name="events"></param>
        public void DeleteEvent(Event events)
        {
            if (dataRepository.GetAllEventEnumerable().Contains(events))
            {
                events.VehicleState.Avaiable = true;
                events.ReturnOfDate = DateTimeOffset.Now;
                dataRepository.DeleteEvent(events);

            }
            else
            {
                throw new ArgumentException("Takie Wypożyczenie nie istnieje");
            }
        }
        /// <summary>
        /// Update Event
        /// </summary>
        /// <param name="oldEvent"></param>
        /// <param name="newEvent"></param>
        public void UpdateEvent(Event oldEvent, Event newEvent)
        {
            if (dataRepository.GetAllEvent().Contains(oldEvent))
            {
                dataRepository.UpdateEvent(newEvent, oldEvent);
            }
            else
            {
                throw new ArgumentException("Takie wypożyczenie nie istenieje");
            }
        }
        
        /// <summary>
        /// Metoda zwracająca WYpozyczenia klienta
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public IEnumerable<Event> EventForClient(Client client)
        {
            List<Event> listEvent = new List<Event>();
            foreach (Event item in dataRepository.GetAllEventEnumerable())
            {
                if(item.Client == client)
                {
                    listEvent.Add(item);
                }
            }
            return listEvent;
        }//diagram

        /// <summary>
        /// Metoda zwraca Wypozyczenia pomiedzy data wypozyczenia i zwrotu
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public IEnumerable<Event> EventBetwenDateTime(DateTimeOffset startDateTime, DateTimeOffset endDateTime)
        {
            List<Event> listEvent = new List<Event>();
            foreach (Event item in dataRepository.GetAllEventEnumerable())
            {
                if (item.RentalOfDate >= startDateTime && item.ReturnOfDate <= endDateTime)
                {
                    listEvent.Add(item);
                }

            }
            return listEvent;
        }//diagram

    }
}
