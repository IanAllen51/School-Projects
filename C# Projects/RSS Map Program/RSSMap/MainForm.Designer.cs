
namespace RSSMap
{
    partial class MainForm
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.MainTabPage = new System.Windows.Forms.TabPage();
            this.ArticleDataGridView = new System.Windows.Forms.DataGridView();
            this.MapTabPage = new System.Windows.Forms.TabPage();
            this.BrowserTabPage = new System.Windows.Forms.TabPage();
            this.WebBrowser = new System.Windows.Forms.WebBrowser();
            this.FeedTopicTabControl = new System.Windows.Forms.TabControl();
            this.FeedTabPage = new System.Windows.Forms.TabPage();
            this.FeedTreeView = new System.Windows.Forms.TreeView();
            this.TopicTabPage = new System.Windows.Forms.TabPage();
            this.TopicTreeView = new System.Windows.Forms.TreeView();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageFeedsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageTopicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setRefreshRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapElementHost = new System.Windows.Forms.Integration.ElementHost();
            this.mapControl = new RSSMap.MapControl();
            this.TabControl.SuspendLayout();
            this.MainTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleDataGridView)).BeginInit();
            this.MapTabPage.SuspendLayout();
            this.BrowserTabPage.SuspendLayout();
            this.FeedTopicTabControl.SuspendLayout();
            this.FeedTabPage.SuspendLayout();
            this.TopicTabPage.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.MainTabPage);
            this.TabControl.Controls.Add(this.MapTabPage);
            this.TabControl.Controls.Add(this.BrowserTabPage);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.TabControl.Location = new System.Drawing.Point(190, 24);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.ShowToolTips = true;
            this.TabControl.Size = new System.Drawing.Size(548, 549);
            this.TabControl.TabIndex = 0;
            // 
            // MainTabPage
            // 
            this.MainTabPage.Controls.Add(this.ArticleDataGridView);
            this.MainTabPage.Location = new System.Drawing.Point(4, 22);
            this.MainTabPage.Name = "MainTabPage";
            this.MainTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MainTabPage.Size = new System.Drawing.Size(540, 523);
            this.MainTabPage.TabIndex = 1;
            this.MainTabPage.Text = "Main";
            this.MainTabPage.UseVisualStyleBackColor = true;
            // 
            // ArticleDataGridView
            // 
            this.ArticleDataGridView.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.ArticleDataGridView.AllowUserToAddRows = false;
            this.ArticleDataGridView.AllowUserToDeleteRows = false;
            this.ArticleDataGridView.AllowUserToResizeRows = false;
            this.ArticleDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ArticleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ArticleDataGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ArticleDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ArticleDataGridView.Location = new System.Drawing.Point(3, 3);
            this.ArticleDataGridView.MultiSelect = false;
            this.ArticleDataGridView.Name = "ArticleDataGridView";
            this.ArticleDataGridView.Size = new System.Drawing.Size(534, 517);
            this.ArticleDataGridView.TabIndex = 1;
            this.ArticleDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ArticleDataGridView_CellContentClick);
            // 
            // MapTabPage
            // 
            this.MapTabPage.Controls.Add(this.mapElementHost);
            this.MapTabPage.Location = new System.Drawing.Point(4, 22);
            this.MapTabPage.Name = "MapTabPage";
            this.MapTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MapTabPage.Size = new System.Drawing.Size(540, 523);
            this.MapTabPage.TabIndex = 2;
            this.MapTabPage.Text = "Map";
            this.MapTabPage.UseVisualStyleBackColor = true;
            // 
            // BrowserTabPage
            // 
            this.BrowserTabPage.Controls.Add(this.WebBrowser);
            this.BrowserTabPage.Location = new System.Drawing.Point(4, 22);
            this.BrowserTabPage.Name = "BrowserTabPage";
            this.BrowserTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.BrowserTabPage.Size = new System.Drawing.Size(540, 523);
            this.BrowserTabPage.TabIndex = 3;
            this.BrowserTabPage.Text = "Browser";
            this.BrowserTabPage.UseVisualStyleBackColor = true;
            // 
            // WebBrowser
            // 
            this.WebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebBrowser.Location = new System.Drawing.Point(3, 3);
            this.WebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBrowser.Name = "WebBrowser";
            this.WebBrowser.ScriptErrorsSuppressed = true;
            this.WebBrowser.Size = new System.Drawing.Size(534, 517);
            this.WebBrowser.TabIndex = 1;
            // 
            // FeedTopicTabControl
            // 
            this.FeedTopicTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FeedTopicTabControl.Controls.Add(this.FeedTabPage);
            this.FeedTopicTabControl.Controls.Add(this.TopicTabPage);
            this.FeedTopicTabControl.Location = new System.Drawing.Point(12, 24);
            this.FeedTopicTabControl.Name = "FeedTopicTabControl";
            this.FeedTopicTabControl.SelectedIndex = 0;
            this.FeedTopicTabControl.Size = new System.Drawing.Size(176, 549);
            this.FeedTopicTabControl.TabIndex = 1;
            this.FeedTopicTabControl.SelectedIndexChanged += new System.EventHandler(this.FeedTopicTabControl_SelectedIndexChanged);
            // 
            // FeedTabPage
            // 
            this.FeedTabPage.Controls.Add(this.FeedTreeView);
            this.FeedTabPage.Location = new System.Drawing.Point(4, 22);
            this.FeedTabPage.Name = "FeedTabPage";
            this.FeedTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.FeedTabPage.Size = new System.Drawing.Size(168, 523);
            this.FeedTabPage.TabIndex = 0;
            this.FeedTabPage.Text = "Feeds";
            this.FeedTabPage.UseVisualStyleBackColor = true;
            // 
            // FeedTreeView
            // 
            this.FeedTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.FeedTreeView.Location = new System.Drawing.Point(3, 3);
            this.FeedTreeView.Name = "FeedTreeView";
            this.FeedTreeView.Size = new System.Drawing.Size(169, 517);
            this.FeedTreeView.TabIndex = 0;
            this.FeedTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FeedTreeView_AfterSelect);
            // 
            // TopicTabPage
            // 
            this.TopicTabPage.Controls.Add(this.TopicTreeView);
            this.TopicTabPage.Location = new System.Drawing.Point(4, 22);
            this.TopicTabPage.Name = "TopicTabPage";
            this.TopicTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.TopicTabPage.Size = new System.Drawing.Size(168, 523);
            this.TopicTabPage.TabIndex = 1;
            this.TopicTabPage.Text = "Topics";
            this.TopicTabPage.UseVisualStyleBackColor = true;
            // 
            // TopicTreeView
            // 
            this.TopicTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopicTreeView.Location = new System.Drawing.Point(3, 3);
            this.TopicTreeView.Name = "TopicTreeView";
            this.TopicTreeView.Size = new System.Drawing.Size(162, 517);
            this.TopicTreeView.TabIndex = 0;
            this.TopicTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TopicTreeView_AfterSelect);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.manageToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(738, 24);
            this.mainMenuStrip.TabIndex = 6;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadXMLToolStripMenuItem,
            this.saveXMLToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // loadXMLToolStripMenuItem
            // 
            this.loadXMLToolStripMenuItem.Name = "loadXMLToolStripMenuItem";
            this.loadXMLToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.loadXMLToolStripMenuItem.Text = "Load XML";
            this.loadXMLToolStripMenuItem.Click += new System.EventHandler(this.loadXMLToolStripMenuItem_Click);
            // 
            // saveXMLToolStripMenuItem
            // 
            this.saveXMLToolStripMenuItem.Name = "saveXMLToolStripMenuItem";
            this.saveXMLToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.saveXMLToolStripMenuItem.Text = "Save XML";
            this.saveXMLToolStripMenuItem.Click += new System.EventHandler(this.saveXMLToolStripMenuItem_Click);
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageFeedsToolStripMenuItem,
            this.manageTopicsToolStripMenuItem});
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.manageToolStripMenuItem.Text = "Manage";
            // 
            // manageFeedsToolStripMenuItem
            // 
            this.manageFeedsToolStripMenuItem.Name = "manageFeedsToolStripMenuItem";
            this.manageFeedsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.manageFeedsToolStripMenuItem.Text = "Manage Feeds";
            this.manageFeedsToolStripMenuItem.Click += new System.EventHandler(this.manageFeedsToolStripMenuItem_Click);
            // 
            // manageTopicsToolStripMenuItem
            // 
            this.manageTopicsToolStripMenuItem.Name = "manageTopicsToolStripMenuItem";
            this.manageTopicsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.manageTopicsToolStripMenuItem.Text = "Manage Topics";
            this.manageTopicsToolStripMenuItem.Click += new System.EventHandler(this.manageTopicsToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setRefreshRateToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // setRefreshRateToolStripMenuItem
            // 
            this.setRefreshRateToolStripMenuItem.Name = "setRefreshRateToolStripMenuItem";
            this.setRefreshRateToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.setRefreshRateToolStripMenuItem.Text = "Set Refresh Rate";
            this.setRefreshRateToolStripMenuItem.Click += new System.EventHandler(this.setRefreshRateToolStripMenuItem_Click);
            // 
            // mapElementHost
            // 
            this.mapElementHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapElementHost.Location = new System.Drawing.Point(3, 3);
            this.mapElementHost.Name = "mapElementHost";
            this.mapElementHost.Size = new System.Drawing.Size(534, 517);
            this.mapElementHost.TabIndex = 0;
            this.mapElementHost.Text = "elementHost1";
            this.mapElementHost.Child = this.mapControl;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 573);
            this.Controls.Add(this.FeedTopicTabControl);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "RSS Map";
            this.TabControl.ResumeLayout(false);
            this.MainTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ArticleDataGridView)).EndInit();
            this.MapTabPage.ResumeLayout(false);
            this.BrowserTabPage.ResumeLayout(false);
            this.FeedTopicTabControl.ResumeLayout(false);
            this.FeedTabPage.ResumeLayout(false);
            this.TopicTabPage.ResumeLayout(false);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage MainTabPage;
        private System.Windows.Forms.TabPage MapTabPage;
        private System.Windows.Forms.TabPage BrowserTabPage;
        private System.Windows.Forms.DataGridView ArticleDataGridView;
        private System.Windows.Forms.TabControl FeedTopicTabControl;
        private System.Windows.Forms.TabPage FeedTabPage;
        private System.Windows.Forms.TreeView FeedTreeView;
        private System.Windows.Forms.TabPage TopicTabPage;
        private System.Windows.Forms.TreeView TopicTreeView;
        private System.Windows.Forms.Integration.ElementHost mapElementHost;
        private MapControl mapControl;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageFeedsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageTopicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setRefreshRateToolStripMenuItem;
        private System.Windows.Forms.WebBrowser WebBrowser;
    }
}