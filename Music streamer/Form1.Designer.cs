namespace Music_streamer
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lstQueue = new System.Windows.Forms.ListBox();
            this.lstFiles = new System.Windows.Forms.ListView();
            this.clhTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhPerformer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOpen = new System.Windows.Forms.Button();
            this.fbdOpen = new System.Windows.Forms.FolderBrowserDialog();
            this.lblArtist = new System.Windows.Forms.Label();
            this.lblClients = new System.Windows.Forms.Label();
            this.clhFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(13, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "--";
            // 
            // lstQueue
            // 
            this.lstQueue.AllowDrop = true;
            this.lstQueue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstQueue.FormattingEnabled = true;
            this.lstQueue.Location = new System.Drawing.Point(12, 71);
            this.lstQueue.Name = "lstQueue";
            this.lstQueue.Size = new System.Drawing.Size(212, 368);
            this.lstQueue.TabIndex = 1;
            this.lstQueue.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstQueue_DragDrop);
            this.lstQueue.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstQueue_DragEnter);
            // 
            // lstFiles
            // 
            this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhTitle,
            this.clhPerformer,
            this.clhFilename});
            this.lstFiles.Location = new System.Drawing.Point(230, 71);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(496, 367);
            this.lstFiles.TabIndex = 2;
            this.lstFiles.UseCompatibleStateImageBehavior = false;
            this.lstFiles.View = System.Windows.Forms.View.Details;
            this.lstFiles.DoubleClick += new System.EventHandler(this.lstFiles_DoubleClick);
            // 
            // clhTitle
            // 
            this.clhTitle.Text = "Title";
            this.clhTitle.Width = 200;
            // 
            // clhPerformer
            // 
            this.clhPerformer.Text = "Performer";
            this.clhPerformer.Width = 100;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(230, 35);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblArtist
            // 
            this.lblArtist.AutoSize = true;
            this.lblArtist.Location = new System.Drawing.Point(12, 40);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(13, 13);
            this.lblArtist.TabIndex = 4;
            this.lblArtist.Text = "--";
            // 
            // lblClients
            // 
            this.lblClients.AutoSize = true;
            this.lblClients.Location = new System.Drawing.Point(165, 40);
            this.lblClients.Name = "lblClients";
            this.lblClients.Size = new System.Drawing.Size(50, 13);
            this.lblClients.TabIndex = 5;
            this.lblClients.Text = "Clients: 0";
            // 
            // clhFilename
            // 
            this.clhFilename.Text = "File";
            this.clhFilename.Width = 150;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 449);
            this.Controls.Add(this.lblClients);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.lstQueue);
            this.Controls.Add(this.lblTitle);
            this.Name = "Form1";
            this.Text = "Music streamer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListBox lstQueue;
        private System.Windows.Forms.ListView lstFiles;
        private System.Windows.Forms.ColumnHeader clhTitle;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.FolderBrowserDialog fbdOpen;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.Label lblClients;
        private System.Windows.Forms.ColumnHeader clhPerformer;
        private System.Windows.Forms.ColumnHeader clhFilename;
    }
}

