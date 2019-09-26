using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeoInformation.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Url { get; set; }
        public string Download_url { get; set; }
    }
}