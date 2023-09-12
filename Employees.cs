using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TugasMcc
{
    public class Employees : Person
    {
        string noHp;
        public string Umur { get; set; }
        public Employees(string name, string address, string noHp, string umur) : base(name, address)  //untuk di new objectnya
        {
            this.noHp = noHp;
            Umur = umur;
        }

        public override void Disply()
        {
            base.Disply();
            Console.WriteLine("No Hp: {0}", noHp); //{0}, $ penggantinya +
            Console.WriteLine($"umur  : {Umur}");

        }
    
    
    
    
    }



}
