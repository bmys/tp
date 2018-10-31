using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace Zadanie1
{
    public class WypelnianieStalymi : DataFiller
    {
       
        public override void Fill(DataContext dataContext)
        {
            var listClients = dataContext.listClients;
            var dictionaryVehicles = dataContext.dictionaryVehicles;
            var obsColEvents = dataContext.obsColEvents;
            var listVehicleStates = dataContext.listVehicleStates;

          

            Client client1 = new Client()
            {
                //Set 
                Pesel = "96052909880",
                FirstName = "Mateusz",
                LastName = "Misiak",
                Age = 22
            };

            Client client2 = new Client()
            {
                //Set 
                Pesel = "95081878364",
                FirstName = "Bartosz",
                LastName = "Myśliwiec",
                Age = 23
            };

            Client client3 = new Client()
            {
                //Set 
                Pesel = "98052978391",
                FirstName = "Natalia",
                LastName = "Kwiat",
                Age = 20
            };

            Client client4 = new Client()
            {
                //Set 
                Pesel = "91070878328",
                FirstName = "Damian",
                LastName = "Nowak",
                Age = 23
            };

            Client client5 = new Client()
            {
                //Set 
                Pesel = "86070878328",
                FirstName = "Jacek",
                LastName = "Kubczak",
                Age = 32
            };

            listClients.Add(client1);
            listClients.Add(client2);
            listClients.Add(client3);
            listClients.Add(client4);
            listClients.Add(client5);

            Vehicle vehicle1 = new Vehicle()
            {
                Registration = "ELE 3G78",
                VehicleBrand = "BMW",
                VehicleModel = "E39"
            };

            Vehicle vehicle2 = new Vehicle()
            {
                Registration = "ELE T98C",
                VehicleBrand = "AUDI",
                VehicleModel = "A6"
            };

            Vehicle vehicle3 = new Vehicle()
            {
                Registration = "EL U98C5",
                VehicleBrand = "AUDI",
                VehicleModel = "A7"
            };


            Vehicle vehicle4 = new Vehicle()
            {
                Registration = "EL AF9CS",
                VehicleBrand = "BMW",
                VehicleModel = "M8"
            };

            Vehicle vehicle5 = new Vehicle()
            {
                Registration = "EL KWR8Y",
                VehicleBrand = "Mercenes",
                VehicleModel = "AMG C63"
            };

            Vehicle vehicle6 = new Vehicle()
            {
                Registration = "ELE AADR",
                VehicleBrand = "Mercenes",
                VehicleModel = "AMG CLA"
            };

            Vehicle vehicle7 = new Vehicle()
            {
                Registration = "WA B68L3",
                VehicleBrand = "Mazda",
                VehicleModel = "RX 8"
            };

        

            dataContext.dictionaryVehicles.Add(vehicle1.Registration, vehicle1);
            dataContext.dictionaryVehicles.Add(vehicle2.Registration, vehicle2);
            dataContext.dictionaryVehicles.Add(vehicle3.Registration, vehicle3);
            dataContext.dictionaryVehicles.Add(vehicle4.Registration, vehicle4);
            dataContext.dictionaryVehicles.Add(vehicle5.Registration, vehicle5);
            dataContext.dictionaryVehicles.Add(vehicle6.Registration, vehicle6);
            dataContext.dictionaryVehicles.Add(vehicle7.Registration, vehicle7);



            VehicleState vehicleState1 = new VehicleState()
            {
                Vehicle = vehicle1,
                Avaiable = true,
                RentalPrice = 400
            };

            VehicleState vehicleState2 = new VehicleState()
            {
                Vehicle = vehicle2,
                Avaiable = true,
                RentalPrice = 600
            };

            VehicleState vehicleState3 = new VehicleState()
            {
                Vehicle = vehicle3,
                Avaiable = true,
                RentalPrice = 700
            };

            VehicleState vehicleState4 = new VehicleState()
            {
                Vehicle = vehicle4,
                Avaiable = true,    
                RentalPrice = 1200
            };

            VehicleState vehicleState5 = new VehicleState()
            {
                Vehicle = vehicle5,
                Avaiable = true,               
                RentalPrice = 1100
            };

            VehicleState vehicleState6 = new VehicleState()
            {
                Vehicle = vehicle6,
                Avaiable = true,
                RentalPrice = 800
            };

            VehicleState vehicleState7 = new VehicleState()
            {
                Vehicle = vehicle7,
                Avaiable = true,
                RentalPrice = 900
            };

            listVehicleStates.Add(vehicleState1);
            listVehicleStates.Add(vehicleState2);
            listVehicleStates.Add(vehicleState3);
            listVehicleStates.Add(vehicleState4);
            listVehicleStates.Add(vehicleState5);
            listVehicleStates.Add(vehicleState7);

            Event event1 = new Event()
            {
                Client = client1,
                VehicleState = vehicleState1,
                //TimeSpan Przesunięcie czasu ze skoordynowanego czasu uniwersalnego (UTC).
                RentalOfDate = new DateTimeOffset(2018, 04, 20, 12, 0, 0, new TimeSpan(1, 0, 0)),
                ReturnOfDate = new DateTimeOffset(2018, 05, 20, 13, 0, 0, new TimeSpan(1, 0, 0))
            };

            Event event2 = new Event()
            {
                Client = client2,
                VehicleState = vehicleState2,
                //TimeSpan Przesunięcie czasu ze skoordynowanego czasu uniwersalnego (UTC).
                RentalOfDate = new DateTimeOffset(2018, 05, 05, 11, 0, 0, new TimeSpan(1, 0, 0)),
                ReturnOfDate = new DateTimeOffset(2018, 06, 05, 12, 0, 0, new TimeSpan(1, 0, 0))
            };

            Event event3 = new Event()
            {
                Client = client3,
                VehicleState = vehicleState3,
                //TimeSpan Przesunięcie czasu ze skoordynowanego czasu uniwersalnego (UTC).
                RentalOfDate = new DateTimeOffset(2018, 07, 15, 08, 0, 0, new TimeSpan(1, 0, 0)),
                ReturnOfDate = new DateTimeOffset(2018, 09, 16, 10, 0, 0, new TimeSpan(1, 0, 0))
            };

            Event event4 = new Event()
            {
                Client = client4,
                VehicleState = vehicleState4,
                //TimeSpan Przesunięcie czasu ze skoordynowanego czasu uniwersalnego (UTC).
                RentalOfDate = new DateTimeOffset(2018, 05, 28, 12, 0, 0, new TimeSpan(1, 0, 0)),
                ReturnOfDate = new DateTimeOffset(2018, 09, 28, 13, 0, 0, new TimeSpan(1, 0, 0))
            };

            Event event5 = new Event()
            {
                Client = client5,
                VehicleState = vehicleState5,
                //TimeSpan Przesunięcie czasu ze skoordynowanego czasu uniwersalnego (UTC).
                RentalOfDate = new DateTimeOffset(2018, 02, 03, 14, 0, 0, new TimeSpan(1, 0, 0)),
                ReturnOfDate = new DateTimeOffset(2018, 02, 15, 16, 0, 0, new TimeSpan(1, 0, 0))
            };



            obsColEvents.Add(event1);
            obsColEvents.Add(event2);
            obsColEvents.Add(event3);
            obsColEvents.Add(event4);
            obsColEvents.Add(event5);

        }
    }
 
}
