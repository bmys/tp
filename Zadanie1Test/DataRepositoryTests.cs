using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using Zadanie1;
using System.Linq;


namespace Zadanie1Test
{
    
    [TestClass]
    public class DataRepositoryTests
    {
        /// <summary>
        /// Test Repository daabase const
        /// </summary>
        [TestMethod]
        public void TestDataRepository()
        {
            DataFiller dataFiller = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataFiller)
            {
                DataContext = dataContext
            };
            dataRepository.Fill();


            Assert.AreEqual(dataRepository.GetAllVehicleEnumerable().Count(), 7);
            Assert.AreEqual(dataRepository.GetAllCLientsEnumerable().Count(), 5);
            Assert.AreEqual(dataRepository.GetAllEvent().Count(), 5);
            Assert.AreEqual(dataRepository.GetAllVehicleStateIEnumerable().Count(), 6);
        }
        /// <summary>
        /// Test Add
        /// </summary>
        [TestMethod]
        public void TestAddRepository()
        {
            DataFiller dataFiller = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataFiller)
            {
                DataContext = dataContext
            };
            dataRepository.Fill();

            // Test for add vehicle
            Vehicle newVehicle = new Vehicle()
            {
                Registration = "WA 77777",
                VehicleBrand = "Lamborghini",
                VehicleModel = "Usus"
            };

            Assert.AreEqual(dataRepository.GetAllVehicleEnumerable().Count(), 7);
            dataRepository.AddVehicle(newVehicle);
            Assert.AreEqual(dataRepository.GetAllVehicleEnumerable().Count(), 8);

            //Test for add Client
            Client newClient = new Client()
            {
                FirstName = "Adrian",
                LastName = "Michalak",
                Age = 19,
                Pesel = "2323425982"
            };
            Assert.AreEqual(dataRepository.GetAllCLientsEnumerable().Count(),5);
            dataRepository.AddClient(newClient);
            Assert.AreEqual(dataRepository.GetAllCLientsEnumerable().Count(), 6);

            //Test for add VehicleStatus
            VehicleState newVehicleStatus = new VehicleState()
            {
                Vehicle = newVehicle,
                Avaiable = false,
                RentalPrice = 2000
            };

            Assert.AreEqual(dataRepository.GetAllVehicleStateIEnumerable().Count(),6);
            dataRepository.AddVehicleState(newVehicleStatus);
            Assert.AreEqual(dataRepository.GetAllVehicleStateIEnumerable().Count(), 7);

            Event newEvent = new Event()
            {
                Client = newClient,
                VehicleState = newVehicleStatus,
                RentalOfDate = new DateTimeOffset(2018, 02, 22, 12, 0, 0, new TimeSpan(1, 0, 0)),
                ReturnOfDate = new DateTimeOffset(2018, 04, 09, 13, 0, 0, new TimeSpan(1, 0, 0))
            };

