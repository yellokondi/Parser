using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ParserSorter.Factory
{
    public class ConcreteFileFactory : FileFactory
    {
        public override IFileFactory GetFile(String fileLocation)
        {
            String delimiter = IdentifyDelimiter(fileLocation);
            switch (delimiter.ToLowerInvariant())
            {
                case "space":
                    return new SpaceDelimitedFile(fileLocation);
                case "comma":
                    return new CommaDelimitedFile(fileLocation);
                case "pipe":
                    return new PipeDelimitedFile(fileLocation);
                default:
                    throw new ApplicationException(String.Format("{0} delimited file cannot be created", delimiter));
            }
        }

        public String IdentifyDelimiter(String fileLocation)
        {
            String retVal = String.Empty;
            StreamReader reader = File.OpenText(fileLocation);
            String line = reader.ReadLine();

            //from the first line, find which delimiter occurs most often:
            if (!String.IsNullOrEmpty(line))
            {
                Int32 spaceDelimited = line.Split(' ').Length;
                Int32 commaDelimited = line.Split(',').Length;
                Int32 pipeDelimited = line.Split('|').Length;
                if (spaceDelimited > commaDelimited)
                {
                    if (commaDelimited > pipeDelimited || spaceDelimited > pipeDelimited)
                    {
                        retVal = "space";
                    }
                }
                else if (commaDelimited > pipeDelimited)
                {
                    retVal = "comma";
                }
                else
                {
                    retVal = "pipe";
                }
            }
            return retVal;
        }

        #region Unit Tests

        #endregion
    }
}
