using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserSorter.Factory
{
    public interface IFileFactory
    {
        List<Person> Parse();
    }
}
