using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization; // references 


/// <summary>
/// Class client represents people who rent vehicle
/// </summary>
namespace ClassLibrary
{
    [DataContract]
    [Serializable]
    public class Client
    {
        
        private string pesel;
        private string firstName;
        private string lastName;
        private int age;
     
        [DataMember()]
        public string Pesel { get => pesel; set => pesel = value; }
        [DataMember()]
        public string FirstName { get => firstName; set => firstName = value; }
        [DataMember()]
        public string LastName { get => lastName; set => lastName = value; }
        [DataMember()]
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
            return "First Name: " + this.FirstName + " Last Name: " + this.LastName + " Pesel: " + this.Pesel + " Age: " + this.Age + "\n";
        }

    }
}
