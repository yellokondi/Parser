using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace ParserSorter
{
    public class Globals
    {
        #region Enums
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
        #endregion

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
                DateTime.TryParse(items[4], out dateResult);

                Person parsedLine = new Person()
                {
                    LastName = items[0] ?? "",
                    FirstName = items[1] ?? "",
                    Gender = personGender,
                    FavoriteColor = items[3] ?? "",
                    DateOfBirth = dateResult
                };
                retVal.Add(parsedLine);
            }
            return retVal;
        }

        #region Unit Tests
        [Fact]
        public void ParseBy_FileLocationNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ParseBy(',', null));
        }

        [Fact]
        public void ParseBy_FileLocationWrong_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ParseBy(',', " "));
            Assert.Throws<ArgumentException>(() => ParseBy(',', ""));
            Assert.Throws<ArgumentException>(() => ParseBy(',', "|"));
        }

        [Fact]
        public void ParseBy_FileLocationWrongFilename_ThrowsArgumentNullException()
        {
            Assert.Throws<FileNotFoundException>(() => ParseBy(',', @"C:\MyDir\CommaDelimited.txt"));
        }

        [Fact]
        public void ParseBy_FileLocationWrongDirectoryPath_ThrowsArgumentNullException()
        {
            Assert.Throws<DirectoryNotFoundException>(() => ParseBy(',', @"Z:\MyDir\CommaDelim.txt"));
        }

        [Fact]
        public void ParseBy_CommaDelimitedLine_ReturnsPerson()
        {
            //arrange:
            String fileLocation = @"TestSamples\UnitTestCommaDelimited.txt";
            List<Person> expected = new List<Person>
            {
                new Person()
                {
                    FirstName = "Joshua",
                    LastName = "Chavez",
                    Gender = Gender.Male,
                    FavoriteColor = "Purple",
                    DateOfBirth = new DateTime(1985, 3, 13)
                }
            };

            //act
            List<Person> actual = ParseBy(',', fileLocation);

            //assert
            Assert.Equal<Person>(expected, actual);
        }

        [Fact]
        public void ParseBy_CommaDelimitedLineWithNoGender_ReturnsPersonWithGenderSetToOther()
        {
            //arrange:
            String fileLocation = @"TestSamples\UnitTestGenderOther.txt";
            List<Person> expected = new List<Person>
            {
                new Person()
                {
                    FirstName = "Joshua",
                    LastName = "Chavez",
                    Gender = Gender.Other,
                    FavoriteColor = "Purple",
                    DateOfBirth = new DateTime(1985, 3, 13)
                }
            };

            //act
            List<Person> actual = ParseBy(',', fileLocation);

            //assert
            Assert.Equal<Person>(expected, actual);
        }
        #endregion
    }
}
