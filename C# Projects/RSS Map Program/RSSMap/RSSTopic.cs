using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSMap
{
    public class RSSTopic
    {
        private string topicName;
        private List<string> topicKeywords;

        public string Name
        {
            get
            {
                return topicName;
            }
            set
            {
                topicName = value;
            }
        }

        public List<string> Keywords
        {
            get
            {
                return topicKeywords;
            }
            set
            {
                topicKeywords = value;
            }
        }

        public RSSTopic(string name)
        {
            topicName = name;
            topicKeywords = new List<string>();
        }
    }
}
