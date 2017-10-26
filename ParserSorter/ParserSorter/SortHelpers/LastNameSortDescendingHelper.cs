using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserSorter.SortHelpers
{
    public class LastNameSortDescendingHelper : IComparer<Person>
    {
        Int32 IComparer<Person>.Compare(Person x, Person y)
        {
            return String.Compare(y.LastName, x.LastName);
        }
    }
}
