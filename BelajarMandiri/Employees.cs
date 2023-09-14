using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TugasMcc
{
    public class Employees <T> : Person // class generic, di constructor nya variabelnya juga kudu generic ges
    {
        public T Id { get; set; }
        string noHp;
        public string Umur { get; set; }
        string hobby;
        public Employees(T id, string name, string address, string noHp, string umur, string hobby) : base(name, address)  //untuk di new objectnya
        {
            this.noHp = noHp;
            Umur = umur;
            Id = id;
            this.hobby = hobby;
        }

        public override void Disply()
        {
            Console.WriteLine($"Id  : {Id}");
            base.Disply();
            Console.WriteLine("No Hp: {0}", noHp); //{0}, $ penggantinya +
            Console.WriteLine($"umur  : {Umur}");

        }
    
    
    
    
    }



}
