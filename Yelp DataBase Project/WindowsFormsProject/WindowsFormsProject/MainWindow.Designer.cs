
namespace WindowsFormsProject
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.stateList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.categoryList = new System.Windows.Forms.ComboBox();
            this.npgsqlDataAdapter1 = new Npgsql.NpgsqlDataAdapter();
            this.BusinessSearchGridView = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.openButton = new System.Windows.Forms.Button();
            this.citiesBox = new System.Windows.Forms.ListBox();
            this.zipcodeBox = new System.Windows.Forms.ListBox();
            this.selectedCategoryBox = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.BusinessSearchTab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectedBusinessOpenClose = new System.Windows.Forms.Label();
            this.selectedBusinessAddress = new System.Windows.Forms.Label();
            this.selectedBusinessName = new System.Windows.Forms.Label();
            this.UserInfoTab = new System.Windows.Forms.TabPage();
            this.UIUpdateButton = new System.Windows.Forms.Button();
            this.UIEditButton = new System.Windows.Forms.Button();
            this.UILongBox = new System.Windows.Forms.ListBox();
            this.UILatBox = new System.Windows.Forms.ListBox();
            this.UITLikesBox = new System.Windows.Forms.ListBox();
            this.UITCountBox = new System.Windows.Forms.ListBox();
            this.UIUsefulBox = new System.Windows.Forms.ListBox();
            this.UICoolBox = new System.Windows.Forms.ListBox();
            this.UIFunnyBox = new System.Windows.Forms.ListBox();
            this.UIYelpBox = new System.Windows.Forms.ListBox();
            this.UIFansBox = new System.Windows.Forms.ListBox();
            this.UIStarsBox = new System.Windows.Forms.ListBox();
            this.UINameBox = new System.Windows.Forms.ListBox();
            this.UserInfoLongLabel = new System.Windows.Forms.Label();
            this.UserInfoLatLabel = new System.Windows.Forms.Label();
            this.UserInfoLocationLabel = new System.Windows.Forms.Label();
            this.UserInfoTLikesLabel = new System.Windows.Forms.Label();
            this.UserInfoTCountLabel = new System.Windows.Forms.Label();
            this.UserInfoUsefulLabel = new System.Windows.Forms.Label();
            this.UserInfoCoolLabel = new System.Windows.Forms.Label();
            this.UserInfoFunnyLabel = new System.Windows.Forms.Label();
            this.UserInfoVotesLabel = new System.Windows.Forms.Label();
            this.UserInfoYelpLabel = new System.Windows.Forms.Label();
            this.UserInfoFansLabel = new System.Windows.Forms.Label();
            this.UserInfoStarsLabel = new System.Windows.Forms.Label();
            this.UserInfoNameLabel = new System.Windows.Forms.Label();
            this.UserInfoLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.UserIDBox = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.FriendGrid = new System.Windows.Forms.DataGridView();
            this.FriendTipGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.BusinessSearchGridView)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.BusinessSearchTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.UserInfoTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FriendGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FriendTipGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // stateList
            // 
            this.stateList.FormattingEnabled = true;
            this.stateList.Location = new System.Drawing.Point(195, 64);
            this.stateList.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.stateList.Name = "stateList";
            this.stateList.Size = new System.Drawing.Size(316, 39);
            this.stateList.TabIndex = 0;
            this.stateList.Text = "Pick a State: ";
            this.stateList.SelectedIndexChanged += new System.EventHandler(this.stateList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "State: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 155);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "City: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 525);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Zipcode: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 839);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "Categories: ";
            // 
            // categoryList
            // 
            this.categoryList.FormattingEnabled = true;
            this.categoryList.Location = new System.Drawing.Point(221, 839);
            this.categoryList.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.categoryList.Name = "categoryList";
            this.categoryList.Size = new System.Drawing.Size(364, 39);
            this.categoryList.TabIndex = 7;
            this.categoryList.SelectedIndexChanged += new System.EventHandler(this.categoryList_SelectedIndexChanged);
            // 
            // npgsqlDataAdapter1
            // 
            this.npgsqlDataAdapter1.DeleteCommand = null;
            this.npgsqlDataAdapter1.InsertCommand = null;
            this.npgsqlDataAdapter1.SelectCommand = null;
            this.npgsqlDataAdapter1.UpdateCommand = null;
            // 
            // BusinessSearchGridView
            // 
            this.BusinessSearchGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BusinessSearchGridView.Location = new System.Drawing.Point(656, 64);
            this.BusinessSearchGridView.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.BusinessSearchGridView.Name = "BusinessSearchGridView";
            this.BusinessSearchGridView.RowHeadersWidth = 102;
            this.BusinessSearchGridView.Size = new System.Drawing.Size(2117, 1037);
            this.BusinessSearchGridView.TabIndex = 9;
            this.BusinessSearchGridView.SelectionChanged += new System.EventHandler(this.BusinessSearchGridView_SelectionChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(72, 978);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(490, 58);
            this.label5.TabIndex = 11;
            this.label5.Text = "Selected Categories:";
            // 
            // openButton
            // 
            this.openButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.openButton.Location = new System.Drawing.Point(88, 1285);
            this.openButton.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(504, 131);
            this.openButton.TabIndex = 12;
            this.openButton.Text = "Open Selected Business";
            this.openButton.UseVisualStyleBackColor = false;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // citiesBox
            // 
            this.citiesBox.FormattingEnabled = true;
            this.citiesBox.ItemHeight = 31;
            this.citiesBox.Location = new System.Drawing.Point(195, 155);
            this.citiesBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.citiesBox.Name = "citiesBox";
            this.citiesBox.Size = new System.Drawing.Size(391, 314);
            this.citiesBox.TabIndex = 14;
            this.citiesBox.SelectedIndexChanged += new System.EventHandler(this.citiesBox_SelectedIndexChanged);
            // 
            // zipcodeBox
            // 
            this.zipcodeBox.FormattingEnabled = true;
            this.zipcodeBox.ItemHeight = 31;
            this.zipcodeBox.Location = new System.Drawing.Point(195, 525);
            this.zipcodeBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.zipcodeBox.Name = "zipcodeBox";
            this.zipcodeBox.Size = new System.Drawing.Size(391, 252);
            this.zipcodeBox.TabIndex = 15;
            this.zipcodeBox.SelectedIndexChanged += new System.EventHandler(this.zipcodeBox_SelectedIndexChanged);
            // 
            // selectedCategoryBox
            // 
            this.selectedCategoryBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Chart;
            this.selectedCategoryBox.FormattingEnabled = true;
            this.selectedCategoryBox.ItemHeight = 31;
            this.selectedCategoryBox.Location = new System.Drawing.Point(75, 1044);
            this.selectedCategoryBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.selectedCategoryBox.Name = "selectedCategoryBox";
            this.selectedCategoryBox.Size = new System.Drawing.Size(511, 221);
            this.selectedCategoryBox.TabIndex = 16;
            this.selectedCategoryBox.SelectedIndexChanged += new System.EventHandler(this.selectedCategoryBox_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.BusinessSearchTab);
            this.tabControl1.Controls.Add(this.UserInfoTab);
            this.tabControl1.Location = new System.Drawing.Point(32, 29);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(3643, 1994);
            this.tabControl1.TabIndex = 17;
            // 
            // BusinessSearchTab
            // 
            this.BusinessSearchTab.Controls.Add(this.groupBox1);
            this.BusinessSearchTab.Controls.Add(this.BusinessSearchGridView);
            this.BusinessSearchTab.Controls.Add(this.selectedCategoryBox);
            this.BusinessSearchTab.Controls.Add(this.stateList);
            this.BusinessSearchTab.Controls.Add(this.zipcodeBox);
            this.BusinessSearchTab.Controls.Add(this.label1);
            this.BusinessSearchTab.Controls.Add(this.citiesBox);
            this.BusinessSearchTab.Controls.Add(this.label2);
            this.BusinessSearchTab.Controls.Add(this.openButton);
            this.BusinessSearchTab.Controls.Add(this.label3);
            this.BusinessSearchTab.Controls.Add(this.label5);
            this.BusinessSearchTab.Controls.Add(this.label4);
            this.BusinessSearchTab.Controls.Add(this.categoryList);
            this.BusinessSearchTab.Location = new System.Drawing.Point(10, 48);
            this.BusinessSearchTab.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.BusinessSearchTab.Name = "BusinessSearchTab";
            this.BusinessSearchTab.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.BusinessSearchTab.Size = new System.Drawing.Size(3623, 1936);
            this.BusinessSearchTab.TabIndex = 0;
            this.BusinessSearchTab.Text = "Business Search";
            this.BusinessSearchTab.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selectedBusinessOpenClose);
            this.groupBox1.Controls.Add(this.selectedBusinessAddress);
            this.groupBox1.Controls.Add(this.selectedBusinessName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(656, 1171);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox1.Size = new System.Drawing.Size(2117, 706);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Business:";
            // 
            // selectedBusinessOpenClose
            // 
            this.selectedBusinessOpenClose.AutoSize = true;
            this.selectedBusinessOpenClose.Location = new System.Drawing.Point(16, 281);
            this.selectedBusinessOpenClose.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.selectedBusinessOpenClose.Name = "selectedBusinessOpenClose";
            this.selectedBusinessOpenClose.Size = new System.Drawing.Size(447, 46);
            this.selectedBusinessOpenClose.TabIndex = 19;
            this.selectedBusinessOpenClose.Text = "Today: Opens / Closes";
            // 
            // selectedBusinessAddress
            // 
            this.selectedBusinessAddress.AutoSize = true;
            this.selectedBusinessAddress.Location = new System.Drawing.Point(16, 198);
            this.selectedBusinessAddress.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.selectedBusinessAddress.Name = "selectedBusinessAddress";
            this.selectedBusinessAddress.Size = new System.Drawing.Size(173, 46);
            this.selectedBusinessAddress.TabIndex = 18;
            this.selectedBusinessAddress.Text = "Address";
            // 
            // selectedBusinessName
            // 
            this.selectedBusinessName.AutoSize = true;
            this.selectedBusinessName.Location = new System.Drawing.Point(16, 114);
            this.selectedBusinessName.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.selectedBusinessName.Name = "selectedBusinessName";
            this.selectedBusinessName.Size = new System.Drawing.Size(312, 46);
            this.selectedBusinessName.TabIndex = 17;
            this.selectedBusinessName.Text = "Business Name";
            // 
            // UserInfoTab
            // 
            this.UserInfoTab.Controls.Add(this.UIUpdateButton);
            this.UserInfoTab.Controls.Add(this.UIEditButton);
            this.UserInfoTab.Controls.Add(this.UILongBox);
            this.UserInfoTab.Controls.Add(this.UILatBox);
            this.UserInfoTab.Controls.Add(this.UITLikesBox);
            this.UserInfoTab.Controls.Add(this.UITCountBox);
            this.UserInfoTab.Controls.Add(this.UIUsefulBox);
            this.UserInfoTab.Controls.Add(this.UICoolBox);
            this.UserInfoTab.Controls.Add(this.UIFunnyBox);
            this.UserInfoTab.Controls.Add(this.UIYelpBox);
            this.UserInfoTab.Controls.Add(this.UIFansBox);
            this.UserInfoTab.Controls.Add(this.UIStarsBox);
            this.UserInfoTab.Controls.Add(this.UINameBox);
            this.UserInfoTab.Controls.Add(this.UserInfoLongLabel);
            this.UserInfoTab.Controls.Add(this.UserInfoLatLabel);
            this.UserInfoTab.Controls.Add(this.UserInfoLocationLabel);
            this.UserInfoTab.Controls.Add(this.UserInfoTLikesLabel);
            this.UserInfoTab.Controls.Add(this.UserInfoTCountLabel);
            this.UserInfoTab.Controls.Add(this.UserInfoUsefulLabel);
            this.UserInfoTab.Controls.Add(this.UserInfoCoolLabel);
            this.UserInfoTab.Controls.Add(this.UserInfoFunnyLabel);
            this.UserInfoTab.Controls.Add(this.UserInfoVotesLabel);
            this.UserInfoTab.Controls.Add(this.UserInfoYelpLabel);
            this.UserInfoTab.Controls.Add(this.UserInfoFansLabel);
            this.UserInfoTab.Controls.Add(this.UserInfoStarsLabel);
            this.UserInfoTab.Controls.Add(this.UserInfoNameLabel);
            this.UserInfoTab.Controls.Add(this.UserInfoLabel);
            this.UserInfoTab.Controls.Add(this.label7);
            this.UserInfoTab.Controls.Add(this.UserNameTextBox);
            this.UserInfoTab.Controls.Add(this.UserIDBox);
            this.UserInfoTab.Controls.Add(this.label6);
            this.UserInfoTab.Controls.Add(this.FriendGrid);
            this.UserInfoTab.Controls.Add(this.FriendTipGrid);
            this.UserInfoTab.Location = new System.Drawing.Point(10, 48);
            this.UserInfoTab.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.UserInfoTab.Name = "UserInfoTab";
            this.UserInfoTab.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.UserInfoTab.Size = new System.Drawing.Size(3623, 1936);
            this.UserInfoTab.TabIndex = 1;
            this.UserInfoTab.Text = "User Info";
            this.UserInfoTab.UseVisualStyleBackColor = true;
            // 
            // UIUpdateButton
            // 
            this.UIUpdateButton.Location = new System.Drawing.Point(1267, 775);
            this.UIUpdateButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UIUpdateButton.Name = "UIUpdateButton";
            this.UIUpdateButton.Size = new System.Drawing.Size(125, 47);
            this.UIUpdateButton.TabIndex = 32;
            this.UIUpdateButton.Text = "Update";
            this.UIUpdateButton.UseVisualStyleBackColor = true;
            // 
            // UIEditButton
            // 
            this.UIEditButton.Location = new System.Drawing.Point(1267, 716);
            this.UIEditButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UIEditButton.Name = "UIEditButton";
            this.UIEditButton.Size = new System.Drawing.Size(125, 49);
            this.UIEditButton.TabIndex = 31;
            this.UIEditButton.Text = "Edit";
            this.UIEditButton.UseVisualStyleBackColor = true;
            // 
            // UILongBox
            // 
            this.UILongBox.FormattingEnabled = true;
            this.UILongBox.ItemHeight = 31;
            this.UILongBox.Location = new System.Drawing.Point(1005, 775);
            this.UILongBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UILongBox.Name = "UILongBox";
            this.UILongBox.Size = new System.Drawing.Size(236, 35);
            this.UILongBox.TabIndex = 30;
            // 
            // UILatBox
            // 
            this.UILatBox.FormattingEnabled = true;
            this.UILatBox.ItemHeight = 31;
            this.UILatBox.Location = new System.Drawing.Point(1005, 727);
            this.UILatBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UILatBox.Name = "UILatBox";
            this.UILatBox.Size = new System.Drawing.Size(236, 35);
            this.UILatBox.TabIndex = 29;
            // 
            // UITLikesBox
            // 
            this.UITLikesBox.FormattingEnabled = true;
            this.UITLikesBox.ItemHeight = 31;
            this.UITLikesBox.Location = new System.Drawing.Point(1096, 610);
            this.UITLikesBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UITLikesBox.Name = "UITLikesBox";
            this.UITLikesBox.Size = new System.Drawing.Size(183, 35);
            this.UITLikesBox.TabIndex = 28;
            // 
            // UITCountBox
            // 
            this.UITCountBox.FormattingEnabled = true;
            this.UITCountBox.ItemHeight = 31;
            this.UITCountBox.Location = new System.Drawing.Point(1096, 541);
            this.UITCountBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UITCountBox.Name = "UITCountBox";
            this.UITCountBox.Size = new System.Drawing.Size(183, 35);
            this.UITCountBox.TabIndex = 27;
            // 
            // UIUsefulBox
            // 
            this.UIUsefulBox.FormattingEnabled = true;
            this.UIUsefulBox.ItemHeight = 31;
            this.UIUsefulBox.Location = new System.Drawing.Point(1296, 465);
            this.UIUsefulBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UIUsefulBox.Name = "UIUsefulBox";
            this.UIUsefulBox.Size = new System.Drawing.Size(95, 35);
            this.UIUsefulBox.TabIndex = 26;
            // 
            // UICoolBox
            // 
            this.UICoolBox.FormattingEnabled = true;
            this.UICoolBox.ItemHeight = 31;
            this.UICoolBox.Location = new System.Drawing.Point(1163, 465);
            this.UICoolBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UICoolBox.Name = "UICoolBox";
            this.UICoolBox.Size = new System.Drawing.Size(95, 35);
            this.UICoolBox.TabIndex = 25;
            // 
            // UIFunnyBox
            // 
            this.UIFunnyBox.FormattingEnabled = true;
            this.UIFunnyBox.ItemHeight = 31;
            this.UIFunnyBox.Location = new System.Drawing.Point(1021, 465);
            this.UIFunnyBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UIFunnyBox.Name = "UIFunnyBox";
            this.UIFunnyBox.Size = new System.Drawing.Size(95, 35);
            this.UIFunnyBox.TabIndex = 24;
            // 
            // UIYelpBox
            // 
            this.UIYelpBox.FormattingEnabled = true;
            this.UIYelpBox.ItemHeight = 31;
            this.UIYelpBox.Location = new System.Drawing.Point(1107, 355);
            this.UIYelpBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UIYelpBox.Name = "UIYelpBox";
            this.UIYelpBox.Size = new System.Drawing.Size(287, 35);
            this.UIYelpBox.TabIndex = 23;
            // 
            // UIFansBox
            // 
            this.UIFansBox.FormattingEnabled = true;
            this.UIFansBox.ItemHeight = 31;
            this.UIFansBox.Location = new System.Drawing.Point(1285, 281);
            this.UIFansBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UIFansBox.Name = "UIFansBox";
            this.UIFansBox.Size = new System.Drawing.Size(108, 35);
            this.UIFansBox.TabIndex = 22;
            // 
            // UIStarsBox
            // 
            this.UIStarsBox.FormattingEnabled = true;
            this.UIStarsBox.ItemHeight = 31;
            this.UIStarsBox.Location = new System.Drawing.Point(1005, 284);
            this.UIStarsBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UIStarsBox.Name = "UIStarsBox";
            this.UIStarsBox.Size = new System.Drawing.Size(143, 35);
            this.UIStarsBox.TabIndex = 21;
            // 
            // UINameBox
            // 
            this.UINameBox.FormattingEnabled = true;
            this.UINameBox.ItemHeight = 31;
            this.UINameBox.Location = new System.Drawing.Point(1005, 205);
            this.UINameBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UINameBox.Name = "UINameBox";
            this.UINameBox.Size = new System.Drawing.Size(388, 35);
            this.UINameBox.TabIndex = 20;
            // 
            // UserInfoLongLabel
            // 
            this.UserInfoLongLabel.AutoSize = true;
            this.UserInfoLongLabel.Location = new System.Drawing.Point(923, 775);
            this.UserInfoLongLabel.Name = "UserInfoLongLabel";
            this.UserInfoLongLabel.Size = new System.Drawing.Size(78, 32);
            this.UserInfoLongLabel.TabIndex = 19;
            this.UserInfoLongLabel.Text = "long:";
            // 
            // UserInfoLatLabel
            // 
            this.UserInfoLatLabel.AutoSize = true;
            this.UserInfoLatLabel.Location = new System.Drawing.Point(949, 727);
            this.UserInfoLatLabel.Name = "UserInfoLatLabel";
            this.UserInfoLatLabel.Size = new System.Drawing.Size(54, 32);
            this.UserInfoLatLabel.TabIndex = 18;
            this.UserInfoLatLabel.Text = "lat:";
            // 
            // UserInfoLocationLabel
            // 
            this.UserInfoLocationLabel.AutoSize = true;
            this.UserInfoLocationLabel.Location = new System.Drawing.Point(891, 675);
            this.UserInfoLocationLabel.Name = "UserInfoLocationLabel";
            this.UserInfoLocationLabel.Size = new System.Drawing.Size(132, 32);
            this.UserInfoLocationLabel.TabIndex = 17;
            this.UserInfoLocationLabel.Text = "Location:";
            // 
            // UserInfoTLikesLabel
            // 
            this.UserInfoTLikesLabel.AutoSize = true;
            this.UserInfoTLikesLabel.Location = new System.Drawing.Point(891, 610);
            this.UserInfoTLikesLabel.Name = "UserInfoTLikesLabel";
            this.UserInfoTLikesLabel.Size = new System.Drawing.Size(208, 32);
            this.UserInfoTLikesLabel.TabIndex = 16;
            this.UserInfoTLikesLabel.Text = "Total Tip Likes:";
            // 
            // UserInfoTCountLabel
            // 
            this.UserInfoTCountLabel.AutoSize = true;
            this.UserInfoTCountLabel.Location = new System.Drawing.Point(891, 546);
            this.UserInfoTCountLabel.Name = "UserInfoTCountLabel";
            this.UserInfoTCountLabel.Size = new System.Drawing.Size(146, 32);
            this.UserInfoTCountLabel.TabIndex = 15;
            this.UserInfoTCountLabel.Text = "Tip Count:";
            // 
            // UserInfoUsefulLabel
            // 
            this.UserInfoUsefulLabel.AutoSize = true;
            this.UserInfoUsefulLabel.Location = new System.Drawing.Point(1288, 417);
            this.UserInfoUsefulLabel.Name = "UserInfoUsefulLabel";
            this.UserInfoUsefulLabel.Size = new System.Drawing.Size(104, 32);
            this.UserInfoUsefulLabel.TabIndex = 14;
            this.UserInfoUsefulLabel.Text = "Useful:";
            // 
            // UserInfoCoolLabel
            // 
            this.UserInfoCoolLabel.AutoSize = true;
            this.UserInfoCoolLabel.Location = new System.Drawing.Point(1157, 417);
            this.UserInfoCoolLabel.Name = "UserInfoCoolLabel";
            this.UserInfoCoolLabel.Size = new System.Drawing.Size(82, 32);
            this.UserInfoCoolLabel.TabIndex = 13;
            this.UserInfoCoolLabel.Text = "Cool:";
            // 
            // UserInfoFunnyLabel
            // 
            this.UserInfoFunnyLabel.AutoSize = true;
            this.UserInfoFunnyLabel.Location = new System.Drawing.Point(1016, 417);
            this.UserInfoFunnyLabel.Name = "UserInfoFunnyLabel";
            this.UserInfoFunnyLabel.Size = new System.Drawing.Size(102, 32);
            this.UserInfoFunnyLabel.TabIndex = 12;
            this.UserInfoFunnyLabel.Text = "Funny:";
            // 
            // UserInfoVotesLabel
            // 
            this.UserInfoVotesLabel.AutoSize = true;
            this.UserInfoVotesLabel.Location = new System.Drawing.Point(891, 417);
            this.UserInfoVotesLabel.Name = "UserInfoVotesLabel";
            this.UserInfoVotesLabel.Size = new System.Drawing.Size(96, 32);
            this.UserInfoVotesLabel.TabIndex = 11;
            this.UserInfoVotesLabel.Text = "Votes:";
            // 
            // UserInfoYelpLabel
            // 
            this.UserInfoYelpLabel.AutoSize = true;
            this.UserInfoYelpLabel.Location = new System.Drawing.Point(891, 358);
            this.UserInfoYelpLabel.Name = "UserInfoYelpLabel";
            this.UserInfoYelpLabel.Size = new System.Drawing.Size(199, 32);
            this.UserInfoYelpLabel.TabIndex = 10;
            this.UserInfoYelpLabel.Text = "Yelping Since:";
            // 
            // UserInfoFansLabel
            // 
            this.UserInfoFansLabel.AutoSize = true;
            this.UserInfoFansLabel.Location = new System.Drawing.Point(1192, 284);
            this.UserInfoFansLabel.Name = "UserInfoFansLabel";
            this.UserInfoFansLabel.Size = new System.Drawing.Size(86, 32);
            this.UserInfoFansLabel.TabIndex = 9;
            this.UserInfoFansLabel.Text = "Fans:";
            // 
            // UserInfoStarsLabel
            // 
            this.UserInfoStarsLabel.AutoSize = true;
            this.UserInfoStarsLabel.Location = new System.Drawing.Point(891, 284);
            this.UserInfoStarsLabel.Name = "UserInfoStarsLabel";
            this.UserInfoStarsLabel.Size = new System.Drawing.Size(89, 32);
            this.UserInfoStarsLabel.TabIndex = 8;
            this.UserInfoStarsLabel.Text = "Stars:";
            // 
            // UserInfoNameLabel
            // 
            this.UserInfoNameLabel.AutoSize = true;
            this.UserInfoNameLabel.Location = new System.Drawing.Point(891, 205);
            this.UserInfoNameLabel.Name = "UserInfoNameLabel";
            this.UserInfoNameLabel.Size = new System.Drawing.Size(98, 32);
            this.UserInfoNameLabel.TabIndex = 7;
            this.UserInfoNameLabel.Text = "Name:";
            // 
            // UserInfoLabel
            // 
            this.UserInfoLabel.AutoSize = true;
            this.UserInfoLabel.Location = new System.Drawing.Point(880, 117);
            this.UserInfoLabel.Name = "UserInfoLabel";
            this.UserInfoLabel.Size = new System.Drawing.Size(223, 32);
            this.UserInfoLabel.TabIndex = 6;
            this.UserInfoLabel.Text = "User Infromation";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(225, 32);
            this.label7.TabIndex = 5;
            this.label7.Text = "Set Current User";
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(56, 165);
            this.UserNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(572, 38);
            this.UserNameTextBox.TabIndex = 4;
            this.UserNameTextBox.TextChanged += new System.EventHandler(this.UserNameTextBox_TextChanged_1);
            // 
            // UserIDBox
            // 
            this.UserIDBox.FormattingEnabled = true;
            this.UserIDBox.ItemHeight = 31;
            this.UserIDBox.Location = new System.Drawing.Point(56, 241);
            this.UserIDBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UserIDBox.Name = "UserIDBox";
            this.UserIDBox.Size = new System.Drawing.Size(572, 624);
            this.UserIDBox.TabIndex = 3;
            this.UserIDBox.SelectedIndexChanged += new System.EventHandler(this.UserIDBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1476, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(329, 32);
            this.label6.TabIndex = 2;
            this.label6.Text = "Latest tips of my friends?";
            // 
            // FriendGrid
            // 
            this.FriendGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FriendGrid.Location = new System.Drawing.Point(56, 940);
            this.FriendGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FriendGrid.Name = "FriendGrid";
            this.FriendGrid.RowHeadersWidth = 102;
            this.FriendGrid.RowTemplate.Height = 40;
            this.FriendGrid.Size = new System.Drawing.Size(1343, 782);
            this.FriendGrid.TabIndex = 1;
            // 
            // FriendTipGrid
            // 
            this.FriendTipGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FriendTipGrid.Location = new System.Drawing.Point(1482, 107);
            this.FriendTipGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FriendTipGrid.Name = "FriendTipGrid";
            this.FriendTipGrid.RowHeadersWidth = 102;
            this.FriendTipGrid.RowTemplate.Height = 40;
            this.FriendTipGrid.Size = new System.Drawing.Size(2096, 1612);
            this.FriendTipGrid.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3789, 2118);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "MainWindow";
            this.Text = "Main Window - Milestone 2";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BusinessSearchGridView)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.BusinessSearchTab.ResumeLayout(false);
            this.BusinessSearchTab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.UserInfoTab.ResumeLayout(false);
            this.UserInfoTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FriendGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FriendTipGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox stateList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox categoryList;
        private Npgsql.NpgsqlDataAdapter npgsqlDataAdapter1;
        private System.Windows.Forms.DataGridView BusinessSearchGridView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.ListBox citiesBox;
        private System.Windows.Forms.ListBox zipcodeBox;
        private System.Windows.Forms.ListBox selectedCategoryBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage BusinessSearchTab;
        private System.Windows.Forms.TabPage UserInfoTab;
        private System.Windows.Forms.DataGridView FriendGrid;
        private System.Windows.Forms.DataGridView FriendTipGrid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox UserIDBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.Label UserInfoLatLabel;
        private System.Windows.Forms.Label UserInfoLocationLabel;
        private System.Windows.Forms.Label UserInfoTLikesLabel;
        private System.Windows.Forms.Label UserInfoTCountLabel;
        private System.Windows.Forms.Label UserInfoUsefulLabel;
        private System.Windows.Forms.Label UserInfoCoolLabel;
        private System.Windows.Forms.Label UserInfoFunnyLabel;
        private System.Windows.Forms.Label UserInfoVotesLabel;
        private System.Windows.Forms.Label UserInfoYelpLabel;
        private System.Windows.Forms.Label UserInfoFansLabel;
        private System.Windows.Forms.Label UserInfoStarsLabel;
        private System.Windows.Forms.Label UserInfoNameLabel;
        private System.Windows.Forms.Label UserInfoLabel;
        private System.Windows.Forms.Button UIUpdateButton;
        private System.Windows.Forms.Button UIEditButton;
        private System.Windows.Forms.ListBox UILongBox;
        private System.Windows.Forms.ListBox UILatBox;
        private System.Windows.Forms.ListBox UITLikesBox;
        private System.Windows.Forms.ListBox UITCountBox;
        private System.Windows.Forms.ListBox UIUsefulBox;
        private System.Windows.Forms.ListBox UICoolBox;
        private System.Windows.Forms.ListBox UIFunnyBox;
        private System.Windows.Forms.ListBox UIYelpBox;
        private System.Windows.Forms.ListBox UIFansBox;
        private System.Windows.Forms.ListBox UIStarsBox;
        private System.Windows.Forms.ListBox UINameBox;
        private System.Windows.Forms.Label UserInfoLongLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label selectedBusinessOpenClose;
        private System.Windows.Forms.Label selectedBusinessAddress;
        private System.Windows.Forms.Label selectedBusinessName;
    }
}

