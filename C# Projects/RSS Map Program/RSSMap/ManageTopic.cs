using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSSMap
{
    public partial class ManageTopic : Form
    {
        private User user;
        public ManageTopic(User u)
        {
            InitializeComponent();
            user = u;
            List<string> topics = user.GetUserTopics();
            foreach (string topic in topics)
            {
                comboBoxTopics.Items.Add(topic);
            }
            if (null == comboBoxTopics.SelectedItem && 0 < comboBoxTopics.Items.Count)
            {
                comboBoxTopics.SelectedIndex = 0;
            }
        }


        private void buttonNewTopic_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxTopic.Text))
            {
                MessageBox.Show("Error: Topic can not be empty.", "Empty Topic Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string topicName = textBoxTopic.Text;
                RSSTopic topic = new RSSTopic(topicName);
                user.AddTopic(topic);
                comboBoxTopics.Items.Add(topicName);
                textBoxTopic.Clear();
                comboBoxTopics.SelectedIndex = comboBoxTopics.Items.Count - 1;
            }
        }

        private void buttonDeleteTopic_Click(object sender, EventArgs e)
        {
            if (comboBoxTopics.Items.Count == 0)
            {
                MessageBox.Show("Error: There are no topics to delete.", "Delete Empty Topic Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int index = comboBoxTopics.SelectedIndex;
                string topicString = comboBoxTopics.SelectedItem as string;
                comboBoxTopics.Items.Remove(comboBoxTopics.SelectedItem);
                RSSTopic topicDelete = user.GetTopic(topicString);
                if (topicDelete != null)
                {
                    user.RemoveTopic(topicDelete);
                }
                else
                {
                    MessageBox.Show("Error: The topic you are trying to delete does not exist!", "Delete Unused Topic Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if(comboBoxTopics.Items.Count != 0)
                {
                    comboBoxTopics.SelectedIndex = index-1 > 0 ? index-1: 0; 

                }
                else
                {
                    comboBoxTopics.Text = string.Empty;
                }
                Console.WriteLine(comboBoxTopics.SelectedItem as string);
            }
        }

        private void selectedIndex_Changed(object sender, EventArgs e)
        {
            checkedListBoxKeywords.Items.Clear();
            string topicName = comboBoxTopics.SelectedItem as string;
            RSSTopic selectedTopic = user.GetTopic(topicName);
            if (null != selectedTopic)
            {
                foreach (string keyword in selectedTopic.Keywords)
                {
                    checkedListBoxKeywords.Items.Add(keyword, false);
                }
            }
        }

        private void buttonDeleteKeywords_Click(object sender, EventArgs e)
        {
            if (0 == comboBoxTopics.Items.Count)
            {
                MessageBox.Show("Error: There are no topics to delete.", "Delete Empty Topic Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string[] deleteKeys = checkedListBoxKeywords.CheckedItems.OfType<string>().ToArray();
                if (null != deleteKeys && 0 < deleteKeys.Length)
                {
                    foreach (string deleteKey in deleteKeys)
                    {
                        checkedListBoxKeywords.Items.Remove(deleteKey);
                    }
                    string topicName = comboBoxTopics.SelectedItem as string;
                    RSSTopic selectedTopic = user.GetTopic(topicName);
                    if (null != selectedTopic)
                    {
                        foreach (string keyword in deleteKeys)
                        {
                            selectedTopic.Keywords.Remove(keyword);
                        }
                    }
                }
            }
        }

        private void buttonAddKeyword_Click(object sender, EventArgs e)
        {
            if (null == comboBoxTopics.SelectedItem)
            {
                MessageBox.Show("Error: Add a topic before adding keywords to it", "Empty Topic Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(textBoxKeyword.Text))
            {
                MessageBox.Show("Error: Keyword can not be empty", "Empty Keyword Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                checkedListBoxKeywords.Items.Add(textBoxKeyword.Text);
                string topic = comboBoxTopics.SelectedItem as string;
                RSSTopic selectedTopic = user.GetTopic(topic);
                if (null != selectedTopic)
                {
                    selectedTopic.Keywords.Add(textBoxKeyword.Text);
                }
                textBoxKeyword.Clear();
            }

        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
