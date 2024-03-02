
namespace RSSMap
{
    partial class ManageFeeds
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
            this.labelURL = new System.Windows.Forms.Label();
            this.textboxURL = new System.Windows.Forms.TextBox();
            this.buttonAddFeed = new System.Windows.Forms.Button();
            this.feedsPanel = new System.Windows.Forms.Panel();
            this.dataGridViewFeed = new System.Windows.Forms.DataGridView();
            this.buttonDeleteFeed = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.feedsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFeed)).BeginInit();
            this.SuspendLayout();
            // 
            // ManageUrlLable
            // 
            this.labelURL.AutoSize = true;
            this.labelURL.Location = new System.Drawing.Point(12, 20);
            this.labelURL.Name = "ManageUrlLable";
            this.labelURL.Size = new System.Drawing.Size(59, 13);
            this.labelURL.TabIndex = 7;
            this.labelURL.Text = "Feed URL:";
            // 
            // ManageURLTextBox
            // 
            this.textboxURL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxURL.Location = new System.Drawing.Point(83, 17);
            this.textboxURL.Name = "ManageURLTextBox";
            this.textboxURL.Size = new System.Drawing.Size(439, 20);
            this.textboxURL.TabIndex = 9;
            // 
            // ManageFeedAddButton
            // 
            this.buttonAddFeed.Location = new System.Drawing.Point(528, 15);
            this.buttonAddFeed.Name = "ManageFeedAddButton";
            this.buttonAddFeed.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFeed.TabIndex = 11;
            this.buttonAddFeed.Text = "Add";
            this.buttonAddFeed.UseVisualStyleBackColor = true;
            this.buttonAddFeed.Click += new System.EventHandler(this.ManageFeedAddButton_Click);
            // 
            // panel1
            // 
            this.feedsPanel.Controls.Add(this.buttonDeleteFeed);
            this.feedsPanel.Controls.Add(this.dataGridViewFeed);
            this.feedsPanel.Location = new System.Drawing.Point(15, 57);
            this.feedsPanel.Name = "panel1";
            this.feedsPanel.Size = new System.Drawing.Size(588, 304);
            this.feedsPanel.TabIndex = 12;
            // 
            // SubscriptionDataGridView
            // 
            this.dataGridViewFeed.AllowUserToAddRows = false;
            this.dataGridViewFeed.AllowUserToDeleteRows = false;
            this.dataGridViewFeed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewFeed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFeed.Location = new System.Drawing.Point(-58, 3);
            this.dataGridViewFeed.Name = "SubscriptionDataGridView";
            this.dataGridViewFeed.Size = new System.Drawing.Size(643, 269);
            this.dataGridViewFeed.TabIndex = 1;
            // 
            // ManageDeleteFeedButton
            // 
            this.buttonDeleteFeed.Location = new System.Drawing.Point(244, 278);
            this.buttonDeleteFeed.Name = "ManageDeleteFeedButton";
            this.buttonDeleteFeed.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteFeed.TabIndex = 2;
            this.buttonDeleteFeed.Text = "Delete";
            this.buttonDeleteFeed.UseVisualStyleBackColor = true;
            this.buttonDeleteFeed.Click += new System.EventHandler(this.ManageDeleteFeedButton_Click);
            // 
            // ManageAcceptButton
            // 
            this.buttonAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAccept.Location = new System.Drawing.Point(259, 373);
            this.buttonAccept.Name = "ManageAcceptButton";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 13;
            this.buttonAccept.Text = "Done";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.ManageAcceptButton_Click);
            // 
            // ManageFeeds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 408);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.feedsPanel);
            this.Controls.Add(this.buttonAddFeed);
            this.Controls.Add(this.textboxURL);
            this.Controls.Add(this.labelURL);
            this.Name = "ManageFeeds";
            this.Text = "ManageFeeds";
            this.feedsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelURL;
        private System.Windows.Forms.TextBox textboxURL;
        private System.Windows.Forms.Button buttonAddFeed;
        private System.Windows.Forms.Panel feedsPanel;
        private System.Windows.Forms.Button buttonDeleteFeed;
        private System.Windows.Forms.DataGridView dataGridViewFeed;
        private System.Windows.Forms.Button buttonAccept;
    }
}