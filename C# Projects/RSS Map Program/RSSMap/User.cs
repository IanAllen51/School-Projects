using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace RSSMap
{

    public class User : INotifyPropertyChanged
    {
        private ObservableCollection<RSSFeed> userFeeds = new ObservableCollection<RSSFeed>();
        private ObservableCollection<RSSTopic> userTopics = new ObservableCollection<RSSTopic>();
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangedEventHandler TopicChanged;
        private int timerRefresh = 3;
        private readonly string userDataFile = "\\RSSMapUser.xml";
        private readonly string userDataFolder;


        private static System.Timers.Timer updateTimer;

        public User()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            userDataFolder = Path.Combine(folder, "RSSMap");
            userFeeds.CollectionChanged += FeedCollectionChanged;
            userTopics.CollectionChanged += TopicCollectionChanged;
            updateTimer = new System.Timers.Timer(); 
            updateTimer.Elapsed += UpdateFeedTimer;      
            updateTimer.Interval = timerRefresh * 60 * 1000; 
            updateTimer.Start();
        }
        public ObservableCollection<RSSFeed> GetUserFeeds()
        {
            return userFeeds;
        }

        public void SetRefresh(int value)
        {
            timerRefresh = value;
            UpdateXML();
        }

        private void UpdateFeedTimer(object sender, System.Timers.ElapsedEventArgs e)
        {
            foreach (RSSFeed feed in userFeeds)
                feed.UpdateFeed();
        }

        public List<string> GetUserTopics()
        {
            List<string> topicList = new List<string>(); 
            foreach (RSSTopic topic in userTopics)
            {
                topicList.Add(topic.Name);
            }
            return topicList;
        }

        public List<RSSArticle> GetUserArticles(string name)
        {
            RSSFeed feed = userFeeds.Single(a => a.Title == name);
            return feed.GetArticles;
        }



        public void TryLoadXML()
        {
            if (File.Exists(userDataFolder+userDataFile))
            {
                Console.WriteLine("file exists");
                LoadXML(userDataFolder + userDataFile);
            }

        }

        public bool LoadXML(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.Load(fileStream);
            }
            catch (XmlException)
            {
                Console.WriteLine("XML Load Error");
                return false;
            }

            // clear topics and feeds
            foreach(RSSFeed f in userFeeds)
            {
                userFeeds.Remove(f);
            }
            foreach(RSSTopic t in userTopics)
            {
                userTopics.Remove(t);
            }


            XmlElement root = xmlDocument.DocumentElement;
            string refreshString = root.GetElementsByTagName("Refresh") [0].ChildNodes.Item(0).InnerText;
            int refreshValue;
            if (int.TryParse(refreshString, out refreshValue))
            {
                if (refreshValue > 1)
                    timerRefresh = refreshValue;
            }
            XmlNodeList feeds = root.GetElementsByTagName("Feed");
            foreach (XmlNode feed in feeds)
            {
                XmlNodeList feedAttributes = feed.ChildNodes;
                string url = feedAttributes.Item(2).InnerText;
                Console.WriteLine(url);
                if (url != null)
                    userFeeds.Add(new RSSFeed(url));
            }

            XmlNodeList topics = root.GetElementsByTagName("Topic");
            foreach (XmlNode topic in topics)
            {
                XmlNodeList topicAttributes = topic.ChildNodes;
                if (0 < topicAttributes.Count)
                {
                    RSSTopic topicAdd = new RSSTopic(topicAttributes.Item(0).InnerText);

                    if (1 < topicAttributes.Count)
                    {
                        for (int i = 1 ; i < topicAttributes.Count ; i++)
                        {
                            topicAdd.Keywords.Add(topicAttributes.Item(i).InnerText);
                        }
                    }

                    userTopics.Add(topicAdd);
                }
            }

            fileStream.Close();
            return true;
        }

        public void SaveXML(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.NewLineChars = "\n";
            settings.NewLineOnAttributes = false;
            settings.Indent = true;

            XmlWriter w = XmlWriter.Create(fs, settings);
            w.WriteStartDocument();

            w.WriteStartElement("RSSMap");
            w.WriteStartElement("Refresh");
            w.WriteValue(timerRefresh);
            w.WriteEndElement();
            foreach (RSSFeed feed in userFeeds)
            {
                w.WriteStartElement("Feed");

                w.WriteStartElement("Title");
                w.WriteValue(feed.Title);
                w.WriteEndElement();
                w.WriteStartElement("Description");
                w.WriteValue(feed.Description);
                w.WriteEndElement();
                w.WriteStartElement("URL");
                w.WriteValue(feed.URL);
                w.WriteEndElement();
                w.WriteStartElement("Language");
                w.WriteValue(feed.Language);
                w.WriteEndElement();
                w.WriteStartElement("PublishDate");
                w.WriteValue(feed.PublishDate);
                w.WriteEndElement();
                w.WriteEndElement();          
            }

            foreach (RSSTopic topic in userTopics)
            {
                w.WriteStartElement("Topic");

                w.WriteStartElement("Name");
                w.WriteValue(topic.Name);
                w.WriteEndElement();

                foreach (string keyword in topic.Keywords)
                {
                    w.WriteStartElement("Keyword");
                    w.WriteValue(keyword);
                    w.WriteEndElement();
                }

                w.WriteEndElement();           
            }

            w.WriteEndElement();
            w.WriteEndDocument();
            w.Dispose();
            fs.Close();
        }

        public void UpdateXML()
        {
            if (!Directory.Exists(userDataFolder))
            {
                Directory.CreateDirectory(userDataFolder);
            }

            SaveXML(userDataFolder + userDataFile);

        }

        internal void AddTopic(RSSTopic topic)
        {
            userTopics.Add(topic);
            UpdateXML();
        }

        internal void AddFeed(RSSFeed newFeed)
        {
            userFeeds.Add(newFeed);
            UpdateXML();
        }

        internal void RemoveTopic(RSSTopic topic)
        {
            userTopics.Remove(topic);
            UpdateXML();

        }
        internal void RemoveFeed(RSSFeed feed)
        {
            userFeeds.Remove(feed);
            UpdateXML();
        }

        public RSSTopic GetTopic(string name)
        {
            RSSTopic topic = userTopics.Where(t => t.Name == name).FirstOrDefault();
            return topic;
        }



        private void FeedCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var changedFeed = sender as ObservableCollection<RSSFeed>;
                
                PropertyChanged?.Invoke(changedFeed.Last(), null);
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                if (PropertyChanged != null)
                {
                    Console.WriteLine("ayy");
                    
                    List<RSSFeed> oldFeeds = new List<RSSFeed>();
                    foreach (var item in e.OldItems)
                    {
                        oldFeeds.Add((RSSFeed) item);
                    }
                    Console.WriteLine(oldFeeds[0].URL);

                    PropertyChanged(oldFeeds, null);
                }
            }
        }

        private void TopicCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                ObservableCollection<RSSTopic> changedTopic = sender as ObservableCollection<RSSTopic>;
                TopicChanged?.Invoke(changedTopic.Last(), null);
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                TopicChanged?.Invoke(e.OldItems, null);
            }
        }
    }
}
