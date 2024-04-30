using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DirectShowLib;

//using DirectShowLib;
using QuartzTypeLib;

namespace SoundProject
{
    public partial class MP3Player : Form
    {
        private FilgraphManager filterGraph;
        private DirectShowLib.IMediaControl mediaControl;

        public MP3Player()
        {
            InitializeComponent();
            InitializePlayer();
        }

        private void InitializePlayer()
        {
            filterGraph = new FilgraphManager();
            mediaControl = filterGraph as DirectShowLib.IMediaControl;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos MP3|*.mp3",
                Title = "Selecciona un archivo MP3"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string mp3FilePath = openFileDialog.FileName;
                File.Text = mp3FilePath;
                Play(mp3FilePath);
            }
        }

        private void Play(string mp3FilePath)
        {
            mediaControl.Stop();
            InitializePlayer();
            filterGraph.RenderFile(mp3FilePath);
            mediaControl.Run();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            mediaControl.Run();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            mediaControl.Pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            mediaControl.Stop();
        }

        private void btnGet_State(object sender, EventArgs e)
        {
            FilterState filterState;
            _ = mediaControl.GetState(0, out filterState);
            if (filterState == FilterState.Stopped)
            {
                MessageBox.Show("El audio está parado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (filterState == FilterState.Paused)
            {
                MessageBox.Show("El audio está pausado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (filterState == FilterState.Running)
            {
                MessageBox.Show("El audio está corriendo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void File_TextChanged(object sender, EventArgs e)
        {
            //File.Text = mp3FilePath;
        }
    }
}
