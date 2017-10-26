using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserSorter
{
    public class Person : IComparable<Person>
    {
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public Globals.Gender Gender { get; set; }
        public String FavoriteColor { get; set; }
        public DateTime? DateOfBirth { get; set; }

        #region Default Sort
        Int32 IComparable<Person>.CompareTo(Person other)
        {
            return LastName.CompareTo(other.LastName);
        }
        #endregion
    }
}
