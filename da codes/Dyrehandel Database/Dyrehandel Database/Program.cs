using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2FirstDBSetup
{
    public class Program
    {
        public static List<PersonModel> peopleList = new List<PersonModel>();
        static void Main(string[] args)
        {
            bool isProgramExiting = false;
            while (isProgramExiting == false) 
            {
                Console.WriteLine("Welcome, choose option 1 or 2");
                string userInput = Console.ReadLine();
                int choice = int.Parse(userInput);

                if (choice == 1)
                {
                    peopleList = SQLiteDataAccess.LoadPeople();

                    for (int i = 0; i < peopleList.Count; i++)
                    {
                        Console.WriteLine(peopleList[i].name);
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter name: ");
                    string userName = Console.ReadLine();

                    Console.WriteLine("Enter Age: ");
                    string userInput3 = Console.ReadLine();
                    int userAge = int.Parse(userInput3);

                    PersonModel pm = new PersonModel();

                    pm.name = userName;
                    pm.age = userAge;

                    SQLiteDataAccess.AddPerson(pm);
                }
                else if (choice == 3)
                {
                    var result = from element in peopleList
                                 where element.age > 20
                                 select element;
                    List<PersonModel> resultList = result.ToList();
                    for (int i = 0; i < resultList.Count; i++)
                    {
                        Console.WriteLine(resultList[i].name + ", " + resultList[i].age);
                    }
                }
                else if (choice == 4) 
                {
                    List<PersonModel> result = peopleList.OrderByDescending(x => x.name).ToList();

                    for (int i = 0; i < result.Count; i++)
                    {
                        Console.WriteLine(result[i].name + ", " + result[i].age);
                    }
                }
                else 
                {
                    Console.WriteLine("Close Program");
                    isProgramExiting = true;
                }

                Console.ReadKey();
            }            
        }
    }
}
