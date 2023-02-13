using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyrehandel_Database_V2
{
    public class ProduktModel
    {
        public int ProduktID { get; set; }
        public int Antal { get; set; }
        public string Kategori { get; set; }
        public int Pris { get; set; }
        public string ProduktNavn { get; set; }
    }
}
