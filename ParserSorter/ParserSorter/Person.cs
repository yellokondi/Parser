using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserSorter
{
    public class Person
    {
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public Globals.Gender Gender { get; set; }
        public String FavoriteColor { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
