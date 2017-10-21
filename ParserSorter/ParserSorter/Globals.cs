using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserSorter
{
    public class Globals
    {
        public enum Gender
        {
            Female,
            Male,
            Other
        }

        public enum SortDirection
        {
            Ascending,
            Descending
        }

        public List<Person> ParseBy(Char delimiter, String fileLocation)
        {
            List<Person> retVal = new List<Person>();
            StreamReader reader = File.OpenText(fileLocation);
            String line;
            while ((line = reader.ReadLine()) != null)
            {
                String[] items = line.Split(delimiter);
                Gender personGender;
                if (String.IsNullOrEmpty(items[2]))
                {
                    personGender = Gender.Other;
                }
                else
                {
                    Enum.TryParse(items[2], true, out Gender personGender2);
                    personGender = personGender2;
                }

                DateTime dateResult;
                DateTime.TryParse(items[3], out dateResult);

                Person parsedLine = new Person()
                {
                    LastName = items[0] ?? "",
                    FirstName = items[1] ?? "",
                    Gender = personGender,
                    DateOfBirth = dateResult
                };
                retVal.Add(parsedLine);
            }
            return retVal;
        }
    }
}
