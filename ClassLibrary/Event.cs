using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Event describes the relations binding persons and occurrences referring to dictionary positions
/// </summary>
namespace ClassLibrary
{
    public class Event
    {
        private Client client;
        private VehicleState vehicleState;
        private DateTimeOffset rentalOfDate;
        private DateTimeOffset returnOfDate;

        public Client Client { get => client; set => client = value; }
        public DateTimeOffset RentalOfDate { get => rentalOfDate; set => rentalOfDate = value; }
        public DateTimeOffset ReturnOfDate { get => returnOfDate; set => returnOfDate = value; }
        internal VehicleState VehicleState { get => vehicleState; set => vehicleState = value; }

        public override bool Equals(object obj)
        {
            var @event = obj as Event;
            return @event != null &&
                   EqualityComparer<Client>.Default.Equals(client, @event.client) &&
                   EqualityComparer<VehicleState>.Default.Equals(vehicleState, @event.vehicleState) &&
                   rentalOfDate.Equals(@event.rentalOfDate) &&
                   returnOfDate.Equals(@event.returnOfDate);
        }

        public override int GetHashCode()
        {
            var hashCode = -1468429342;
            hashCode = hashCode * -1521134295 + EqualityComparer<Client>.Default.GetHashCode(client);
            hashCode = hashCode * -1521134295 + EqualityComparer<VehicleState>.Default.GetHashCode(vehicleState);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset>.Default.GetHashCode(rentalOfDate);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset>.Default.GetHashCode(returnOfDate);
            return hashCode;
        }

        public override string ToString()
        {
            return this.Client + "\n" + this.VehicleState + " Rental of date: " + this.RentalOfDate + 
                   " Return of date: " + this.ReturnOfDate + "\n"; 
        }
    }
}
