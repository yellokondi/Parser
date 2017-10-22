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

            }
            catch(Exception ex)
            {

            }
        }
    }
}
