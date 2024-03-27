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
    public partial class MainWindow : Form
    {
        public string username = "postgres";
        public string databaseName = "tempyelp";
        public string password = "**********";

        public List<Business> businesses = new List<Business>();
        public List<string> categories = new List<string>();
        public List<Friend> friends = new List<Friend>();
        public List<FriendTip> friendTips = new List<FriendTip>();
        public List<User> users = new List<User>();
        public User currentUser = new User();
        public bool newSearch = true;

        public class Business
        {
            public string bid { get; set; }
            public string name { get; set; }
            public string state { get; set; }
            public string city { get; set; }
            public string zip { get; set; }
            public string address { get; set; }
            public int checkincount { get; set; }
            public int tipcount { get; set; }
            public string busid { get; set; }
        }
        public class Friend
        {
            public string name { get; set; }
            public int totalLikes { get; set; }
            public double avgStar { get; set; }
            public string yelpDate { get; set; }
        }
        public class User
        {
            public User()
            {
                name = "";
                avgStar = 0;
                fans = 0;
                yelpDate = "n/a";
                funny = 0;
                cool = 0;
                useful = 0;
                tipCount = 0;
                totalLikes = 69;
                latitude = 0;
                longitude = 0;
                yelpDateCheck = "";
            }
            public string name { get; set; }
            public double avgStar { get; set; }
            public int fans { get; set; }
            public string yelpDate { get; set; }
            public int funny { get; set; }
            public int cool { get; set; }
            public int useful { get; set; }
            public int tipCount { get; set; }
            public int totalLikes { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }

            public string yelpDateCheck { get; set; }
        }

        public class FriendTip
        {
            public string name { get; set; }
            public string businessName { get; set; }
            public string city { get; set; }
            public string tipText { get; set; }
            //public string tipDate { get; set; }
            public DateTime tipDate { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // populates states list to the drop down box on load.
            addStates();
            addColumnsToGrid();
            addColumnToTipTextGrid();
            addColumnToFriendGrid();

        }

        // Function to add header to the grid.
        private void addColumnsToGrid()
        {
            DataGridViewColumn column = new DataGridViewTextBoxColumn { HeaderText = "Name" };
            this.BusinessSearchGridView.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { HeaderText = "Address" };
            this.BusinessSearchGridView.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { HeaderText = "City" };
            this.BusinessSearchGridView.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { HeaderText = "State" };
            this.BusinessSearchGridView.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { HeaderText = "Zip" };
            this.BusinessSearchGridView.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { HeaderText = "# Tips" };
            this.BusinessSearchGridView.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { HeaderText = "Checkins" };
            this.BusinessSearchGridView.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { HeaderText = "busID" };
            this.BusinessSearchGridView.Columns.Add(column);
            this.BusinessSearchGridView.RowHeadersWidth = 75; // in pixels.
        }

        private void addColumnToTipTextGrid()
        {
            DataGridViewColumn column = new DataGridViewTextBoxColumn { HeaderText = "User Name" };
            column.Width = 75;
            this.FriendTipGrid.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { HeaderText = "Business" };
            column.Width = 110;
            this.FriendTipGrid.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { HeaderText = "City" };
            column.Width = 75;
            this.FriendTipGrid.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { HeaderText = "Text" };
            column.Width = 350;
            this.FriendTipGrid.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { HeaderText = "Date" };
            column.Width = 150;
            this.FriendTipGrid.Columns.Add(column);

            this.FriendTipGrid.RowHeadersWidth = 50;
        }

        private void addColumnToFriendGrid()
        {
            DataGridViewColumn column = new DataGridViewTextBoxColumn { HeaderText = "Name" };
            this.FriendGrid.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { HeaderText = "TotalLikes" };
            this.FriendGrid.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { HeaderText = "Avg Stars" };
            this.FriendGrid.Columns.Add(column);

            column = new DataGridViewTextBoxColumn { HeaderText = "Yelping Since" };
            column.Width = 155;
            this.FriendGrid.Columns.Add(column);

            this.FriendGrid.RowHeadersWidth = 50;
        }

        public void addStates()
        {
            string query = "SELECT distinct bstate FROM business ORDER BY bstate";
            executeQuery(query, populateStatesInBox);
        }

        // lambda func to execute initial query to populate the states
        private void populateStatesInBox(NpgsqlDataReader reader)
        {
            stateList.Items.Add(reader.GetString(0));
        }

        // Lambda func for selecting a state and populating the second box with cities.
        private void populateCitiesInBox(NpgsqlDataReader reader)
        {
            citiesBox.Items.Add(reader.GetString(0));
        }
        
        // Lambda func for selecting a city and populating the third box with zip codes.
        private void populateZipsInBox(NpgsqlDataReader reader)
        {
            zipcodeBox.Items.Add(reader.GetString(0));
        }
        
        // Lambda func for selecting a zip and populating the fourth box with categories.
        private void populateCategoriesInBox(NpgsqlDataReader reader)
        {
            categoryList.Items.Add(reader.GetString(0));
        }

        private void populateUserIdInBox(NpgsqlDataReader reader)
        {
            UserIDBox.Items.Add(reader.GetString(0));
        }

        // Lambda for Business Search populating grid
        private void populateBusinesses(NpgsqlDataReader reader)
        {
            // Create business and add to list
            string sqlName = reader.GetString(0);
            string sqlState = reader.GetString(1);
            string sqlCity = reader.GetString(2);
            string sqlZip = reader.GetString(3);

            string sqlAddress = reader.GetString(4);
            int sqlCheckincount = reader.GetInt32(5);
            int sqlTipCount = reader.GetInt32(6);
            string sqlBusID = reader.GetString(7);

            Business businessItem = new Business() {    name = sqlName, state = sqlState, city = sqlCity, zip = sqlZip, address = sqlAddress,
                                                        checkincount = sqlCheckincount, tipcount = sqlTipCount, busid = sqlBusID };

            this.businesses.Add(businessItem);
        }

        private void populateFriends(NpgsqlDataReader reader)
        {
            string sqlName = reader.GetString(0);
            int sqlTotalLikes = reader.GetInt32(1);
            double sqlAvgStar = reader.GetDouble(2);
            string sqlYelpDate = reader.GetString(3);

            Friend addedFriend = new Friend() { name = sqlName, totalLikes = sqlTotalLikes, avgStar = sqlAvgStar, yelpDate = sqlYelpDate };
            this.friends.Add(addedFriend);
        }

        private void populateFriendTips(NpgsqlDataReader reader)
        {
            string sqlName = reader.GetString(0);
            string sqlBusiness = reader.GetString(1);
            string sqlCity = reader.GetString(2);
            string sqlTipText = reader.GetString(3);
            //string sqlTipDate = reader.GetString(4);
            DateTime sqlTipDate = reader.GetDateTime(4);
            FriendTip addFTip = new FriendTip() { name = sqlName, businessName = sqlBusiness, city = sqlCity, tipText = sqlTipText, tipDate = sqlTipDate };
            this.friendTips.Add(addFTip);
        }

        public void populateUsers(NpgsqlDataReader reader)
        {
            string sqlName = reader.GetString(0);
            double sqlStar = reader.GetDouble(1);
            int sqlFans = reader.GetInt32(2);
            string sqlYelpDate = reader.GetString(3);
            int sqlFunny = reader.GetInt32(4);
            int sqlCool = reader.GetInt32(5);
            int sqlUseful = reader.GetInt32(6);
            int sqlTipCount = reader.GetInt32(7);
            int sqlTotalLikes = reader.GetInt32(8);

            currentUser = new User() { name = sqlName, avgStar = sqlStar, fans = sqlFans,yelpDate = sqlYelpDate, funny = sqlFunny, cool = sqlCool, useful = sqlUseful, tipCount = sqlTipCount, totalLikes = sqlTotalLikes, latitude = 0.0, longitude = 0.0};

            //this.users.Add(currentUser);
        }

        public void updateUserInfo()
        {
            UINameBox.Items.Clear();
            UINameBox.Items.Add(currentUser.name);
            UIStarsBox.Items.Clear();
            UIStarsBox.Items.Add(currentUser.avgStar);
            UIFansBox.Items.Clear();
            UIFansBox.Items.Add(currentUser.fans);
            UIYelpBox.Items.Clear();
            UIYelpBox.Items.Add(currentUser.yelpDate);
            UIFunnyBox.Items.Clear();
            UIFunnyBox.Items.Add(currentUser.funny);
            UICoolBox.Items.Clear();
            UICoolBox.Items.Add(currentUser.cool);
            UIUsefulBox.Items.Clear();
            UIUsefulBox.Items.Add(currentUser.useful);
            UITCountBox.Items.Clear();
            UITCountBox.Items.Add(currentUser.tipCount);
            UITLikesBox.Items.Clear();
            UITLikesBox.Items.Add(currentUser.totalLikes);
            UILatBox.Items.Clear();
            UILatBox.Items.Add(currentUser.latitude);
            UILongBox.Items.Clear();
            UILongBox.Items.Add(currentUser.longitude);
        }

        // General query function
        public void executeQuery(string query, Action<NpgsqlDataReader> func)
        {
            string connectionString = "Host = localhost; Username = " + username + "; " +
                "Database = " + databaseName + "; " +
                "password=" + password;

            using (var connection = new NpgsqlConnection(connectionString))
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

        private void stateList_SelectedIndexChanged(object sender, EventArgs e)
        {

            citiesBox.Items.Clear();
            citiesBox.Text = "";
            zipcodeBox.Items.Clear();
            zipcodeBox.Text = "";
            categoryList.Items.Clear();
            categoryList.Text = "";
            clearDataGrid();

            if (stateList.SelectedIndex > -1)
            {
                string query = "SELECT distinct bcity FROM business WHERE bstate = \'" + stateList.SelectedItem.ToString() + "\' ORDER BY bcity";
                executeQuery(query, populateCitiesInBox);
            }
        }

        private void categoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categoryList.SelectedIndex > -1)
            {
                BusinessSearchGridView.Rows.Clear();
                // Add the selected category to the list of categories chosen
                string selectedCategory = categoryList.SelectedItem.ToString();

                if (!categories.Contains(selectedCategory))
                 {
                    this.categories.Add(selectedCategory);
                    this.selectedCategoryBox.Items.Add(selectedCategory);
                }

                // refresh business search for when a new category gets added or removed.
                BusinessSearch();
            }
        }

        private string buildWhereEquiJoin()
        {
            string result = "";

            for (int i = 0; i < categories.Count; i++)
            {
                result += "b.busid = c" + i + ".busid and ";

            }
            return result ;
        }

        private string buildFromQueryString(string from)
        {
            for(int i = 0; i < categories.Count; i++)
            {
                from += ", categories c" +i;
            }

            return from;
        }

        private string OptionalCategoryString()
        {
            if(categories.Count < 1)
            {
                return string.Empty;
            }

            string result = "AND ( ";
            
            for (int i = 0; i<categories.Count; i++)
            {
                result +=  "c" + i + ".category = \'" + categories[i] + "\' ";

                if (categories.Count > 1 && i < categories.Count - 1)
                {
                    result += " and ";
                }
            }

            return result + ") ";
        }

        private void BusinessSearch()
        {
            clearDataGrid();

            string selectedCity = citiesBox.SelectedItem.ToString();
            string selectedState = stateList.SelectedItem.ToString();
            string selectedZip = zipcodeBox.SelectedItem.ToString();

            string select = "SELECT distinct bname, bcity, bstate, bzip, baddress, checkincount, tipcount, b.busid ";
            string from = buildFromQueryString("FROM business b");
            string where = " WHERE " + buildWhereEquiJoin() + " bzip = \'" + selectedZip + "\' " + OptionalCategoryString() + " ORDER BY bname";

            string query = select + from + where;

            executeQuery(query, populateBusinesses);
            updateDataGrid();
        }

        public void updateFriendGrid()
        {
            for (int i = 0; i < this.friends.Count; i++)
            {
                this.FriendGrid.Rows.Add(new DataGridViewRow());
                this.FriendGrid.Rows[i].HeaderCell.Value = (i + 1).ToString();
                this.FriendGrid.Rows[i].Cells[0].Value = this.friends[i].name;
                this.FriendGrid.Rows[i].Cells[1].Value = this.friends[i].totalLikes;
                this.FriendGrid.Rows[i].Cells[2].Value = this.friends[i].avgStar;
                this.FriendGrid.Rows[i].Cells[3].Value = this.friends[i].yelpDate;
            }
        }

        public void updateFriendTipGrid()
        {
            for (int i = 0; i < this.friendTips.Count; i++)
            {
                this.FriendTipGrid.Rows.Add(new DataGridViewRow());
                this.FriendTipGrid.Rows[i].HeaderCell.Value = (i + 1).ToString();
                this.FriendTipGrid.Rows[i].Cells[0].Value = this.friendTips[i].name;
                this.FriendTipGrid.Rows[i].Cells[1].Value = this.friendTips[i].businessName;
                this.FriendTipGrid.Rows[i].Cells[2].Value = this.friendTips[i].city;
                this.FriendTipGrid.Rows[i].Cells[3].Value = this.friendTips[i].tipText;
                this.FriendTipGrid.Rows[i].Cells[4].Value = this.friendTips[i].tipDate;
            }
        }

        public void clearFriendTipGrid()
        {
            this.FriendTipGrid.Rows.Clear();
        }

        public void clearFriendGrid()
        {
            this.FriendGrid.Rows.Clear();
        }

        public void updateDataGrid()
        {
            // update data grid
            // Loop responsible for creating rows in the dataGridView.
            for (int i = 0; i < this.businesses.Count; i++)
            {
                this.BusinessSearchGridView.Rows.Add(new DataGridViewRow());
                this.BusinessSearchGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }

            // Transfer the values from businesses to data grid
            for (int i = 0; i < this.businesses.Count; i++)
            {
                this.BusinessSearchGridView.Rows[i].Cells[0].Value = this.businesses[i].name;
                this.BusinessSearchGridView.Rows[i].Cells[1].Value = this.businesses[i].state;
                this.BusinessSearchGridView.Rows[i].Cells[2].Value = this.businesses[i].city;
                this.BusinessSearchGridView.Rows[i].Cells[3].Value = this.businesses[i].zip;

                this.BusinessSearchGridView.Rows[i].Cells[4].Value = this.businesses[i].address;
                this.BusinessSearchGridView.Rows[i].Cells[5].Value = this.businesses[i].checkincount;
                this.BusinessSearchGridView.Rows[i].Cells[6].Value = this.businesses[i].tipcount;
                this.BusinessSearchGridView.Rows[i].Cells[7].Value = this.businesses[i].busid;
            }
        }

        public void clearDataGrid()
        {
            this.businesses.Clear();
            this.BusinessSearchGridView.Rows.Clear();
            newSearch = true;
        }

        // When a cell selection changes we must change the business info labels at the bottom of Business Search
        private void BusinessSearchGridView_SelectionChanged(object sender, EventArgs e)
        {
            if(BusinessSearchGridView.SelectedRows.Count == 1)
            {
                // Set known information
                string busName = BusinessSearchGridView.SelectedRows[0].Cells[0].Value.ToString(); // name
                string busCity = BusinessSearchGridView.SelectedRows[0].Cells[1].Value.ToString(); // city
                string busState = BusinessSearchGridView.SelectedRows[0].Cells[2].Value.ToString(); // state
                string busZip = BusinessSearchGridView.SelectedRows[0].Cells[3].Value.ToString(); // zip
                string busAddy = BusinessSearchGridView.SelectedRows[0].Cells[4].Value.ToString(); // street address 
                // Cells[5] tips 
                // Cells[6] checkins 
                string busid = BusinessSearchGridView.SelectedRows[0].Cells[7].Value.ToString(); // busid

                string fullAddress = busAddy + ", " + busCity + ", " + busState + " " + busZip;

                selectedBusinessName.Text = busName;
                selectedBusinessAddress.Text = fullAddress;

                // Execute query to receive open and close times based on day of the week.
                string day = DateTime.Today.DayOfWeek.ToString();
                string query = "SELECT dayofweek, opentime, closetime FROM hours WHERE busid = \'" + busid + "\' and dayofweek = \'" + day + "\'";
                executeQuery(query, populateBusinessInfo);
            }
        }

        public void populateBusinessInfo(NpgsqlDataReader reader)
        {
            string day = reader.GetString(0);
            string sqlOpen = reader.GetString(1);
            string sqlClose = reader.GetString(2);

            char[] delim = { ':' };
            string[] open = sqlOpen.Split(delim);
            string[] close = sqlClose.Split(delim);
            Console.WriteLine(open[0]);
            Console.WriteLine(open[1]);

            selectedBusinessOpenClose.Text = "TODAY (" + day + ")--> Open: " + open[0] +"   Close: "+ close[0];
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (BusinessSearchGridView.Rows.Count >= 1 && businesses.Count > 0)
            {
                int row = BusinessSearchGridView.CurrentCell.RowIndex;
                int col = BusinessSearchGridView.CurrentCell.ColumnIndex;

                BusinessForm businessWindow = new BusinessForm(businesses[row].busid);
                businessWindow.Show();
            }
        }

        private void citiesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            zipcodeBox.Items.Clear();
            zipcodeBox.Text = "";
            categoryList.Items.Clear();
            categoryList.Text = "";
            clearDataGrid();

            if (citiesBox.SelectedIndex > -1)
            {
                // Create the text query
                string selectedCity = citiesBox.SelectedItem.ToString();
                string selectedState = stateList.SelectedItem.ToString();

                string query = "SELECT distinct bzip FROM business WHERE bstate = \'" + selectedState + "\' AND bcity = \'" + selectedCity + "\' ORDER BY bzip";
                executeQuery(query, populateZipsInBox);
            }
        }

        private void zipcodeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoryList.Items.Clear();
            categoryList.Text = "";

            if (zipcodeBox.SelectedIndex > -1)
            {
                // Create the text query to get the list of categories in a given zip code.
                string selectedZip = zipcodeBox.SelectedItem.ToString();

                string query = "SELECT distinct category FROM business b, categories c WHERE b.busid = c.busid AND bzip = \'" + selectedZip + "\' ORDER BY category";
                executeQuery(query, populateCategoriesInBox);
            }

            BusinessSearch();
        }

        private void selectedCategoryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int test = selectedCategoryBox.SelectedIndex;
            Console.WriteLine(test);

            if(selectedCategoryBox.SelectedIndex >= 0)
            {
                categories.RemoveAt(selectedCategoryBox.SelectedIndex);
                selectedCategoryBox.Items.RemoveAt(selectedCategoryBox.SelectedIndex);
                BusinessSearch();
            }
        }

        private void UserNameTextBox_TextChanged_1(object sender, EventArgs e)
        {
            UserIDBox.Items.Clear();
            UserIDBox.Text = "";

            string userName = UserNameTextBox.Text;
            if (userName != "")
            {
                string query = "SELECT userid FROM users WHERE uname like '" + userName + "%'";
                executeQuery(query, populateUserIdInBox);
            }
            
        }

        private void UserIDBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // trim the string of the userID if any whitespace is detected
            string userId = UserIDBox.SelectedItem.ToString().Trim();

            if(UserIDBox.SelectedIndex > -1)
            {
                this.friends.Clear();
                this.friendTips.Clear();
                string query = "SELECT users.uname, users.avgstars, users.totalfans, users.join_datetime, users.funnyvotes, users.coolvotes, users.usefulvotes, count(likes) as TipCount, sum(likes) as TotalTipCount FROM tip, users WHERE tip.userid = \'" + userId + "\' AND tip.userid = users.userid GROUP BY users.userid";
                executeQuery(query, populateUsers);
                if (currentUser.yelpDateCheck == currentUser.yelpDate)
                {
                    currentUser = new User();
                }
                else 
                {
                    currentUser.yelpDateCheck = currentUser.yelpDate;
                }
                updateUserInfo();

                query = "SELECT uname, tipcount, avgstars, join_datetime FROM users, friend WHERE users.userid = friend.friendid and friend.userid = '"+ userId + "'";
                executeQuery(query, populateFriends);
                clearFriendGrid();
                updateFriendGrid();

                query = "SELECT FriendList.fname, business.bname, business.bcity, tip.tiptext, tip.tipdate FROM business, tip, (SELECT users.userid AS fid, users.uname AS fname FROM users, friend WHERE users.userid = friend.friendid and friend.userid = '"+ userId +"') AS FriendList WHERE FriendList.fid = tip.userid AND business.busid = tip.busid ORDER BY tipdate desc";
                query = "SELECT FriendList.fname, business.bname, business.bcity, tip.tiptext, tip.tipdate FROM business, tip, (SELECT users.userid AS fid, users.uname AS fname FROM users, friend WHERE users.userid = friend.friendid and friend.userid = '"+ userId +"') AS FriendList WHERE FriendList.fid = tip.userid AND business.busid = tip.busid AND tipdate = (SELECT MAX(tipdate) FROM tip WHERE tip.userid = fid)";
                executeQuery(query, populateFriendTips);
                clearFriendTipGrid();
                updateFriendTipGrid();
            }
            //updateUserInfo();
        }
    }
}
