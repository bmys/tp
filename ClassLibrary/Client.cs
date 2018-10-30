using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Class client represents people who rent vehicle
/// </summary>
namespace ClassLibrary
{
    public class Client
    {
        private string pesel;
        private string firstName;
        private string lastName;
        private int age;

        public string Pesel { get => pesel; set => pesel = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Age { get => age; set => age = value; }

        public override bool Equals(object obj)
        {
            var client = obj as Client;
            return client != null &&
                   pesel == client.pesel &&
                   firstName == client.firstName &&
                   lastName == client.lastName &&
                   age == client.age;
        }

        public override int GetHashCode()
        {
            var hashCode = -1795900458;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(pesel);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(firstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(lastName);
            hashCode = hashCode * -1521134295 + age.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "First Name: " + this.FirstName + " Last Name: " + this.LastName + " Pesel: " + this.Pesel + " Age: " + this.Age;
        }

    }
}
