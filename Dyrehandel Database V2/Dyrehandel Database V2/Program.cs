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
            Console.WriteLine("Hej med dig det her er en butik med dyr, ikke en dyr butik hehehehehe");
            Console.WriteLine("Delen med at tilføje og fjerne folk fra listen med consol appen er ikke færdig endnu, og den data der accepteres skal ændres fra default til det vi kan bruge");
            Console.WriteLine("");

            //setup til switchboard
            bool isProgramExiting = false, isInputCorrect = false;
            int numberInput = -1;
            //Switchboard pt. 1
            while (!isProgramExiting)
            {
                Console.Clear();
                Console.WriteLine("Du har følgende muligheder: ");
                Console.WriteLine("");
                Console.WriteLine("1 - vis brugere: ");
                Console.WriteLine("2 - vis butikker: ");
                Console.WriteLine("3 - vis hvilke vare en hvis butik har");
                Console.WriteLine("4 - vis produkter: ");
                Console.WriteLine("5 - sorter efter intast pris");
                Console.WriteLine("6 - se pris for katte og hunde");
                Console.WriteLine("420 - admin panel");
                Console.WriteLine("");
                Console.WriteLine("0 - luk programmet: ");
                

                //error Correction for switcboard                
                isInputCorrect = false;

                //Switchboard pt. 2
                switch (switchboardStuff(isProgramExiting, isInputCorrect, numberInput, 6))
                {
                    case 0:
                        Console.WriteLine("Programmet lukker nu.");
                        isProgramExiting = true;
                        Console.ReadKey();
                        break;
                    case 1: //virker
                        visBrugere();
                        break;
                    case 2: //virker
                        visButikker();
                        break;
                    case 3: //BROKEN
                        visBestemButik();
                        break;
                    case 4: //virker
                        visProdukter();
                        break;
                    case 5: //BORKEN
                        sorterProdukter();
                        break;
                    case 6: //BROKEN
                        hundKat();
                        break;
                    case 420: //, virker Admin panel
                        Console.Clear();

                        isInputCorrect= false; //til error correction i det nye switchboard

                        Console.WriteLine("Velkommen til Admin panelet");
                        Console.WriteLine("");
                        Console.WriteLine("1 - tilføj en bruger: ");
                        Console.WriteLine("2 - tilføj en butik: ");
                        Console.WriteLine("3 - tilføj et produkt: ");

                        Console.WriteLine("4 - fjern en kunde");
                        Console.WriteLine("5 - fjern en butik");
                        Console.WriteLine("6 - fjern et produkt");

                        Console.WriteLine("");
                        Console.WriteLine("0 - tilbage: ");

                        switch (switchboardStuff(isProgramExiting, isInputCorrect, numberInput, 6))
                        {
                            case 1:
                                tilføjBruger();
                                break;
                            case 2:
                                tilføjButik();
                                break;
                            case 3:
                                tilføjProdukt();
                                break;
                            case 4:
                                fjernKunde();
                                break;
                            case 5:
                                fjernButik();
                                break;
                            case 6:
                                fjernProdukter();
                                break;
                            case 0:
                                break;
                            case 420:
                                Console.WriteLine("Du er her squda allerede");
                                break;
                        } ///Admin Panel
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
                Console.WriteLine("Skriv Produktnavn");
                p.ProduktNavn = Console.ReadLine();

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
                Console.WriteLine("Produkt ID: " + Produkt[i].ProduktID + " Produktnavn: " + Produkt[i].ProduktNavn + " Antal: " + Produkt[i].Antal + " I kategorien " + Produkt[i].Kategori + " " );
            }
            Console.WriteLine("");
            Console.WriteLine("Tryk 0 for at gå tilbage");
            Console.ReadKey();
        }

        private static void fjernProdukter()
        {
            Console.Clear();

            //Viser alle eksisterende produkter
            for (int i = 0; i < Produkt.Count; i++)
            {
                Console.WriteLine("Produkt ID: " + Produkt[i].ProduktID + " Produktnavn: " + Produkt[i].ProduktNavn + " Antal: " + Produkt[i].Antal + " I kategorien " + Produkt[i].Kategori + " ");
            }
            Console.WriteLine("");

            //skaber en produktmodel for at fortælle databasen hvilken en der skal slettes
            ProduktModel p = new ProduktModel();
            try
            {
                Console.WriteLine("Skriv ProduktID");
                p.ProduktID = int.Parse(Console.ReadLine());

                SqliteDataAccess.fjernProdukt(p);
                Console.WriteLine("Done");
            }
            catch (Exception)
            {
                Console.WriteLine("Eow din adam du gjorde noget forkert. Error SletProdukt");
                throw;
            }

            Console.ReadKey();
        }

        private static void fjernKunde()
        {
            Console.Clear();

            //Viser alle eksisterende kunder
            for (int i = 0; i < Kunde.Count; i++)
            {
                Console.WriteLine(Kunde[i].KundeID + " " + Kunde[i].Navn + " som bor på " + Kunde[i].Adresse + " i " + Kunde[i].By + " med postnummeret " + Kunde[i].Postnummer);
            }
            Console.WriteLine("");

            //skaber en kundemodel for at fortælle databasen hvilken en der skal slettes
            KundeModel p = new KundeModel();
            try
            {
                Console.WriteLine("Skriv KundeID");
                p.KundeID = int.Parse(Console.ReadLine());

                SqliteDataAccess.fjernKunde(p);
                Console.WriteLine("Done");
            }
            catch (Exception)
            {
                Console.WriteLine("Eow din adam du gjorde noget forkert. Error SletKunde");
                throw;
            }

            Console.ReadKey();
        }

        private static void fjernButik()
        {
            Console.Clear();

            //Viser alle eksisterende kunder
            for (int i = 0; i < Butik.Count; i++)
            {
                Console.WriteLine("Butik nr. " + Butik[i].ButikID + " som ligger i " + Butik[i].Adresse + " " + Butik[i].Postnummer + " " + Butik[i].By);
            }
            Console.WriteLine("");

            //skaber en kundemodel for at fortælle databasen hvilken en der skal slettes
            ButikModel p = new ButikModel();
            try
            {
                Console.WriteLine("Skriv ButikID");
                p.ButikID = int.Parse(Console.ReadLine());

                SqliteDataAccess.fjernButik(p);
                Console.WriteLine("Done");
            }
            catch (Exception)
            {
                Console.WriteLine("Eow din adam du gjorde noget forkert. Error SletButik");
                throw;
            }

            Console.ReadKey();
        }


        private static void visBestemButik()
        {

        }
        private static void sorterProdukter()
        {

        }
        private static void hundKat()
        {

        }
        private static int switchboardStuff(bool isProgramExiting, bool isInputCorrect, int numberInput, int a)
        {
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
                    if (numberInput >= 0 && numberInput <= a | numberInput == 420)
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
                    Console.WriteLine("Indtast venligst et tal mellem 0 og 11");
                }
            }
            return numberInput;
        }
    }
}
