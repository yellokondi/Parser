using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParserSorter.SortHelpers
{
    public class LastNameSortDescendingHelper : IComparer<Person>
    {
        Int32 IComparer<Person>.Compare(Person x, Person y)
        {
            return String.Compare(y.LastName, x.LastName);
        }

        #region Unit Tests
        [Fact]
        public void LastNameSortDescendingHelper_Compare_SameLastName_ReturnsZero()
        {
            //arrange:
            Person actual = new Person() { LastName = "Smith" };
            Person expected = new Person() { LastName = "Smith" };
            Assert.True(actual.LastName.CompareTo(expected.LastName) == 0);
        }

        [Fact]
        public void LastNameSortDescendingHelper_Compare_EarlierLastNameFirst_ReturnsNegativeOne()
        {
            //arrange:
            Person actual = new Person() { LastName = "Smith" };
            Person expected = new Person() { LastName = "Smithe" };
            Assert.True(actual.LastName.CompareTo(expected.LastName) == -1);
        }

        [Fact]
        public void LastNameSortDescendingHelper_Compare_LaterLastNameFirst_ReturnsOne()
        {
            //arrange:
            Person actual = new Person() { LastName = "Smithe" };
            Person expected = new Person() { LastName = "Smith" };
            Assert.True(actual.LastName.CompareTo(expected.LastName) == 1);
        }
        #endregion
    }
}
