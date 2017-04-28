namespace OpenSubSearch
{
    partial class Form1
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("");
            this.button1 = new System.Windows.Forms.Button();
            this.meta_title = new System.Windows.Forms.TextBox();
            this.searchNameButton = new System.Windows.Forms.Button();
            this.searchHashButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.meta_season = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.meta_episode = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.meta_year = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.hashProgress = new System.Windows.Forms.ProgressBar();
            this.listView1 = new System.Windows.Forms.ListView();
            this.language = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.year = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rating = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.searchWorker = new System.ComponentModel.BackgroundWorker();
            this.includeReleaseGroupCB = new System.Windows.Forms.CheckBox();
            this.downloadButton = new System.Windows.Forms.Button();
            this.searchCoumtLabel = new System.Windows.Forms.Label();
            this.meta_group = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.meta_quality = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.languageCBB = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.includeQualityCB = new System.Windows.Forms.CheckBox();
            this.includeYearCB = new System.Windows.Forms.CheckBox();
            this.subPageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(595, 487);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.openFile_Click);
            // 
            // meta_title
            // 
            this.meta_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.meta_title.Location = new System.Drawing.Point(104, 12);
            this.meta_title.Name = "meta_title";
            this.meta_title.Size = new System.Drawing.Size(410, 20);
            this.meta_title.TabIndex = 1;
            this.meta_title.TextChanged += new System.EventHandler(this.meta_title_TextChanged);
            // 
            // searchNameButton
            // 
            this.searchNameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchNameButton.Enabled = false;
            this.searchNameButton.Location = new System.Drawing.Point(520, 9);
            this.searchNameButton.Name = "searchNameButton";
            this.searchNameButton.Size = new System.Drawing.Size(150, 23);
            this.searchNameButton.TabIndex = 2;
            this.searchNameButton.Text = "Search by Name";
            this.searchNameButton.UseVisualStyleBackColor = true;
            this.searchNameButton.Click += new System.EventHandler(this.searchName_Click);
            // 
            // searchHashButton
            // 
            this.searchHashButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchHashButton.Enabled = false;
            this.searchHashButton.Location = new System.Drawing.Point(520, 38);
            this.searchHashButton.Name = "searchHashButton";
            this.searchHashButton.Size = new System.Drawing.Size(150, 23);
            this.searchHashButton.TabIndex = 3;
            this.searchHashButton.Text = "Search by Hash";
            this.searchHashButton.UseVisualStyleBackColor = true;
            this.searchHashButton.Click += new System.EventHandler(this.searchHash_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Season:";
            // 
            // meta_season
            // 
            this.meta_season.Location = new System.Drawing.Point(104, 40);
            this.meta_season.Name = "meta_season";
            this.meta_season.Size = new System.Drawing.Size(76, 20);
            this.meta_season.TabIndex = 6;
            this.meta_season.TextChanged += new System.EventHandler(this.meta_season_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Episode:";
            // 
            // meta_episode
            // 
            this.meta_episode.Location = new System.Drawing.Point(104, 66);
            this.meta_episode.Name = "meta_episode";
            this.meta_episode.Size = new System.Drawing.Size(76, 20);
            this.meta_episode.TabIndex = 8;
            this.meta_episode.TextChanged += new System.EventHandler(this.meta_episode_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // meta_year
            // 
            this.meta_year.Location = new System.Drawing.Point(240, 40);
            this.meta_year.Name = "meta_year";
            this.meta_year.Size = new System.Drawing.Size(76, 20);
            this.meta_year.TabIndex = 10;
            this.meta_year.TextChanged += new System.EventHandler(this.meta_year_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Year:";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // hashProgress
            // 
            this.hashProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hashProgress.Location = new System.Drawing.Point(12, 487);
            this.hashProgress.Name = "hashProgress";
            this.hashProgress.Size = new System.Drawing.Size(577, 23);
            this.hashProgress.TabIndex = 11;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.language,
            this.year,
            this.title,
            this.rating});
            this.listView1.FullRowSelect = true;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.listView1.Location = new System.Drawing.Point(12, 146);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(658, 335);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // language
            // 
            this.language.Text = "Language";
            // 
            // year
            // 
            this.year.Text = "Year";
            // 
            // title
            // 
            this.title.Text = "Title";
            // 
            // rating
            // 
            this.rating.Text = "Rating";
            // 
            // searchWorker
            // 
            this.searchWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.searchWorker_DoWork);
            this.searchWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.searchWorker_RunWorkerCompleted);
            // 
            // includeReleaseGroupCB
            // 
            this.includeReleaseGroupCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.includeReleaseGroupCB.AutoSize = true;
            this.includeReleaseGroupCB.Location = new System.Drawing.Point(499, 96);
            this.includeReleaseGroupCB.Name = "includeReleaseGroupCB";
            this.includeReleaseGroupCB.Size = new System.Drawing.Size(15, 14);
            this.includeReleaseGroupCB.TabIndex = 14;
            this.includeReleaseGroupCB.UseVisualStyleBackColor = true;
            // 
            // downloadButton
            // 
            this.downloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadButton.Enabled = false;
            this.downloadButton.Location = new System.Drawing.Point(520, 90);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(150, 23);
            this.downloadButton.TabIndex = 15;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.download_Click);
            // 
            // searchCoumtLabel
            // 
            this.searchCoumtLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchCoumtLabel.AutoSize = true;
            this.searchCoumtLabel.Location = new System.Drawing.Point(585, 126);
            this.searchCoumtLabel.Name = "searchCoumtLabel";
            this.searchCoumtLabel.Size = new System.Drawing.Size(85, 17);
            this.searchCoumtLabel.TabIndex = 16;
            this.searchCoumtLabel.Text = "Found: 0 results";
            this.searchCoumtLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.searchCoumtLabel.UseCompatibleTextRendering = true;
            // 
            // meta_group
            // 
            this.meta_group.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.meta_group.Location = new System.Drawing.Point(104, 93);
            this.meta_group.Name = "meta_group";
            this.meta_group.Size = new System.Drawing.Size(389, 20);
            this.meta_group.TabIndex = 18;
            this.meta_group.TextChanged += new System.EventHandler(this.meta_group_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Release Group:";
            this.label5.UseCompatibleTextRendering = true;
            // 
            // meta_quality
            // 
            this.meta_quality.Location = new System.Drawing.Point(240, 66);
            this.meta_quality.Name = "meta_quality";
            this.meta_quality.Size = new System.Drawing.Size(76, 20);
            this.meta_quality.TabIndex = 20;
            this.meta_quality.TextChanged += new System.EventHandler(this.meta_quality_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(186, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Quality:";
            this.label6.UseCompatibleTextRendering = true;
            // 
            // languageCBB
            // 
            this.languageCBB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageCBB.FormattingEnabled = true;
            this.languageCBB.Location = new System.Drawing.Point(104, 119);
            this.languageCBB.Name = "languageCBB";
            this.languageCBB.Size = new System.Drawing.Size(212, 21);
            this.languageCBB.TabIndex = 21;
            this.languageCBB.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "Language:";
            this.label7.UseCompatibleTextRendering = true;
            // 
            // includeQualityCB
            // 
            this.includeQualityCB.AutoSize = true;
            this.includeQualityCB.Location = new System.Drawing.Point(322, 70);
            this.includeQualityCB.Name = "includeQualityCB";
            this.includeQualityCB.Size = new System.Drawing.Size(15, 14);
            this.includeQualityCB.TabIndex = 23;
            this.includeQualityCB.UseVisualStyleBackColor = true;
            // 
            // includeYearCB
            // 
            this.includeYearCB.AutoSize = true;
            this.includeYearCB.Checked = true;
            this.includeYearCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeYearCB.Location = new System.Drawing.Point(322, 43);
            this.includeYearCB.Name = "includeYearCB";
            this.includeYearCB.Size = new System.Drawing.Size(15, 14);
            this.includeYearCB.TabIndex = 24;
            this.includeYearCB.UseVisualStyleBackColor = true;
            // 
            // subPageButton
            // 
            this.subPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.subPageButton.Enabled = false;
            this.subPageButton.Location = new System.Drawing.Point(520, 65);
            this.subPageButton.Name = "subPageButton";
            this.subPageButton.Size = new System.Drawing.Size(150, 23);
            this.subPageButton.TabIndex = 25;
            this.subPageButton.Text = "Subtitle Page";
            this.subPageButton.UseVisualStyleBackColor = true;
            this.subPageButton.Click += new System.EventHandler(this.subPageButton_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(682, 522);
            this.Controls.Add(this.subPageButton);
            this.Controls.Add(this.includeYearCB);
            this.Controls.Add(this.includeQualityCB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.languageCBB);
            this.Controls.Add(this.meta_quality);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.meta_group);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.searchCoumtLabel);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.includeReleaseGroupCB);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.hashProgress);
            this.Controls.Add(this.meta_year);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.meta_episode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.meta_season);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchHashButton);
            this.Controls.Add(this.searchNameButton);
            this.Controls.Add(this.meta_title);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Open Sub Search";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox meta_title;
        private System.Windows.Forms.Button searchNameButton;
        private System.Windows.Forms.Button searchHashButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox meta_season;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox meta_episode;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox meta_year;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar hashProgress;
        private System.Windows.Forms.ListView listView1;
        private System.ComponentModel.BackgroundWorker searchWorker;
        private System.Windows.Forms.CheckBox includeReleaseGroupCB;
        private System.Windows.Forms.ColumnHeader language;
        private System.Windows.Forms.ColumnHeader title;
        private System.Windows.Forms.ColumnHeader year;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Label searchCoumtLabel;
        private System.Windows.Forms.TextBox meta_group;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox meta_quality;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox languageCBB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox includeQualityCB;
        private System.Windows.Forms.CheckBox includeYearCB;
        private System.Windows.Forms.ColumnHeader rating;
        private System.Windows.Forms.Button subPageButton;
    }
}

