using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserSorter
{
    public class Person : IComparable
    {
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public Globals.Gender Gender { get; set; }
        public String FavoriteColor { get; set; }
        public String DateOfBirth { get; set; }

        #region Default Sort and Sort Helper Methods
        Int32 IComparable.CompareTo(Object obj)
        {
            Person p = (Person)obj;
            return String.Compare(LastName, p.LastName);
        }

        public IComparer SortByGenderAscending()
        {
            return new SortHelpers.GenderSortAscendingHelper();
        }

        public IComparer SortByDateOfBirthAscending()
        {
            return new SortHelpers.DobSortAscendingHelper();
        }

        public IComparer SortByLastNameDescending()
        {
            return new SortHelpers.LastNameSortDescendingHelper();
        }
        #endregion

    }
}
