namespace WaifuWallpaperSetter_GUI
{
    partial class WaifuWallpaperSetter
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaifuWallpaperSetter));
            groupBox1 = new GroupBox();
            TXT_ExcludedFiles = new TextBox();
            label7 = new Label();
            TXT_IncludedFiles = new TextBox();
            label8 = new Label();
            label6 = new Label();
            CBX_Orientation = new ComboBox();
            label5 = new Label();
            CBX_OrderBy = new ComboBox();
            label4 = new Label();
            CHK_OnlyGif = new CheckBox();
            label3 = new Label();
            CHK_NsfwResults = new CheckBox();
            TXT_ExcludedTags = new TextBox();
            label2 = new Label();
            TXT_IncludedTags = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            BTN_Open = new Button();
            label11 = new Label();
            CBX_WallpaperFit = new ComboBox();
            TXT_ImageLocation = new TextBox();
            label9 = new Label();
            groupBox3 = new GroupBox();
            label12 = new Label();
            CHK_OnlyFavorites = new CheckBox();
            TXT_Token = new TextBox();
            label14 = new Label();
            BTN_DownloadSetWallpaper = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(TXT_ExcludedFiles);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(TXT_IncludedFiles);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(CBX_Orientation);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(CBX_OrderBy);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(CHK_OnlyGif);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(CHK_NsfwResults);
            groupBox1.Controls.Add(TXT_ExcludedTags);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(TXT_IncludedTags);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(9, 1);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(368, 259);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Search Filters";
            // 
            // TXT_ExcludedFiles
            // 
            TXT_ExcludedFiles.Location = new Point(91, 107);
            TXT_ExcludedFiles.Name = "TXT_ExcludedFiles";
            TXT_ExcludedFiles.Size = new Size(259, 23);
            TXT_ExcludedFiles.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 110);
            label7.Name = "label7";
            label7.Size = new Size(77, 15);
            label7.TabIndex = 7;
            label7.Text = "Exclude Files:";
            // 
            // TXT_IncludedFiles
            // 
            TXT_IncludedFiles.Location = new Point(91, 78);
            TXT_IncludedFiles.Name = "TXT_IncludedFiles";
            TXT_IncludedFiles.Size = new Size(259, 23);
            TXT_IncludedFiles.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(10, 81);
            label8.Name = "label8";
            label8.Size = new Size(75, 15);
            label8.TabIndex = 5;
            label8.Text = "Include Files:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 169);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 11;
            label6.Text = "Orientation:";
            // 
            // CBX_Orientation
            // 
            CBX_Orientation.DropDownStyle = ComboBoxStyle.DropDownList;
            CBX_Orientation.FormattingEnabled = true;
            CBX_Orientation.Items.AddRange(new object[] { "No Preference", "Landscape", "Portrait" });
            CBX_Orientation.Location = new Point(91, 165);
            CBX_Orientation.Name = "CBX_Orientation";
            CBX_Orientation.Size = new Size(259, 23);
            CBX_Orientation.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 140);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 9;
            label5.Text = "Order By:";
            // 
            // CBX_OrderBy
            // 
            CBX_OrderBy.DropDownStyle = ComboBoxStyle.DropDownList;
            CBX_OrderBy.FormattingEnabled = true;
            CBX_OrderBy.Items.AddRange(new object[] { "Random", "Uploaded At", "Favorites", "Liked At" });
            CBX_OrderBy.Location = new Point(91, 136);
            CBX_OrderBy.Name = "CBX_OrderBy";
            CBX_OrderBy.Size = new Size(259, 23);
            CBX_OrderBy.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 230);
            label4.Name = "label4";
            label4.Size = new Size(78, 15);
            label4.TabIndex = 15;
            label4.Text = "Only GIF Files";
            // 
            // CHK_OnlyGif
            // 
            CHK_OnlyGif.AutoSize = true;
            CHK_OnlyGif.Location = new Point(210, 231);
            CHK_OnlyGif.Name = "CHK_OnlyGif";
            CHK_OnlyGif.Size = new Size(15, 14);
            CHK_OnlyGif.TabIndex = 16;
            CHK_OnlyGif.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 202);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 13;
            label3.Text = "NSFW Searches:";
            // 
            // CHK_NsfwResults
            // 
            CHK_NsfwResults.AutoSize = true;
            CHK_NsfwResults.Location = new Point(210, 203);
            CHK_NsfwResults.Name = "CHK_NsfwResults";
            CHK_NsfwResults.Size = new Size(15, 14);
            CHK_NsfwResults.TabIndex = 14;
            CHK_NsfwResults.UseVisualStyleBackColor = true;
            // 
            // TXT_ExcludedTags
            // 
            TXT_ExcludedTags.Location = new Point(91, 49);
            TXT_ExcludedTags.Name = "TXT_ExcludedTags";
            TXT_ExcludedTags.Size = new Size(259, 23);
            TXT_ExcludedTags.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 52);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 3;
            label2.Text = "Exclude Tags:";
            // 
            // TXT_IncludedTags
            // 
            TXT_IncludedTags.Location = new Point(91, 20);
            TXT_IncludedTags.Name = "TXT_IncludedTags";
            TXT_IncludedTags.Size = new Size(259, 23);
            TXT_IncludedTags.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 23);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 1;
            label1.Text = "Include Tags:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(BTN_Open);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(CBX_WallpaperFit);
            groupBox2.Controls.Add(TXT_ImageLocation);
            groupBox2.Controls.Add(label9);
            groupBox2.Location = new Point(387, 1);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(368, 134);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "Wallpaper Information";
            // 
            // BTN_Open
            // 
            BTN_Open.Location = new Point(296, 42);
            BTN_Open.Name = "BTN_Open";
            BTN_Open.Size = new Size(58, 23);
            BTN_Open.TabIndex = 20;
            BTN_Open.Text = "Open";
            BTN_Open.UseVisualStyleBackColor = true;
            BTN_Open.Click += BTN_Open_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(14, 75);
            label11.Name = "label11";
            label11.Size = new Size(79, 15);
            label11.TabIndex = 21;
            label11.Text = "Wallpaper Fit:";
            // 
            // CBX_WallpaperFit
            // 
            CBX_WallpaperFit.DropDownStyle = ComboBoxStyle.DropDownList;
            CBX_WallpaperFit.FormattingEnabled = true;
            CBX_WallpaperFit.Items.AddRange(new object[] { "Auto", "Fill", "Fit", "Stretch", "Tile", "Center", "Span" });
            CBX_WallpaperFit.Location = new Point(123, 71);
            CBX_WallpaperFit.Name = "CBX_WallpaperFit";
            CBX_WallpaperFit.Size = new Size(231, 23);
            CBX_WallpaperFit.TabIndex = 22;
            // 
            // TXT_ImageLocation
            // 
            TXT_ImageLocation.Location = new Point(123, 42);
            TXT_ImageLocation.Name = "TXT_ImageLocation";
            TXT_ImageLocation.Size = new Size(167, 23);
            TXT_ImageLocation.TabIndex = 19;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(14, 45);
            label9.Name = "label9";
            label9.Size = new Size(103, 15);
            label9.TabIndex = 18;
            label9.Text = "Download Folder::";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(CHK_OnlyFavorites);
            groupBox3.Controls.Add(TXT_Token);
            groupBox3.Controls.Add(label14);
            groupBox3.Location = new Point(387, 138);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(368, 122);
            groupBox3.TabIndex = 23;
            groupBox3.TabStop = false;
            groupBox3.Text = "User Information";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(11, 74);
            label12.Name = "label12";
            label12.Size = new Size(85, 15);
            label12.TabIndex = 26;
            label12.Text = "Only Favorites:";
            // 
            // CHK_OnlyFavorites
            // 
            CHK_OnlyFavorites.AutoSize = true;
            CHK_OnlyFavorites.Location = new Point(215, 75);
            CHK_OnlyFavorites.Name = "CHK_OnlyFavorites";
            CHK_OnlyFavorites.Size = new Size(15, 14);
            CHK_OnlyFavorites.TabIndex = 27;
            CHK_OnlyFavorites.UseVisualStyleBackColor = true;
            // 
            // TXT_Token
            // 
            TXT_Token.Location = new Point(108, 42);
            TXT_Token.Name = "TXT_Token";
            TXT_Token.Size = new Size(242, 23);
            TXT_Token.TabIndex = 25;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(10, 45);
            label14.Name = "label14";
            label14.Size = new Size(41, 15);
            label14.TabIndex = 24;
            label14.Text = "Token:";
            // 
            // BTN_DownloadSetWallpaper
            // 
            BTN_DownloadSetWallpaper.Location = new Point(311, 266);
            BTN_DownloadSetWallpaper.Name = "BTN_DownloadSetWallpaper";
            BTN_DownloadSetWallpaper.Size = new Size(165, 23);
            BTN_DownloadSetWallpaper.TabIndex = 28;
            BTN_DownloadSetWallpaper.Text = "Download + Set Wallpaper";
            BTN_DownloadSetWallpaper.UseVisualStyleBackColor = true;
            BTN_DownloadSetWallpaper.Click += BTN_DownloadSetWallpaper_Click;
            // 
            // WaifuWallpaperSetter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(767, 298);
            Controls.Add(BTN_DownloadSetWallpaper);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(783, 337);
            MinimumSize = new Size(783, 337);
            Name = "WaifuWallpaperSetter";
            Text = "Waifu Wallpaper Setter";
            FormClosing += WaifuWallpaperSetter_FormClosing;
            Load += WaifuWallpaperSetter_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox TXT_ExcludedTags;
        private Label label2;
        private TextBox TXT_IncludedTags;
        private Label label6;
        private ComboBox CBX_Orientation;
        private Label label5;
        private ComboBox CBX_OrderBy;
        private Label label4;
        private Label label3;
        private CheckBox CHK_NsfwResults;
        private TextBox TXT_ExcludedFiles;
        private Label label7;
        private TextBox TXT_IncludedFiles;
        private Label label8;
        private GroupBox groupBox2;
        private Label label11;
        private ComboBox CBX_WallpaperFit;
        private TextBox TXT_ImageLocation;
        private CheckBox CHK_OnlyGif;
        private Label label9;
        private GroupBox groupBox3;
        private TextBox TXT_Token;
        private Label label14;
        private Button BTN_DownloadSetWallpaper;
        private Label label12;
        private CheckBox CHK_OnlyFavorites;
        private Button BTN_Open;
    }
}