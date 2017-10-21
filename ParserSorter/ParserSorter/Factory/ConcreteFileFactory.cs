using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserSorter.Factory
{
    public class ConcreteFileFactory : FileFactory
    {
        public override IFileFactory GetFile(String fileType,String fileLocation)
        {
            switch (fileType.ToLowerInvariant())
            {
                case "space":
                    return new SpaceDelimitedFile(fileLocation);
                case "comma":
                    return new CommaDelimitedFile(fileLocation);
                case "pipe":
                    return new PipeDelimitedFile(fileLocation);
                default:
                    throw new ApplicationException(String.Format("File type '{0}' cannot be created", fileType));
            }
        }
    }
}
