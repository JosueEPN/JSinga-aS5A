using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSingañaS5A.Utils
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename) 
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory,filename);
        }
    }
}
