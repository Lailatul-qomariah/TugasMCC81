using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasMcc
{
    public class Mobil : Kendaraan
    {
        string typeKendaraan;
        public string NoPlat { get; set; }

        public Mobil(string typeKendaraan, string noPlat)
        {
            this.typeKendaraan = typeKendaraan;
            NoPlat = noPlat;
        }
        public void JenisKendaraan()
        {

            Console.WriteLine("Kendaraan ini adalah jenis BMW, mesin matic");
        
        }

        public int Tarif(int tarif)
        {
            string nameTarif = "harian";
            //tarif = 400000;
            Console.WriteLine($"Tarifnya berupa : {nameTarif}, {tarif}");
            return tarif;
            
        }

        
    }
}
