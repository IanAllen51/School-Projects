using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace RSSMap
{
    public partial class MainForm : Form
    {
        User user;
        public MainForm()
        {
            InitializeComponent();
            
            mapControl.Map.CredentialsProvider = new ApplicationIdCredentialsProvider("AleUAeyFx38ydQcy9s51Ycc7BReixuDnIci5RymVhGRFLwRI-GVYkbjG0SwdbRSS");
            user = new User();

            user.PropertyChanged += UpdateTreeView;
            user.TopicChanged += currentUser_TopicChanged;
            mapControl.clicked += PinClicked;
            user.TryLoadXML();
            
        }

        private void manageTopicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageTopic userTopics = new ManageTopic(user);
            userTopics.Show();
            userTopics.Focus();
        }

        private void manageFeedsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageFeeds userSubscription = new ManageFeeds(user);
            userSubscription.Show();
            userSubscription.Focus();
        }

        private void setRefreshRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshForm refreshForm = new RefreshForm(user);
            refreshForm.Show();
            refreshForm.Focus();
        }



        public void UpdateTreeView(object sender, EventArgs e)
        {
            RSSFeed f = sender as RSSFeed;
            //add feed
            if (f != null)
            {
                FeedTreeView.BeginUpdate();
                FeedTreeView.Nodes.Add(f.URL, f.Title);
                FeedTreeView.EndUpdate();
                FeedTreeView.Refresh();
            }
            //remove feed
            else
            {
                List<RSSFeed> oldFeeds = sender as List<RSSFeed>;
                FeedTreeView.BeginUpdate();
                foreach (RSSFeed item in oldFeeds)
                    FeedTreeView.Nodes.RemoveByKey(item.URL);
                FeedTreeView.EndUpdate();
                FeedTreeView.Refresh();
            }
        }

        void currentUser_TopicChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender.GetType() == typeof(RSSTopic))
            {
                RSSTopic topic = sender as RSSTopic;
                TopicTreeView.BeginUpdate();
                TopicTreeView.Nodes.Add(topic.Name, topic.Name);
                TopicTreeView.EndUpdate();
                TopicTreeView.Refresh();
            }
            else
            {
                System.Collections.IList topics = sender as System.Collections.IList;
                TopicTreeView.BeginUpdate();
                foreach (RSSTopic topic in topics)
                {
                    TopicTreeView.Nodes.RemoveByKey(topic.Name);
                }

                TopicTreeView.EndUpdate();
                TopicTreeView.Refresh();
            }
        }

        private void FeedTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView currentTreeView = sender as TreeView;
            var curArticles = new List<RSSArticle>(user.GetUserArticles(currentTreeView.SelectedNode.Text));
            Console.WriteLine(curArticles.Count);
            ArticleDataGridView.DataSource = curArticles;
            for (int i = 0 ; i < ArticleDataGridView.ColumnCount ; i++)
            {
                ArticleDataGridView.Columns [i].SortMode = DataGridViewColumnSortMode.Automatic;
                ArticleDataGridView.Columns [i].ReadOnly = true;
            }

            var articles = new List<RSSArticle>(user.GetUserArticles(currentTreeView.SelectedNode.Text));


            mapControl.addPins(articles);
            

        }

        private void TopicTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView currentTreeView = sender as TreeView;
            string topicName = currentTreeView.SelectedNode.Text;

            //making sure no duplicate articles
            HashSet<RSSArticle> articles = new HashSet<RSSArticle>();
            Console.WriteLine(articles.Count);
            RSSTopic topic = user.GetTopic(topicName);

            foreach (string keyword in topic.Keywords)
            {
                foreach (RSSFeed feed in user.GetUserFeeds())
                {
                    List<RSSArticle> matchFound = feed.GetArticles.Where(f => f.Title.ToLower().Contains(keyword.ToLower()) || f.Description.ToLower().Contains(keyword.ToLower())).ToList();

                    if (null != matchFound)
                    {
                        foreach (RSSArticle article in matchFound)
                        {
                            articles.Add(article);
                        }
                    }
                }
            }

            List<RSSArticle> articlesDisplay = articles.OrderByDescending(a => a.Date).ToList();

            var curArticles = new List<RSSArticle>(articlesDisplay);
            ArticleDataGridView.DataSource = curArticles;
            for (int i = 0 ; i < ArticleDataGridView.ColumnCount ; i++)
            {
                ArticleDataGridView.Columns [i].SortMode = DataGridViewColumnSortMode.Automatic;
                ArticleDataGridView.Columns [i].ReadOnly = true;
            }
        }

        private void loadXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Opens load file dialog box.
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "XML File (*xml)|*.xml";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    user.LoadXML(openFileDialog.FileName);
                }
            }
        }

        private void saveXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML File (*.xml)|*.xml";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                user.SaveXML(saveFileDialog.FileName);

            }
        }

        private void ArticleDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var Grid = sender as DataGridView;
            if (e.ColumnIndex == ArticleDataGridView.Columns ["Read"].Index)
            {
                if ((bool) ArticleDataGridView.Rows [e.RowIndex].Cells ["Read"].Value)
                {
                    ArticleDataGridView.Rows [e.RowIndex].Cells ["Read"].Value = false;
                }
                else
                {
                    ArticleDataGridView.Rows [e.RowIndex].Cells ["Read"].Value = true;
                    WebBrowser.Url = new Uri(Grid.CurrentRow.Cells ["URL"].Value.ToString());
                    TabControl.SelectedIndex = 2;
                }
            }
            else
            {
                Grid.CurrentRow.Cells ["Read"].Value = true;
                WebBrowser.Url = new Uri(Grid.CurrentRow.Cells ["URL"].Value.ToString());
                TabControl.SelectedIndex = 2;
            }



        }

        private void PinClicked(object sender, MouseButtonEventArgs e)
        {
            Pushpin p = sender as Pushpin;
            WebBrowser.Url = new Uri(p.Content.ToString());
            TabControl.SelectedIndex = 2;
        }

        public void FeedTopicTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            FeedTreeView.SelectedNode = null;
            TopicTreeView.SelectedNode = null;
        }
    }
}
