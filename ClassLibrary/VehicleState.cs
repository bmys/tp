using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Class VehicleState description the condition of the vehicle
/// </summary>
namespace ClassLibrary
{
    public class VehicleState
    {
        private Vehicle vehicle;
        private DateTimeOffset rentalPrice;
        private bool avaiable;

        public DateTimeOffset RentalPrice { get => rentalPrice; set => rentalPrice = value; }
        public bool Avaiable { get => avaiable; set => avaiable = value; }
        internal Vehicle Vehicle { get => vehicle; set => vehicle = value; }

        public override bool Equals(object obj)
        {
            var state = obj as VehicleState;
            return state != null &&
                   EqualityComparer<Vehicle>.Default.Equals(vehicle, state.vehicle) &&
                   rentalPrice.Equals(state.rentalPrice) &&
                   avaiable == state.avaiable;
        }

        public override int GetHashCode()
        {
            var hashCode = -311043215;
            hashCode = hashCode * -1521134295 + EqualityComparer<Vehicle>.Default.GetHashCode(vehicle);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset>.Default.GetHashCode(rentalPrice);
            hashCode = hashCode * -1521134295 + avaiable.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return vehicle + "Rental price: " + this.RentalPrice + "\n";
        }
    }
}
