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
        public DateTime? DateOfBirth { get; set; }

        #region Default Sort
        Int32 IComparable.CompareTo(Object obj)
        {
            Person p = (Person)obj;
            return String.Compare(LastName, p.LastName);
        }
        #endregion
    }
}
