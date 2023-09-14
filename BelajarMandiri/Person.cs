using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasMcc
{
    public class Person
    {
        string name;
        string address;
        
        public Person() { 
        
        }

        public Person(string name, string address)
        {
            this.name = name;
            this.address = address;
        }

        public virtual void Disply() // ini override sama method Disply di class Employees
        {
            Console.WriteLine("halo ini saya");
            Console.WriteLine("Nama saya : {0}", name);
            Console.WriteLine("alamat  : " + address);
        }

    }
}
