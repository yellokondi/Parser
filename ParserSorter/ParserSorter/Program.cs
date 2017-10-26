using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace ParserSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Factory.FileFactory fileFactory = new Factory.ConcreteFileFactory();
                String fileLocation = ConfigurationManager.AppSettings["DefaultFileLocation"].ToString();

                List<Person> peopleRecords = new List<Person>();
                String[] files = Directory.GetFiles(fileLocation, "*.txt");
                foreach(String file in files)
                {
                    Factory.IFileFactory delimitedFile = fileFactory.GetFile(file);
                    peopleRecords.AddRange(delimitedFile.Parse());
                }

                //Write out a header for Output 1:
                Console.WriteLine("Output 1 – sorted by gender (females before males) then by last name ascending");
                peopleRecords.Sort(new SortHelpers.GenderSortAscendingHelper());
                foreach(Person person in peopleRecords)
                {
                    Console.WriteLine(String.Format("{0} {1} {2} {3} {4}", person.Gender, person.LastName, person.FirstName, person.FavoriteColor, person.DateOfBirth.Value.ToString("d")));
                }

                Console.WriteLine();
                Console.WriteLine("Output 2 - sorted by birth date, ascending");
                peopleRecords.Sort(new SortHelpers.DobSortAscendingHelper());
                foreach (Person person in peopleRecords)
                {
                    Console.WriteLine(String.Format("{0} {1} {2} {3} {4}", person.DateOfBirth.Value.ToString("d"), person.LastName, person.FirstName, person.FavoriteColor, person.Gender));
                }

                Console.WriteLine();
                Console.WriteLine("Output 3 - sorted by last name, descending");
                peopleRecords.Sort(new SortHelpers.LastNameSortDescendingHelper());
                foreach (Person person in peopleRecords)
                {
                    Console.WriteLine(String.Format("{0} {1} {2} {3} {4}", person.LastName, person.FirstName, person.FavoriteColor, person.Gender, person.DateOfBirth.Value.ToString("d")));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            Console.Read();
        }
    }
}
