using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserSorter.SortHelpers
{
    class DobSortAscendingHelper : IComparer,IComparer<Person>
    {
        Int32 IComparer.Compare(Object x, Object y)
        {
            Person p1 = (Person)x;
            Person p2 = (Person)y;

            return String.Compare(p1.DateOfBirth, p2.DateOfBirth);
        }

        Int32 IComparer<Person>.Compare(Person x, Person y)
        {
            return String.Compare(x.DateOfBirth, y.DateOfBirth);
        }
    }
}
