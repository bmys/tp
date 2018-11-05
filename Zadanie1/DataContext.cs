using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.Runtime.Serialization;

//Add references with namespace ClassLibrary

/// <summary>
/// the class has a obiect database
/// </summary>
namespace Zadanie1
{
    [DataContract()]
    [Serializable] // objects of this class can be serialized
    public class DataContext
    {
        
        [DataMember()]
        public List<Client> listClients;
        [DataMember()]
        public Dictionary<string, Vehicle> dictionaryVehicles;
        [DataMember()]
        public ObservableCollection<Event> obsColEvents;
        [DataMember()]
        public List<VehicleState> listVehicleStates;


        public DataContext()
        {           
            this.listClients = new List<Client>();               
            this.dictionaryVehicles = new Dictionary<string, Vehicle>();
            this.obsColEvents = new ObservableCollection<Event>();
            this.listVehicleStates = new List<VehicleState>();
            obsColEvents.CollectionChanged += OnCollectionChanged;

        }
 
        public void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Dodano nowy obiekt do kolekcji ObservableCollection");
                foreach (Event ev in e.NewItems)
                {
                    Console.WriteLine(ev);
                }
            }
            else
            {
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    Console.WriteLine("Usunieto obiekt z kolekcji ObservableCollection");
                    foreach (Event ev in e.OldItems)
                    {
                        Console.WriteLine(ev);
                    }
                }
            }
        }
    }
}
