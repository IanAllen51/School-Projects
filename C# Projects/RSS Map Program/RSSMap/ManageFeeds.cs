using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSSMap
{
    public partial class ManageFeeds : Form
    {
        private User user;
        private ObservableCollection<RSSFeed> userFeeds;
        public ManageFeeds(User u)
        {
            user = u;
            InitializeComponent();
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            dataGridViewFeed.Columns.Add(chk);
            chk.HeaderText = "Select";
            chk.Name = "Check";
            userFeeds = user.GetUserFeeds();
            dataGridViewFeed.DataSource = new List<RSSFeed>(userFeeds);
        }

        private void ManageFeedAddButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textboxURL.Text))
                MessageBox.Show("Error: RSS URL can not be empty", "URL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string URL = textboxURL.Text;
                if (!this.HasFeed(URL))
                {
                    RSSFeed feed = new RSSFeed(URL);
                    user.AddFeed(feed);
                    dataGridViewFeed.DataSource = new List<RSSFeed>(userFeeds);
                    textboxURL.Text = String.Empty;
                    textboxURL.Focus();
                }
                else
                    MessageBox.Show("Error: Feed already exists", "Duplicate Feed Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }


        private bool HasFeed(string url)
        {
            foreach(RSSFeed feed in userFeeds)
            {
                if (feed.URL == url)
                    return true;
            }
            return false;
        }

        private void ManageDeleteFeedButton_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (DataGridViewRow item in dataGridViewFeed.Rows)
            {
                bool isChecked = false;
                bool.TryParse(item.Cells [0].EditedFormattedValue.ToString(), out isChecked);
                if (isChecked) 
                {
                    user.RemoveFeed(userFeeds[i]);
                }
                i++;
            }
            
            dataGridViewFeed.DataSource = new List<RSSFeed>(userFeeds);
        }

        private void ManageAcceptButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
