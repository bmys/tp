using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Class vehicle represents vehicle in the rental
/// </summary>
namespace ClassLibrary
{
    class Vehicle
    {
        private string registration;
        private string vehicleBrand;
        private string vehicleModel;
        private int rentalPrice;

        public string Registration { get => registration; set => registration = value; }
        public string VehicleBrand { get => vehicleBrand; set => vehicleBrand = value; }
        public string VehicleModel { get => vehicleModel; set => vehicleModel = value; }
        public int RentalPrice { get => rentalPrice; set => rentalPrice = value; }

        public override bool Equals(object obj)
        {
            var vehicle = obj as Vehicle;
            return vehicle != null &&
                   registration == vehicle.registration &&
                   vehicleBrand == vehicle.vehicleBrand &&
                   vehicleModel == vehicle.vehicleModel &&
                   rentalPrice == vehicle.rentalPrice;
        }

        public override int GetHashCode()
        {
            var hashCode = 1381312012;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(registration);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(vehicleBrand);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(vehicleModel);
            hashCode = hashCode * -1521134295 + rentalPrice.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Vehicle board: " + this.VehicleBrand + "Vehicle model: " + this.VehicleModel + 
                   " Registration: " + this.Registration + "Rental price: " + this.RentalPrice;
        }
    }
}
