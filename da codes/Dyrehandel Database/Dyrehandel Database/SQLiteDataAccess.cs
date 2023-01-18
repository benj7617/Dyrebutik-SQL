using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2FirstDBSetup
{
    public class SQLiteDataAccess
    {
        public static List<PersonModel> LoadPeople()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                List<PersonModel> output = cnn.Query<PersonModel>("SELECT * FROM Person", new DynamicParameters()).ToList();
                return output;
            }
        }

        public static void AddPerson(PersonModel pm)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO Person (Name, Age) VALUES (@name, @age)", pm);
            }
        }

        public static string LoadConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }
    }
}