            Assert.AreEqual(dataRepository.GetAllEventEnumerable().Count(), 5);
            dataRepository.AddEvent(newEvent);
            Assert.AreEqual(dataRepository.GetAllEventEnumerable().Count(), 6);
        }
        /// <summary>
        /// Test Delete 
        /// </summary>
        [TestMethod]
        public void TestDeleteRepository()
        {
            DataFiller dataFiller = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataFiller)
            {
                DataContext = dataContext
            };
            dataRepository.Fill();

            //Delete vehicle
            Assert.AreEqual(dataRepository.GetAllVehicleEnumerable().Count(), 7);
            dataRepository.DeleteVehicle("ELE T98C");
            Assert.AreEqual(dataRepository.GetAllVehicleEnumerable().Count(), 6);

            //Delete Client
            Assert.AreEqual(dataRepository.GetAllCLientsEnumerable().Count(), 5);
            dataRepository.DeleteClient("86070878328");
            Assert.AreEqual(dataRepository.GetAllCLientsEnumerable().Count(), 4);

            //Delete VehicleState
            Assert.AreEqual(dataRepository.GetAllVehicleStateIEnumerable().Count(), 6);
            Vehicle vehicle = new Vehicle();
            vehicle = dataRepository.GetVehicle("EL KWR8Y");
            dataRepository.DeleteVehicleState(vehicle);
            Assert.AreEqual(dataRepository.GetAllVehicleStateIEnumerable().Count(), 5);
            //Assert.AreEqual(dataRepository.GetAllVehicleEnumerable().Count(), 6);
            //Assert.AreEqual(dataRepository.GetVehicle("EL KWR8Y"), vehicle);

            //Delete Evet
            Assert.AreEqual(dataRepository.GetAllEventEnumerable().Count(), 5);
            Client client = new Client();
            client = dataRepository.GetClient("91070878328");
            dataRepository.DeleteEvent(client);          
            Assert.AreEqual(dataRepository.GetAllEventEnumerable().Count(), 4);

        }
        /// <summary>
        /// Test Update
        /// </summary>
        [TestMethod]
        public void TestUpdateRepository()
        {
            DataFiller dataFiller = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataFiller)
            {
                DataContext = dataContext
            };
            dataRepository.Fill();

            //Update Client
            Client newCLient = new Client()
            {
                //Set
                FirstName = "Dariusz" 
               // Age = 26
                
            };

            Assert.AreEqual(dataRepository.GetClient("91070878328").Age, 23);
            dataRepository.UpdateClient(dataRepository.GetClient("91070878328"), newCLient);
            Assert.AreEqual(dataRepository.GetClient("91070878328").Age, 23);
            Assert.AreEqual(dataRepository.GetClient("91070878328").Pesel, "91070878328");
            Assert.AreEqual(dataRepository.GetClient("91070878328").FirstName, "Dariusz");

            //Update Vehicle

            Vehicle newVehicle = new Vehicle()
            {
                Registration = "WA K88BN"
            };
            //TODO  zmienic update i ustawic nowa marke
            Assert.AreEqual(dataRepository.GetVehicle("EL U98C5").Registration, "EL U98C5");
            dataRepository.UpdateVehicle(dataRepository.GetVehicle("EL U98C5"), newVehicle);
            Assert.AreEqual(dataRepository.GetVehicle("WA K88BN").VehicleBrand, "AUDI");
            Assert.AreEqual(dataRepository.GetVehicle("WA K88BN").VehicleModel, "A7");

            //Update VehicleState

            VehicleState newVehicleState = new VehicleState()
            {
                //Vehicle = newVehicle,
                Avaiable = false,
                RentalPrice = 650
            };

            Vehicle newVehicle2 = new Vehicle();
            newVehicle2 = dataRepository.GetVehicle("WA K88BN");

            VehicleState oldVehicleState = new VehicleState();
            oldVehicleState = dataRepository.GetVehicleState(newVehicle2);

            Assert.AreEqual(dataRepository.GetVehicleState(newVehicle2).RentalPrice, 700);
            Assert.IsTrue(dataRepository.GetVehicleState(newVehicle2).Avaiable);
            Assert.AreEqual(dataRepository.GetVehicleState(newVehicle2).Vehicle, newVehicle2);
            dataRepository.UpdateVehicleState(oldVehicleState, newVehicleState);
            Assert.AreEqual(dataRepository.GetVehicleState(newVehicle2).RentalPrice, 650);
            Assert.IsFalse(dataRepository.GetVehicleState(newVehicle2).Avaiable);

            //Update Event

            Event newEvent = new Event()
            {
                RentalOfDate = new DateTimeOffset(2018, 10, 29, 12, 0, 0, new TimeSpan(1, 0, 0)),
                ReturnOfDate = new DateTimeOffset(2018, 11, 29, 14, 30, 0, new TimeSpan(1, 0, 0))

            };

            Client newClient2 = new Client();
            newClient2 = dataRepository.GetClient("91070878328");
         

            Assert.AreEqual(dataRepository.GetEvent(newClient2).Client, newClient2 );
            Assert.AreEqual(dataRepository.GetEvent(newClient2).RentalOfDate, 
                new DateTimeOffset(2018, 05, 28, 12, 0, 0, new TimeSpan(1, 0, 0)));
            Assert.AreEqual(dataRepository.GetEvent(newClient2).ReturnOfDate,
                new DateTimeOffset(2018, 09, 28, 13, 0, 0, new TimeSpan(1, 0, 0)));
            dataRepository.UpdateEvent(newEvent, dataRepository.GetEvent(newClient2));
            Assert.AreEqual(dataRepository.GetEvent(newClient2).Client, newClient2);
            Assert.AreEqual(dataRepository.GetEvent(newClient2).RentalOfDate,
              new DateTimeOffset(2018, 10, 29, 12, 0, 0, new TimeSpan(1, 0, 0)));
            Assert.AreEqual(dataRepository.GetEvent(newClient2).ReturnOfDate,
                new DateTimeOffset(2018, 11, 29, 14, 30, 0, new TimeSpan(1, 0, 0)));

        }


    }
}
