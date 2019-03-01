using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        Streamer streamer = new Streamer(2000);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            streamer.Player.OnStatusUpdate += Player_OnStatusUpdate;
        }

        private object Player_OnStatusUpdate(MusicPlayer.MusicPlayerStatus arg)
        {
            Invoke(new Action(() => {
                lblTitle.Text = arg.CurrentFile.Title;
                lblArtist.Text = arg.CurrentFile.Artist;
                lblClients.Text = string.Format("Clients: {0}", arg.Connections);
                lstQueue.DataSource = arg.Queue;
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
                    var item = new ListViewItem(file.ToString());
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
    }
}
