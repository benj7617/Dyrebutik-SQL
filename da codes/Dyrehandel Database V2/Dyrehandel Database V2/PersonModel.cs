using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyrehandel_Database_V2
{
    public class PersonModel
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public int Lastname { get; set; }

        public string Fullname
        {
            get
            {
                return $"{ Firstname } { Lastname }";
            }
        }
    }
}
