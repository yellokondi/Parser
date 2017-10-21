using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ParserSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory.FileFactory fileFactory = new Factory.ConcreteFileFactory();

            //TODO: Create an IdentifyFileType(String fileLocation) method to recognize which concrete object needs to be used
            
            Factory.IFileFactory pipeDelimitedFile = fileFactory.GetFile("pipe", ConfigurationManager.AppSettings["DefaultFileLocation"].ToString());
            List <Person> personLines = pipeDelimitedFile.Parse();

        }
    }
}
