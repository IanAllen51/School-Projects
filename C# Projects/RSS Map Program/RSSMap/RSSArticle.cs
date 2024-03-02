using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RSSMap
{
    public class RSSArticle
    {
        public bool Read { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string URL { get; set; }
        public string Location { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }




    }
}
