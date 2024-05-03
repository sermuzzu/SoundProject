using DirectShowLib;
using NAudio.Wave;
using QuartzTypeLib;

namespace SoundProject
{
    public partial class MP3Player : Form
    {
        private FilgraphManager filterGraph;
        private DirectShowLib.IMediaControl mediaControl;
        private WaveOutEvent waveOutDevice;
        private AudioFileReader audioFileReader;

        public MP3Player()
        {
            InitializeComponent();
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
                Stopping();
                Play(mp3FilePath);
            }
        }

        private void Play(string mp3FilePath)
        {
            if (string.IsNullOrEmpty(mp3FilePath))
            {
                MessageBox.Show("Por favor selecciona un archivo MP3", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (audioFileReader == null)
                {
                    audioFileReader = new AudioFileReader(mp3FilePath);
                }

                if (audioFileReader.Position != 0 && waveOutDevice.PlaybackState == PlaybackState.Stopped) // si esta al final del archivo
                {
                    //MessageBox.Show("Final " + audioFileReader.Position.ToString() + " " + audioFileReader.Length.ToString(), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    waveOutDevice = new WaveOutEvent();
                    waveOutDevice.Init(audioFileReader);
                    audioFileReader.Position = 0;
                    waveOutDevice.Play();
                }
                else if (audioFileReader.Position != 0 && waveOutDevice.PlaybackState == PlaybackState.Paused) // si esta pausado en cualquier otra parte del archivo
                {
                    //MessageBox.Show("Pausado " + audioFileReader.Position.ToString() + " " + audioFileReader.Length.ToString(), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    waveOutDevice = new WaveOutEvent();
                    waveOutDevice.Init(audioFileReader);
                    waveOutDevice.Play();
                }
                else // si esta al principio del archivo
                {
                    //MessageBox.Show("Principio " + audioFileReader.Position.ToString() + " " + audioFileReader.Length.ToString(), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Stopping();
                    waveOutDevice = new WaveOutEvent();
                    audioFileReader = new AudioFileReader(mp3FilePath);
                    waveOutDevice.Init(audioFileReader);
                    waveOutDevice.Play();
                }

            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Play(File.Text);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(File.Text))
            {
                MessageBox.Show("Por favor selecciona un archivo MP3", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            waveOutDevice?.Pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(File.Text))
            {
                MessageBox.Show("Por favor selecciona un archivo MP3", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Stopping();
        }

        private void Stopping()
        {
            waveOutDevice?.Stop();
            waveOutDevice?.Dispose();
            waveOutDevice = null;

            audioFileReader?.Dispose();
            audioFileReader = null;
        }

        private void btnGet_State(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(File.Text))
            {
                MessageBox.Show("Por favor selecciona un archivo MP3", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (waveOutDevice==null)
            {
                MessageBox.Show("El audio esta parado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (waveOutDevice.PlaybackState == PlaybackState.Stopped)
            {
                MessageBox.Show("El audio llego al final", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (waveOutDevice.PlaybackState == PlaybackState.Paused)
            {
                MessageBox.Show("El audio esta pausado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (waveOutDevice.PlaybackState == PlaybackState.Playing)
            {
                MessageBox.Show("El audio esta corriendo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void File_TextChanged(object sender, EventArgs e)
        {
            //File.Text = mp3FilePath;
        }
    }
}
