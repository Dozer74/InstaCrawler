using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaCrawler
{
    class CsvWriter
    {
        public static void Write(string path, List<InstaPhoto> photos)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Latitude;Longitude;Name;Thumbnail");
            foreach (var instaPhoto in photos)
            {
                sb = sb.Append(instaPhoto.Location.Latitude).Append(';')
                    .Append(instaPhoto.Location.Longitude).Append(';')
                    .Append(instaPhoto.Location.Name).Append(';')
                    .AppendLine(instaPhoto.Thumbnail.Url);
            }
            File.WriteAllText(path,sb.ToString());
        }
    }
}
