using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyrehandel_Database_V2
{
    public class SqliteDataAccess
    {
        //noget der fikser at databaserne virker - rør ikke
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }


        //Kunde
        public static List<KundeModel> LoadKunde() //Skab liste over kunder
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<KundeModel>("select * from Kunde", new DynamicParameters());
                return output.ToList();
            }
        }
       
        public static void SaveKunde(KundeModel Kunde) //Skab Kunde
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Kunde (Navn, Adresse, Postnummer, By) values (@Navn, @Adresse, @Postnummer, @By)", Kunde);
            }
        }


        //Butik
        public static List<ButikModel> LoadButik() //skab liste over butiker
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ButikModel>("select * from Butik", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveButik(ButikModel Butik) //skab butik
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Butik (Adresse, Postnummer, By) values (@Adresse, @Postnummer, @By)", Butik);
            }
        }


        //Produkt
        public static List<ProduktModel> LoadProdukt() //skab liste over produkter
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProduktModel>("select * from Produkt", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveProdukt(ProduktModel Produkt) // skab produkt
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Produkt (Antal, Kategori, Pris, ProduktNavn) values (@Antal, @Kategori, @Pris, @ProduktNavn)", Produkt);
            }
        }

        public static void fjernProdukt(ProduktModel Produkt) //fjern et eksisterende produkt
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("delete from Produkt where ProduktID=@ProduktID", Produkt);
            }
        }

        public static void fjernKunde(KundeModel Kunde) //fjern et eksisterende produkt
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("delete from Kunde where KundeID=@KundeID", Kunde);
            }
        }

        public static void fjernButik(ButikModel Butik) //fjern et eksisterende produkt
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("delete from Butik where ButikID=@ButikID", Butik);
            }
        }
    }
}
