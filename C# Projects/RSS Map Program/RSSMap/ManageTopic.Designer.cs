
namespace RSSMap
{
    partial class ManageTopic
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDeleteKeywords = new System.Windows.Forms.Button();
            this.checkedListBoxKeywords = new System.Windows.Forms.CheckedListBox();
            this.buttonDeleteTopic = new System.Windows.Forms.Button();
            this.textBoxKeyword = new System.Windows.Forms.TextBox();
            this.labelKeyword = new System.Windows.Forms.Label();
            this.buttonNewTopic = new System.Windows.Forms.Button();
            this.textBoxTopic = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.comboBoxTopics = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddKeyword = new System.Windows.Forms.Button();
            this.buttonDone = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonDeleteKeywords);
            this.panel1.Controls.Add(this.checkedListBoxKeywords);
            this.panel1.Location = new System.Drawing.Point(19, 159);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 290);
            this.panel1.TabIndex = 18;
            // 
            // buttonDeleteKeywords
            // 
            this.buttonDeleteKeywords.Location = new System.Drawing.Point(13, 252);
            this.buttonDeleteKeywords.Name = "buttonDeleteKeywords";
            this.buttonDeleteKeywords.Size = new System.Drawing.Size(370, 23);
            this.buttonDeleteKeywords.TabIndex = 1;
            this.buttonDeleteKeywords.Text = "Delete Selected Keyword";
            this.buttonDeleteKeywords.UseVisualStyleBackColor = true;
            this.buttonDeleteKeywords.Click += new System.EventHandler(this.buttonDeleteKeywords_Click);
            // 
            // checkedListBoxKeywords
            // 
            this.checkedListBoxKeywords.FormattingEnabled = true;
            this.checkedListBoxKeywords.Location = new System.Drawing.Point(13, 4);
            this.checkedListBoxKeywords.Name = "checkedListBoxKeywords";
            this.checkedListBoxKeywords.Size = new System.Drawing.Size(370, 229);
            this.checkedListBoxKeywords.TabIndex = 0;
            // 
            // buttonDeleteTopic
            // 
            this.buttonDeleteTopic.Location = new System.Drawing.Point(323, 65);
            this.buttonDeleteTopic.Name = "buttonDeleteTopic";
            this.buttonDeleteTopic.Size = new System.Drawing.Size(93, 23);
            this.buttonDeleteTopic.TabIndex = 2;
            this.buttonDeleteTopic.Text = "Delete Topic";
            this.buttonDeleteTopic.UseVisualStyleBackColor = true;
            this.buttonDeleteTopic.Click += new System.EventHandler(this.buttonDeleteTopic_Click);
            // 
            // textBoxKeyword
            // 
            this.textBoxKeyword.Location = new System.Drawing.Point(104, 108);
            this.textBoxKeyword.Name = "textBoxKeyword";
            this.textBoxKeyword.Size = new System.Drawing.Size(213, 20);
            this.textBoxKeyword.TabIndex = 17;
            // 
            // labelKeyword
            // 
            this.labelKeyword.AutoSize = true;
            this.labelKeyword.Location = new System.Drawing.Point(18, 111);
            this.labelKeyword.Name = "labelKeyword";
            this.labelKeyword.Size = new System.Drawing.Size(76, 13);
            this.labelKeyword.TabIndex = 16;
            this.labelKeyword.Text = "New Keyword:";
            // 
            // buttonNewTopic
            // 
            this.buttonNewTopic.Location = new System.Drawing.Point(323, 24);
            this.buttonNewTopic.Name = "buttonNewTopic";
            this.buttonNewTopic.Size = new System.Drawing.Size(93, 23);
            this.buttonNewTopic.TabIndex = 15;
            this.buttonNewTopic.Text = "Add Topic";
            this.buttonNewTopic.UseVisualStyleBackColor = true;
            this.buttonNewTopic.Click += new System.EventHandler(this.buttonNewTopic_Click);
            // 
            // textBoxTopic
            // 
            this.textBoxTopic.Location = new System.Drawing.Point(104, 26);
            this.textBoxTopic.Name = "textBoxTopic";
            this.textBoxTopic.Size = new System.Drawing.Size(213, 20);
            this.textBoxTopic.TabIndex = 14;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(32, 29);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(62, 13);
            this.labelName.TabIndex = 13;
            this.labelName.Text = "New Topic:";
            // 
            // comboBoxTopics
            // 
            this.comboBoxTopics.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTopics.FormattingEnabled = true;
            this.comboBoxTopics.Location = new System.Drawing.Point(104, 67);
            this.comboBoxTopics.Name = "comboBoxTopics";
            this.comboBoxTopics.Size = new System.Drawing.Size(213, 21);
            this.comboBoxTopics.TabIndex = 12;
            this.comboBoxTopics.SelectedIndexChanged += new System.EventHandler(this.selectedIndex_Changed);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(88, 281);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(206, 20);
            this.textBox1.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Select Topic";
            // 
            // buttonAddKeyword
            // 
            this.buttonAddKeyword.Location = new System.Drawing.Point(323, 108);
            this.buttonAddKeyword.Name = "buttonAddKeyword";
            this.buttonAddKeyword.Size = new System.Drawing.Size(93, 23);
            this.buttonAddKeyword.TabIndex = 19;
            this.buttonAddKeyword.Text = "Add Keyword";
            this.buttonAddKeyword.UseVisualStyleBackColor = true;
            this.buttonAddKeyword.Click += new System.EventHandler(this.buttonAddKeyword_Click);
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(173, 459);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(75, 23);
            this.buttonDone.TabIndex = 11;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // ManageTopic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 494);
            this.Controls.Add(this.buttonDeleteTopic);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxKeyword);
            this.Controls.Add(this.labelKeyword);
            this.Controls.Add(this.buttonNewTopic);
            this.Controls.Add(this.textBoxTopic);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.comboBoxTopics);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAddKeyword);
            this.Name = "ManageTopic";
            this.Text = "ManageTopic";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDeleteTopic;
        private System.Windows.Forms.Button buttonDeleteKeywords;
        private System.Windows.Forms.CheckedListBox checkedListBoxKeywords;
        private System.Windows.Forms.TextBox textBoxKeyword;
        private System.Windows.Forms.Label labelKeyword;
        private System.Windows.Forms.Button buttonNewTopic;
        private System.Windows.Forms.TextBox textBoxTopic;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.ComboBox comboBoxTopics;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddKeyword;
        private System.Windows.Forms.Button buttonDone;
    }
}