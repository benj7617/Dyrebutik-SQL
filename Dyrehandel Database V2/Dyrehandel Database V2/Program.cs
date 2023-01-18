using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyrehandel_Database_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hej med dig det her er en butik med dyr, ikke en dyr butik heheheheheh");

            Console.WriteLine("Delen med at tilføje og fjerne folk fra listen med consol appen er ikek færdig endnu, og den data der accepteres skal ændres fra default til det vi kan bruge");

            KundeModel p = new KundeModel();

            p.Navn = "Jens";
            p.Adresse = "Jørgenvej";
            p.Postnummer = 9;
            p.By = "Thyborøn";

            SqliteDataAccess.SaveKunde(p);


            //skaber liste over butikker
            List<KundeModel> Kunde = new List<KundeModel>();
            Kunde = SqliteDataAccess.LoadKunde();
    
            //printer dem
            for (int i = 0; i < Kunde.Count; i++)
            {
                Console.WriteLine(Kunde[i].By);
            }

            Console.ReadKey();
        }
    }
}
