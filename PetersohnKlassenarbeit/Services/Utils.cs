using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetersohnKlassenarbeit.Services
{
    internal class Utils
    {
        public static string GetSavePath(string folderPath, string extension)
        {
            string fileName = string.Format("output-{0:yyyy-MM-dd_HH-mm-ss}." + extension, DateTime.Now);
            return Path.Combine(folderPath, fileName);
        }
    }
}
