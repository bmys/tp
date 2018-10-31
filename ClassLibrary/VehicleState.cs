using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization; // references 

/// <summary>
/// Class VehicleState description the condition of the vehicle
/// </summary>
namespace ClassLibrary
{
    [DataContract()]
    [Serializable]
    public class VehicleState
    {
        private Vehicle vehicle;
        private int rentalPrice;
        private bool avaiable;

        [DataMember()]
        public Vehicle Vehicle { get => vehicle; set => vehicle = value; }
        [DataMember()]
        public int RentalPrice { get => rentalPrice; set => rentalPrice = value; }
        [DataMember()]
        public bool Avaiable { get => avaiable; set => avaiable = value; }

        public override bool Equals(object obj)
        {
            var state = obj as VehicleState;
            return state != null &&
                   EqualityComparer<Vehicle>.Default.Equals(vehicle, state.vehicle) &&
                   rentalPrice == state.rentalPrice &&
                   avaiable == state.avaiable;
        }

        public override int GetHashCode()
        {
            var hashCode = -329274365;
            hashCode = hashCode * -1521134295 + EqualityComparer<Vehicle>.Default.GetHashCode(vehicle);
            hashCode = hashCode * -1521134295 + rentalPrice.GetHashCode();
            hashCode = hashCode * -1521134295 + avaiable.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            
            return this.Vehicle + " Rental price: " + this.RentalPrice + "\n";
        }
    }
}
