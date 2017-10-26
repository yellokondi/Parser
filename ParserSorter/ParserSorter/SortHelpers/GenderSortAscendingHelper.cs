using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserSorter.SortHelpers
{
    class GenderSortAscendingHelper : IComparer<Person>
    {
        Int32 IComparer<Person>.Compare(Person x, Person y)
        {
            Int32 genderDiff = x.Gender.CompareTo(y.Gender);
            if (genderDiff != 0)
            {
                return genderDiff;
            }
            else
            {
                return x.LastName.CompareTo(y.LastName);
            }
        }
    }
}
