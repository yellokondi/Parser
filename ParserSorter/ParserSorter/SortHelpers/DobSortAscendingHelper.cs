using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserSorter.SortHelpers
{
    public class DobSortAscendingHelper : IComparer<Person>
    {
        Int32 IComparer<Person>.Compare(Person x, Person y)
        {
            if (x.DateOfBirth < y.DateOfBirth)
            {
                return -1;
            }
            if (y.DateOfBirth < x.DateOfBirth)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
