using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;
namespace Zadanie1Test
{
    [TestClass]
    public class JsonLoadTest1
    {
    

        [TestMethod]
        public void TestCount()
        {
            DataFiller dataFiller = new WypelnianieJson();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataFiller)
            {
                DataContext = dataContext
            };

            dataRepository.Fill();

            Assert.AreEqual(dataContext.dictionaryVehicles.Count, 7);
            Assert.AreEqual(dataContext.listVehicleStates.Count, 6);
            Assert.AreEqual(dataContext.obsColEvents.Count, 5);
            Assert.AreEqual(dataContext.listClients.Count, 5);


        }
    }
}
