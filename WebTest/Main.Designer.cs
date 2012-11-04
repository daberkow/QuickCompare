namespace WebTest
{
    partial class Main
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Average", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Data", System.Windows.Forms.HorizontalAlignment.Left);
            this.Go = new System.Windows.Forms.Button();
            this.CodeButton = new System.Windows.Forms.Button();
            this.QuickCompare = new System.Windows.Forms.ListView();
            this.URL1Header = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.url1time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.URL2Header = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.url1Editable = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.url2Ediable = new System.Windows.Forms.TextBox();
            this.ThreadCount = new System.Windows.Forms.NumericUpDown();
            this.Threads = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.testNumber = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ThreadCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // Go
            // 
            this.Go.Location = new System.Drawing.Point(510, 394);
            this.Go.Name = "Go";
            this.Go.Size = new System.Drawing.Size(75, 23);
            this.Go.TabIndex = 0;
            this.Go.Text = "Go";
            this.Go.UseVisualStyleBackColor = true;
            this.Go.Click += new System.EventHandler(this.Go_Click);
            // 
            // CodeButton
            // 
            this.CodeButton.Location = new System.Drawing.Point(12, 394);
            this.CodeButton.Name = "CodeButton";
            this.CodeButton.Size = new System.Drawing.Size(75, 23);
            this.CodeButton.TabIndex = 1;
            this.CodeButton.Text = "Code";
            this.CodeButton.UseVisualStyleBackColor = true;
            this.CodeButton.Click += new System.EventHandler(this.CodeButton_Click);
            // 
            // QuickCompare
            // 
            this.QuickCompare.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.URL1Header,
            this.url1time,
            this.URL2Header});
            listViewGroup1.Header = "Average";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "Data";
            listViewGroup2.Name = "listViewGroup2";
            this.QuickCompare.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.QuickCompare.Location = new System.Drawing.Point(15, 64);
            this.QuickCompare.Name = "QuickCompare";
            this.QuickCompare.Size = new System.Drawing.Size(575, 324);
            this.QuickCompare.TabIndex = 2;
            this.QuickCompare.UseCompatibleStateImageBehavior = false;
            this.QuickCompare.View = System.Windows.Forms.View.Details;
            // 
            // URL1Header
            // 
            this.URL1Header.Tag = "URL 1";
            this.URL1Header.Text = "URL 1";
            this.URL1Header.Width = 200;
            // 
            // url1time
            // 
            this.url1time.Text = "Winner";
            this.url1time.Width = 200;
            // 
            // URL2Header
            // 
            this.URL2Header.Text = "URL2";
            this.URL2Header.Width = 170;
            // 
            // url1Editable
            // 
            this.url1Editable.Location = new System.Drawing.Point(56, 12);
            this.url1Editable.Name = "url1Editable";
            this.url1Editable.Size = new System.Drawing.Size(529, 20);
            this.url1Editable.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "URL 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "URL 2";
            // 
            // url2Ediable
            // 
            this.url2Ediable.Location = new System.Drawing.Point(56, 38);
            this.url2Ediable.Name = "url2Ediable";
            this.url2Ediable.Size = new System.Drawing.Size(529, 20);
            this.url2Ediable.TabIndex = 5;
            // 
            // ThreadCount
            // 
            this.ThreadCount.Location = new System.Drawing.Point(162, 392);
            this.ThreadCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ThreadCount.Name = "ThreadCount";
            this.ThreadCount.Size = new System.Drawing.Size(120, 20);
            this.ThreadCount.TabIndex = 7;
            this.ThreadCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Threads
            // 
            this.Threads.AutoSize = true;
            this.Threads.Location = new System.Drawing.Point(110, 394);
            this.Threads.Name = "Threads";
            this.Threads.Size = new System.Drawing.Size(46, 13);
            this.Threads.TabIndex = 8;
            this.Threads.Text = "Threads";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 415);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "More Threads puts more load on server";
            // 
            // testNumber
            // 
            this.testNumber.Location = new System.Drawing.Point(384, 397);
            this.testNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.testNumber.Name = "testNumber";
            this.testNumber.Size = new System.Drawing.Size(120, 20);
            this.testNumber.TabIndex = 10;
            this.testNumber.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 399);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Number of Tests";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 429);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.testNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Threads);
            this.Controls.Add(this.ThreadCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.url2Ediable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.url1Editable);
            this.Controls.Add(this.QuickCompare);
            this.Controls.Add(this.CodeButton);
            this.Controls.Add(this.Go);
            this.Name = "Form1";
            this.Text = "Quick Compare";
            ((System.ComponentModel.ISupportInitialize)(this.ThreadCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Go;
        private System.Windows.Forms.Button CodeButton;
        private System.Windows.Forms.ListView QuickCompare;
        private System.Windows.Forms.ColumnHeader URL1Header;
        private System.Windows.Forms.ColumnHeader url1time;
        private System.Windows.Forms.ColumnHeader URL2Header;
        private System.Windows.Forms.TextBox url1Editable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox url2Ediable;
        private System.Windows.Forms.NumericUpDown ThreadCount;
        private System.Windows.Forms.Label Threads;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown testNumber;
        private System.Windows.Forms.Label label4;
    }
}

