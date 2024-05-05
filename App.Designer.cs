namespace SoundProject
{
    partial class MP3Player
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
            Browse = new Button();
            PlayBtn = new Button();
            Pause = new Button();
            Stop = new Button();
            getState = new Button();
            File = new TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            progressBar1 = new ProgressBar();
            SuspendLayout();
            // 
            // Browse
            // 
            Browse.Location = new Point(41, 12);
            Browse.Name = "Browse";
            Browse.Size = new Size(78, 38);
            Browse.TabIndex = 0;
            Browse.Text = "Browse";
            Browse.UseVisualStyleBackColor = true;
            Browse.Click += btnBrowse_Click;
            // 
            // PlayBtn
            // 
            PlayBtn.Location = new Point(41, 125);
            PlayBtn.Name = "PlayBtn";
            PlayBtn.Size = new Size(56, 38);
            PlayBtn.TabIndex = 1;
            PlayBtn.Text = "Play";
            PlayBtn.UseVisualStyleBackColor = true;
            PlayBtn.Click += btnPlay_Click;
            // 
            // Pause
            // 
            Pause.Location = new Point(103, 125);
            Pause.Name = "Pause";
            Pause.Size = new Size(72, 38);
            Pause.TabIndex = 2;
            Pause.Text = "Pause";
            Pause.UseVisualStyleBackColor = true;
            Pause.Click += btnPause_Click;
            // 
            // Stop
            // 
            Stop.Location = new Point(181, 125);
            Stop.Name = "Stop";
            Stop.Size = new Size(69, 38);
            Stop.TabIndex = 3;
            Stop.Text = "Stop";
            Stop.UseVisualStyleBackColor = true;
            Stop.Click += btnStop_Click;
            // 
            // getState
            // 
            getState.Location = new Point(354, 129);
            getState.Name = "getState";
            getState.Size = new Size(91, 34);
            getState.TabIndex = 4;
            getState.Text = "GetState";
            getState.UseVisualStyleBackColor = true;
            getState.Click += btnGet_State;
            // 
            // File
            // 
            File.BorderStyle = BorderStyle.FixedSingle;
            File.Location = new Point(145, 12);
            File.Name = "File";
            File.ReadOnly = true;
            File.Size = new Size(300, 31);
            File.TabIndex = 5;
            File.TextChanged += File_TextChanged;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(41, 65);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(404, 34);
            progressBar1.TabIndex = 6;
            // 
            // MP3Player
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 179);
            Controls.Add(progressBar1);
            Controls.Add(File);
            Controls.Add(getState);
            Controls.Add(Stop);
            Controls.Add(Pause);
            Controls.Add(PlayBtn);
            Controls.Add(Browse);
            Name = "MP3Player";
            Text = "MyMP3Player";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Browse;
        private Button Pause;
        private Button Stop;
        private Button PlayBtn;
        private Button getState;
        private TextBox File;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ProgressBar progressBar1;
    }
}
