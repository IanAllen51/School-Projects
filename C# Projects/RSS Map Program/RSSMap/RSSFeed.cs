using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace RSSMap
{
    public class RSSFeed
    {
        public string URL { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string PublishDate { get; set; }
        public List<RSSArticle> GetArticles { get { return articles; } }

        private List<RSSArticle> articles;
        public RSSFeed(string url)
        {
            this.URL = url;
            articles = new List<RSSArticle>();
            ConstructFeed(url);
        }

        private void ConstructFeed(string url)
        {
            using (XmlReader reader = XmlReader.Create(url))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                this.Title = feed.Title.Text;
                this.Description = feed.Description.Text;
                this.Language = feed.Language;
                this.PublishDate = feed.LastUpdatedTime.Date.ToString();

                foreach (SyndicationItem item in feed.Items)
                {
                    RSSArticle art = new RSSArticle();
                    if(item.Title.Text!=null)
                        art.Title = item.Title.Text;

                    //parse out summary text
                    string description = string.Empty;
                    if (item.Summary.Text != null)
                    {
                        description = item.Summary.Text;
                        description = Regex.Replace(description, @"<[^>]+>|&nbsp;", "").Trim();
                        description = WebUtility.HtmlDecode(description);
                    }
                    art.Description = description;

                    //parse out date
                    if( item.PublishDate.Date != null)
                        art.Date = item.PublishDate.Date;

                    //parse out uri
                    if(item.Links [0].Uri != null)
                        art.URL = item.Links [0].Uri.ToString();

                    //add new RSSArticle to articles list
                    this.articles.Add(art);
                }
                GetLocations();

            }
        }

        private void GetLocations()
        {
            string locationPath = "../Locations/";
            bool exists = Directory.Exists(locationPath);
            if (!exists)
            {
                DirectoryInfo d = Directory.CreateDirectory(locationPath);
            }
                
            string [] fileEntries = Directory.GetFiles(locationPath);
            foreach (string fileName in fileEntries)
            {
                Console.WriteLine(fileName);
                if(Path.HasExtension(".csv"))
                {
                    StreamReader streamReader = new StreamReader(fileName);
                    foreach(RSSArticle article in articles)
                    {
                        List<string[]> lines = new List<string[]>();
                        int Row = 0;
                        while (!streamReader.EndOfStream)
                        {
                            string[] Line = streamReader.ReadLine().Split(',');
                            lines.Add(Line);
                            Row++;
                        }
                        int Column = 1;
                        string city = null;
                        string state = null;
                        while (Column < Row)
                        {
                            //check city
                            string csvCity  = lines[Column][3];
                            string csvState = lines[Column][2];
                            if (article.Description.Contains(csvCity) || article.Title.Contains(csvState))
                            {
                                city = csvCity;
                                state = csvState;
                                article.latitude = Convert.ToDouble(lines [Column] [5]);
                                article.longitude = Convert.ToDouble(lines [Column] [6]);
                                break;
                            }

                            Column++;
                        }
                        if (city != null)
                        {
                            string location = city + ", " + state;
                            article.Location = location;
                        }
                        else
                        {
                            article.Location = string.Empty;
                        }
                        
                        //reset streamreader
                        streamReader.DiscardBufferedData();
                        streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    }

                }

            }
        }

        public void UpdateFeed()
        {
            this.articles.Clear();
            this.ConstructFeed(this.URL);
        }

    }
}
