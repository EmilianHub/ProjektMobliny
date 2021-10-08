using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektMobliny.Models
{
    public class Stacje
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }

        public override string ToString()
        {
            return this.Nazwa;
        }
    }
}
