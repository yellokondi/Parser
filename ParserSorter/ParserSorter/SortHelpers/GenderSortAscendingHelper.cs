using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserSorter.SortHelpers
{
    class GenderSortAscendingHelper : IComparer<Person>, IComparer
    {
        int IComparer.Compare(Object x, Object y)
        {
            Person p1 = (Person)x;
            Person p2 = (Person)y;

            if (p1.Gender > p2.Gender)
            {
                return 1;
            }

            if (p1.Gender < p2.Gender)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        int IComparer<Person>.Compare(Person x, Person y)
        {
            if (x.Gender > y.Gender)
            {
                return 1;
            }

            if (x.Gender < y.Gender)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
