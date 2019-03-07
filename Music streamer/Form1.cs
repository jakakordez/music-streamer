using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Music_streamer
{
    public partial class Form1 : Form
    {
        Streamer streamer;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                streamer = new Streamer(2000);
            }
            catch
            {
                MessageBox.Show(
                    "Binding the port TCP 2000 is denied. Check your firewall, other programs or try to run as administrator.",
                    "Access denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
                return;
            }
            streamer.Player.OnStatusUpdate += Player_OnStatusUpdate;
            streamer.Player.OnFileListUpdate += Player_OnFileListUpdate;
        }

        private object Player_OnFileListUpdate(List<MusicFile> queue)
        {
            Invoke(new Action(() =>
            {
                lstQueue.DataSource = queue;
            }));
            return null;
        }

        private object Player_OnStatusUpdate(MusicPlayer.MusicPlayerStatus arg)
        {
            Invoke(new Action(() => {
                lblTitle.Text = arg.CurrentFile.Title;
                lblArtist.Text = arg.CurrentFile.Artist;
                lblClients.Text = string.Format("Clients: {0}", arg.Connections);
            }));
            return null;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if(fbdOpen.ShowDialog() == DialogResult.OK)
            {
                var filenames = Directory.GetFiles(fbdOpen.SelectedPath, "*.mp3");
                foreach (var filename in filenames)
                {
                    var file = new MusicFile(filename);
                    var item = new ListViewItem(new string[] { file.Title, file.Artist, file.Filename });
                    item.Tag = file;
                    lstFiles.Items.Add(item);
                }
            }
        }

        private void lstFiles_DoubleClick(object sender, EventArgs e)
        {
            if(lstFiles.SelectedItems.Count > 0)
            {
                streamer.Player.EnqueueMusic((MusicFile)lstFiles.SelectedItems[0].Tag);
            }
        }

        private void lstQueue_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
        }

        private void lstQueue_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (var filename in files)
            {
                if (!filename.EndsWith(".mp3")) continue;
                var file = new MusicFile(filename);
                streamer.Player.EnqueueMusic(file);
            }
        }
    }
}
