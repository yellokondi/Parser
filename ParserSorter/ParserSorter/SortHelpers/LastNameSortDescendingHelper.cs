using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserSorter.SortHelpers
{
    class LastNameSortDescendingHelper : IComparer
    {
        Int32 IComparer.Compare(Object x, Object y)
        {
            Person p1 = (Person)x;
            Person p2 = (Person)y;

            return String.Compare(p2.LastName, p1.LastName);            
        }
    }
}
