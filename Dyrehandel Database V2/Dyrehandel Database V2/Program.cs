using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyrehandel_Database_V2
{
    internal class Program
    {
        public static List<KundeModel> Kunde;

        static void Main(string[] args)
        {
            //setup til switchboard
            bool isProgramExiting = false, isInputCorrect = false;

            //skaber liste af kunder
            //List<KundeModel> Kunde = new List<KundeModel>();
            Kunde = SqliteDataAccess.LoadKunde();

            Console.WriteLine("Hej med dig det her er en butik med dyr, ikke en dyr butik heheheheheh");
            Console.WriteLine("Delen med at tilføje og fjerne folk fra listen med consol appen er ikek færdig endnu, og den data der accepteres skal ændres fra default til det vi kan bruge");
            Console.WriteLine("");

            //Switchboard pt. 1
            while (!isProgramExiting)
            {
                Console.Clear();
                Console.WriteLine("Du har følgende muligheder: ");
                Console.WriteLine("Tryk 1 for at tilføje en bruger: ");
                Console.WriteLine("Tryk 2 for at vise brugere: ");
                Console.WriteLine("Tryk 0 for at lukke programmet: ");

                //error Correction for switcboard
                int numberInput = -1;
                isInputCorrect = false;
                while (!isInputCorrect)
                {
                    string userInput = Console.ReadLine();

                    try
                    {
                        numberInput = int.Parse(userInput);
                        if (numberInput >= 0 && numberInput <= 2)
                        {
                            isInputCorrect = true;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Indtast venligst et tal for det valg du vil tage");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Indtast venligst et tal mellem 0 og 2");
                    }
                }

                //Switchboard pt. 2
                switch (numberInput)
                {
                    case 0:
                        Console.WriteLine("Programmet lukker nu.");
                        isProgramExiting = true;
                        Console.ReadKey();
                        break;
                    case 1:
                        tilføjBruger();
                        break;
                    case 2:
                        visBrugere();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void tilføjBruger()
        {
            KundeModel p = new KundeModel();

            p.Navn = "Jens";
            p.Adresse = "Jørgenvej";
            p.Postnummer = 9;
            p.By = "Thyborøn";

            SqliteDataAccess.SaveKunde(p);
        }

        private static void visBrugere()
        {
            Console.Clear();
            //printer dem
            for (int i = 0; i < Kunde.Count; i++)
            {
                Console.WriteLine(Kunde[i].Navn + " som bor på " + Kunde[i].Adresse + " i " + Kunde[i].By + " med postnummeret " + Kunde[i].Postnummer);
            }
            Console.WriteLine("");
            Console.WriteLine("Tryk 0 for at gå tilbage");
            Console.ReadKey();
        }
    }
}
