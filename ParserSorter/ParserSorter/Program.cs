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
                    Console.WriteLine(String.Format("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}", person.LastName, person.FirstName, person.Gender, person.FavoriteColor, person.DateOfBirth));
                }
            }
            catch(Exception ex)
            {

            }
            Console.ReadKey();
        }
    }
}
