using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParserSorter.SortHelpers
{
    public class GenderSortAscendingHelper : IComparer<Person>
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

        #region Unit Tests
        [Fact]
        public void GenderSortAscendingHelper_Compare_SameGender_ReturnsZero()
        {
            //arrange:
            Person actual = new Person() { Gender = Globals.Gender.Female };
            Person expected = new Person() { Gender = Globals.Gender.Female };
            Assert.True(actual.Gender.CompareTo(expected.Gender) == 0);
        }

        [Fact]
        public void GenderSortAscendingHelper_Compare_FemaleFirst_ReturnsNegativeOne()
        {
            //arrange:
            Person actual = new Person() { Gender = Globals.Gender.Female };
            Person expected = new Person() { Gender = Globals.Gender.Male };
            Assert.True(actual.Gender.CompareTo(expected.Gender) == -1);
        }

        [Fact]
        public void GenderSortAscendingHelper_Compare_MaleFirst_ReturnsOne()
        {
            //arrange:
            Person actual = new Person() { Gender = Globals.Gender.Male };
            Person expected = new Person() { Gender = Globals.Gender.Female };
            Assert.True(actual.Gender.CompareTo(expected.Gender) == 1);
        }
        #endregion
    }
}
