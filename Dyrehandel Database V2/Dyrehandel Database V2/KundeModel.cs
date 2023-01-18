using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyrehandel_Database_V2
{
    public class KundeModel
    {
        public int KundeID { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public int Postnummer { get; set; }
        public string By { get; set; }
    }
}
