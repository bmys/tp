using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization; // references 

/// <summary>
/// Class vehicle represents vehicle in the rental
/// </summary>
namespace ClassLibrary
{
    [DataContract]
    [Serializable]
    public class Vehicle
    {
        private string registration;
        private string vehicleBrand;
        private string vehicleModel;

        [DataMember()]
        public string Registration { get => registration; set => registration = value; }
        [DataMember()]
        public string VehicleBrand { get => vehicleBrand; set => vehicleBrand = value; }
        [DataMember()]
        public string VehicleModel { get => vehicleModel; set => vehicleModel = value; }

        public override bool Equals(object obj)
        {
            var vehicle = obj as Vehicle;
            return vehicle != null &&
                   registration == vehicle.registration &&
                   vehicleBrand == vehicle.vehicleBrand &&
                   vehicleModel == vehicle.vehicleModel;
        }

        public override int GetHashCode()
        {
            var hashCode = 933605804;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(registration);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(vehicleBrand);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(vehicleModel);
            return hashCode;
        }

        public override string ToString()
        {
            return "Vehicle board: " + this.VehicleBrand + "Vehicle model: " + this.VehicleModel + 
                   " Registration: " + this.Registration + "Rental price: " + "\n";
        }
    }
}
