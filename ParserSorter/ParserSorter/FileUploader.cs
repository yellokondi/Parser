using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace ParserSorter
{
    public class FileUploader
    {
        #region Constructors
        public FileUploader() { }

        public FileUploader(String fileLocation)
        {
            DefaultFileLocation = fileLocation;
        }

        #endregion

        #region Properties
        public String DefaultFileLocation
        {
            get
            {
                return ConfigurationManager.AppSettings["DefaultFileLocation"].ToString();
            }
            private set { }
        }
        #endregion

        #region Methods
        public Boolean FileExists(String fileLocation)
        {            
            return File.Exists(fileLocation);
        }

        public Stream LoadFile(String fileLocation)
        {
            StreamReader sr = File.OpenText(fileLocation);
            return sr.BaseStream;
        }

        #endregion


    }
}
