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
        public static List<ButikModel> Butik;
        public static List<ProduktModel> Produkt;

        static void Main(string[] args)
        {
            //setup til switchboard
            bool isProgramExiting = false, isInputCorrect = false;

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

                Console.WriteLine("Tryk 3 for at tilføje en butik: ");
                Console.WriteLine("Tryk 4 for at vise butikker: ");

                Console.WriteLine("Tryk 5 for at tilføje en vare: ");
                Console.WriteLine("Tryk 6 for at vise varer: ");
                Console.WriteLine("Tryk 7 for at fjerne et produkt");

                Console.WriteLine("Tryk 0 for at lukke programmet: ");

                //error Correction for switcboard
                int numberInput = -1;
                isInputCorrect = false;
                while (!isInputCorrect)
                {
                    //Loader databaserne
                    Kunde = SqliteDataAccess.LoadKunde();
                    Butik = SqliteDataAccess.LoadButik();
                    Produkt = SqliteDataAccess.LoadProdukt();

                    string userInput = Console.ReadLine();

                    try
                    {
                        numberInput = int.Parse(userInput);
                        if (numberInput >= 0 && numberInput <= 7)
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
                        Console.WriteLine("Indtast venligst et tal mellem 0 og 7");
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
                    case 3:
                        tilføjButik();
                        break;
                    case 4:
                        visButikker();
                        break;
                    case 5:
                        tilføjProdukt();
                        break;
                    case 6:
                        visProdukter();
                        break;
                    case 7:
                        fjernProdukter();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void tilføjBruger()
        {
            KundeModel p = new KundeModel();

            Console.WriteLine("Der er ikke noget error correction her endnu");
            try
            {
                Console.WriteLine("Skriv navn");
                p.Navn = Console.ReadLine();
                Console.WriteLine("Skriv Adresse");
                p.Adresse = Console.ReadLine();
                Console.WriteLine("Skriv Postnummer");
                p.Postnummer = int.Parse(Console.ReadLine());
                Console.WriteLine("Skriv By");
                p.By = Console.ReadLine();

                SqliteDataAccess.SaveKunde(p);
            }
            catch (Exception)
            {
                Console.WriteLine("Eow din adam du gjorde noget forkert. Error 1");
                throw;
            }

            
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

        private static void tilføjButik()
        {
            ButikModel p = new ButikModel();

            try
            {
                Console.WriteLine("Skriv Adresse");
                p.Adresse = Console.ReadLine();
                Console.WriteLine("Skriv Postnummer");
                p.Postnummer = int.Parse(Console.ReadLine());
                Console.WriteLine("Skriv By");
                p.By = Console.ReadLine();

                SqliteDataAccess.SaveButik(p);
            }
            catch (Exception)
            {
                Console.WriteLine("Eow din adam du gjorde noget forkert. Error 2");
                throw;
            }
        }

        private static void visButikker()
        {
            Console.Clear();
            //printer dem
            for (int i = 0; i < Butik.Count; i++)
            {
                Console.WriteLine("Butik nr. " + Butik[i].ButikID + " som ligger i " + Butik[i].Adresse + " " + Butik[i].Postnummer + " " + Butik[i].By );
            }
            Console.WriteLine("");
            Console.WriteLine("Tryk 0 for at gå tilbage");
            Console.ReadKey();
        }

        private static void tilføjProdukt()
        {
            ProduktModel p = new ProduktModel();

            try
            {
                Console.WriteLine("Skriv Antal");
                p.Antal = int.Parse(Console.ReadLine());
                Console.WriteLine("Skriv Kategori");
                p.Kategori = Console.ReadLine();
                Console.WriteLine("Skriv Pris");
                p.Pris = int.Parse(Console.ReadLine());

                SqliteDataAccess.SaveProdukt(p);
            }
            catch (Exception)
            {
                Console.WriteLine("Eow din adam du gjorde noget forkert. Error 3");
                throw;
            }
        }

        private static void visProdukter()
        {
            Console.Clear();
            //printer dem
            for (int i = 0; i < Produkt.Count; i++)
            {
                Console.WriteLine("Produkt ID: " + Produkt[i].ProduktID + " Antal: " + Produkt[i].Antal + " I kategorien " + Produkt[i].Kategori + " " );
            }
            Console.WriteLine("");
            Console.WriteLine("Tryk 0 for at gå tilbage");
            Console.ReadKey();
        }
        private static void fjernProdukter()
        {
            
            Console.WriteLine("Vælg produkt id som skal fjernes");
            Console.WriteLine("");
            for (int i = 0; i < Produkt.Count; i++)
            {
                Console.WriteLine("Produkt ID: " + Produkt[i].ProduktID);
            }
            fjernProdukter();
            Console.ReadKey();
        }
    }
}
