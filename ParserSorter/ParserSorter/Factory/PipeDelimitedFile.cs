using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ParserSorter.Factory
{
    public class PipeDelimitedFile : IFileFactory
    {
        public PipeDelimitedFile() { }
        public PipeDelimitedFile(String fileLocation) => FileLocation = fileLocation;

        public String FileLocation { get; set; }

        List<Person> IFileFactory.Parse()
        {
            Globals globals = new Globals();
            return globals.ParseBy('|', FileLocation);
        }
    }
}
