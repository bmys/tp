using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
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
        // obsColEvent ToString display all information
        private List<Client> listClients;
        private Dictionary<string, Vehicle> dictionaryVehicles;
        private ObservableCollection<Event> obsColEvents;
        private List<VehicleState> listVehicleStates;

        public DataContext()
        {
            [DataMember()]
            this.listClients = new List<Client>();
                [DataMember()]
            this.dictionaryVehicles = new Dictionary<string, Vehicle>();
            this.obsColEvents = new ObservableCollection<Event>();
            this.listVehicleStates = new List<VehicleState>();
           // obsColEvents.CollectionChanged += Item_CollectionCHanged;


            //CollectioChanged Occurs when an element is added, removed, changed,
            //CollectionChanged is event, show F12
            obsColEvents.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs item) =>
            {

                if (item.Action == NotifyCollectionChangedAction.Add)
                {
                    Console.WriteLine("Dodano nowy obiekt do kolekcji ObservableCollection");
                    foreach (Event e in item.NewItems)
                    {
                        Console.WriteLine(item);
                    }
}
                else
                {
                   if(item.Action == NotifyCollectionChangedAction.Remove)
                   {
                        Console.WriteLine("Usunieto obiekt z kolekcji ObservableCollection");
                        foreach(Event e in item.NewItems)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
            };

        }

        // two option
        //void Item_CollectionCHanged(object sender, NotifyCollectionChangedEventArgs item)
        //{
        //    if (item.Action == NotifyCollectionChangedAction.Add)
        //    {
        //        Console.WriteLine("Dodano nowy obiekt do kolekcji ObservableCollection");
        //        foreach (Event e in item.NewItems)
        //        {
        //            Console.WriteLine(item);
        //        }
        //    }
        //    else
        //    {
        //        if (item.Action == NotifyCollectionChangedAction.Remove)
        //        {
        //            Console.WriteLine("Usunieto obiekt z kolekcji ObservableCollection");
        //            foreach (Event e in item.NewItems)
        //            {
        //                Console.WriteLine(item);
        //            }
        //        }
        //    }
        //} // end item_CollectionCHanged
    }
}
