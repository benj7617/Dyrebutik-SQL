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

        //dem der er til kunderne
        //TIlføj alt data fra Kunder til en liste
        public static List<PersonModel> LoadKunde()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<PersonModel>("select * from Kunder", new DynamicParameters());
                return output.ToList();
            }
        }

        //Skab en ny person, og gem den til databasen - Ikke done
        public static void SavePerson(PersonModel person)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into person (Firstname, Lastname) values (@Firstname, @Lastname)", person);
            }
        }

        //dem der er til butikkerne
        //Tilføj alt fra butikken til en liste
        public static List<PersonModel> LoadButik()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<PersonModel>("select * from Butik", new DynamicParameters());
                return output.ToList();
            }
        }

        //ikke done
        public static void SavePerson(PersonModel person)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into person (Firstname, Lastname) values (@Firstname, @Lastname)", person);
            }
        }

        //dem der er til Produkterne
        //tilføj alt info om produktet til liste
        public static List<PersonModel> LoadPeople()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<PersonModel>("select * from person", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SavePerson(PersonModel person)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into person (Firstname, Lastname) values (@Firstname, @Lastname)", person);
            }
        }


    }
}
