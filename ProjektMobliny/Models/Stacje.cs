using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektMobliny.Models
{
    public class Stacje
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Wybranastacja { get; set; }
        public double Cena95 { get; set; }
        public double Cena98 { get; set; }
        public double CenaON { get; set; }
        public double CenaLPG { get; set; }
        public string adres { get; set; }
       
      
        


        public override string ToString()
        {
            return Nazwa;
        }
    }
}
