using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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

       [Fact]
       public void DobSortAscendingHelper_Compare_SameDate_ReturnsZero()
        {
            //arrange:
            Person actual = new Person() { DateOfBirth = new DateTime(2010, 1, 1) };
            Person expected = new Person() { DateOfBirth = new DateTime(2010, 1, 1) };
            Assert.True(actual.DateOfBirth.Value.CompareTo(expected.DateOfBirth.Value) == 0);
        }

        [Fact]
        public void DobSortAscendingHelper_Compare_EarlierDate_ReturnsNegativeOne()
        {
            //arrange:
            Person actual = new Person() { DateOfBirth = new DateTime(2009, 1, 1) };
            Person expected = new Person() { DateOfBirth = new DateTime(2010, 1, 1) };
            Assert.True(actual.DateOfBirth.Value.CompareTo(expected.DateOfBirth.Value) == -1);
        }

        [Fact]
        public void DobSortAscendingHelper_Compare_LaterDate_ReturnsOne()
        {
            //arrange:
            Person actual = new Person() { DateOfBirth = new DateTime(2010, 1, 2) };
            Person expected = new Person() { DateOfBirth = new DateTime(2010, 1, 1) };
            Assert.True(actual.DateOfBirth.Value.CompareTo(expected.DateOfBirth.Value) == 1);
        }
    }
}
