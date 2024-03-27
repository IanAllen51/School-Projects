using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace WindowsFormsProject
{
    public partial class BusinessForm : Form
    {
        public string userId = "flV3LafkoykzuGFsM5mFng";
        public string busId = "";

        public List<Tip> tipsModelList = new List<Tip>();

        public class Tip
        {
            public string date { get; set; }
            public string name { get; set; }
            public int likes { get; set; }
            public string text { get; set; }
        }

        public BusinessForm(string busid)
        {
            InitializeComponent();
            this.busId = String.Copy(busid);
        }

        private void BusinessForm_Load(object sender, EventArgs e)
        {
            Console.WriteLine(busId);

            getUser();
            getBusinessQuery();
            addColumnsToGrid();
            getTipsQuery();

        }

        public void addColumnsToGrid()
        {
            DataGridViewColumn column = new DataGridViewTextBoxColumn { HeaderText = "Date" };
            this.tipsGridView.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { HeaderText = "User Name" };
            this.tipsGridView.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { HeaderText = "Likes" };
            this.tipsGridView.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { HeaderText = "Text" };
            this.tipsGridView.Columns.Add(column);
        }

        private void getUser()
        {
            string query = "SELECT uname, userid, avgstars, totallikes, tipcount FROM users WHERE userid = \'"+userId+"\'";
            executeQuery(query, setUserData);
        }
        
        private void getBusinessQuery()
        {
            string query = "SELECT bname FROM business WHERE busid = \'" + this.busId + "\'";
            executeQuery(query, setBusiness);
        }

        // tips ordered from newest to oldest
        private void getTipsQuery()
        {
            tipsModelList.Clear();
            // date, name, likes, text
            string query = "SELECT t.tiptext, t.tipdate, t.likes, u.uname FROM tip t, users u WHERE t.busid = \'" + this.busId + "\' AND t.userid = u.userid ORDER BY tipdate DESC";
            executeQuery(query, setTips);
        }

        private void setTips(NpgsqlDataReader reader)
        {
            string qtext = reader.GetString(0);
            string qdate = reader.GetDateTime(1).ToString();
            int qlikes = reader.GetInt32(2);
            string qname = reader.GetString(3);

            Tip tip = new Tip() { text = qtext, date = qdate, likes = qlikes, name = qname };
            tipsModelList.Add(tip);
            tipsGridView.Rows.Add(qdate, qname, qlikes, qtext);
        }

        private void doNothing(NpgsqlDataReader reader)
        {
        }

        private void setUserData(NpgsqlDataReader reader)
        {
            nameLabel.Text   = "Name: " + reader.GetString(0);
            idLabel.Text     = "UserID: " + reader.GetString(1);
            starsLabel.Text  = "Avg Stars: " + reader.GetDouble(2).ToString();
            likesLabel.Text  = "Total Likes: " + reader.GetInt32(3).ToString();
            tipLabel.Text    = "Tip Count: " + reader.GetInt32(4).ToString();
        }

        private void setBusiness(NpgsqlDataReader reader)
        {
            businessNameLabel.Text = reader.GetString(0);
        }

        // connection and authentication to DB
        private string buildConnectionString()
        {
            return "Host = localhost; Username = postgres; Database = tempyelp; password=TwilightOne1!";
        }

        // General query function
        public void executeQuery(string query, Action<NpgsqlDataReader> func)
        {
            using (var connection = new NpgsqlConnection(this.buildConnectionString()))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = query;
                    try
                    {
                        // execute command
                        var reader = cmd.ExecuteReader();
                        // iterate through results and add the read item into the list of state combobox
                        while (reader.Read())
                            func(reader);
                    }
                    catch (NpgsqlException ex)
                    {
                        Console.WriteLine(ex.Message.ToString());
                        MessageBox.Show("SQL Error: " + ex.Message.ToString());
                    }
                    finally
                    {
                        connection.Close();
                    }

                }
            }
        }

        private string dateTimeNow()
        {
            string timeString = "";
            DateTime now = DateTime.Now;

            int month = now.Month;
            int day = now.Day;
            int year = now.Year;
            int hour = now.Hour;
            int minute = now.Minute;
            int second = now.Second;

            timeString = year + "-" + month + "-" + day + " " + hour + ":" + minute + ":" + second;
            
            return timeString;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            tipsGridView.Rows.Clear();

            int n = DateTime.Now.Second;

            string tip = tipTextBox.Text;
            string query = "INSERT INTO tip VALUES (\'" + busId + "\', \'" + userId + "\', \'"+ dateTimeNow() +"\', 0, \'" + tip +  "\');";

            Console.WriteLine(query);
            executeQuery(query, doNothing);

            getUser();
            getBusinessQuery();
            getTipsQuery();
        }
    }
}
