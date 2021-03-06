﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserSorter.Factory
{
    public class SpaceDelimitedFile : IFileFactory
    {
        public SpaceDelimitedFile() { }
        public SpaceDelimitedFile(String fileLocation) => FileLocation = fileLocation;

        public String FileLocation { get; set; }

        List<Person> IFileFactory.Parse()
        {
            Globals globals = new Globals();
            return globals.ParseBy(' ', FileLocation);
        }
    }
}
