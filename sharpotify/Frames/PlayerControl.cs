using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using nBASS;
using Sharpotify.Media;
using Sharpotify.Controls;

namespace Sharpotify.Frames
{
    public partial class PlayerControl : UserControl, IDisposable
    {
        private AdvancedChannel stream;
        private MusicStream currentStream;
        private List<Track> tracks;
        private int currentTrack;
        private bool randomMode;
        private List<int> tracksCounter;

        public Track CurrentTrack 
        { 
            get 
            {
                if (currentTrack < 0 || currentTrack >= tracks.Count)
                    return null;

                return tracks[currentTrack];
            }
        }

        public PlayerControl()
        {
            InitializeComponent();

            currentStream = null;
            Facade.PlayTrackRequest += new DownloadHandler(Facade_PlayTrackRequest);
            Facade.PlayListTracksRequest += new PlayListHandler(Facade_PlayListTracksRequest);
            tracks = new List<Track>();
            tracksCounter = new List<int>();
            currentTrack = -1;
            randomMode = false;
            barVolume.Value = bass.StreamVolume/10;
        }

        private void Facade_PlayListTracksRequest(List<Track> tracks, bool random)
        {
            randomMode = random;
            Play(tracks);
        }
        private void Facade_PlayTrackRequest(Track t, int index)
        {
            Play(t);
        }
        
        public void Play()
        {
            switch (stream.ActivityState)
            {
                case State.Paused:
                    stream.Resume();
                    ChangeStatus(null);
                    break;
                case State.Stopped:
                    stream.Play(true, StreamPlayFlags.Default);
                    ChangeStatus(null);
                    break;
            }
        }
        public void Pause()
        {
            switch (stream.ActivityState)
            {
                case State.Playing:
                    stream.Pause();
                    ChangeStatus(null);
                    break;
            }
        }
        public void Stop()
        {
            switch (stream.ActivityState)
            {
                case State.Playing:
                    stream.Stop();
                    ChangeStatus(null);
                    break;
            }
        }
        public void Play(Track t)
        { 
            tracks.Clear();
            tracks.Add(t);
            currentTrack = 0;
            InitializeCounters();
            PlayTrack();
        }
        public void Play(List<Track> tracks)
        {
            this.tracks.Clear();
            this.tracks.AddRange(tracks);
            currentTrack = -1;
            InitializeCounters();
            PlayNextTrack();
        }

        protected void PlayTrack()
        {
            if (currentTrack < 0 || currentTrack >= tracks.Count)
                return;

            Track t = tracks[currentTrack];
            
            if (t == null)
                return;
            if (t.Files == null)
                return;
            if (t.Files.Count <= 0)
                return;

            Facade.PlayingTrack = t;
            tracksCounter[currentTrack]++;

            LoadImage();
            ChangeStatus("Loading " + t.Title);
            ResetStream();
            currentStream = Facade.Spotify.GetMusicStream(t, t.Files[0], new TimeSpan(0, 1, 0));
            currentStream.NewDataAvailable += new EventHandler<EventArgs>(currentStream_WaitToStartToPlay);
        }
        protected void InitializeCounters()
        {
            tracksCounter.Clear();
            for (int i = 0; i < tracks.Count; i++)
                tracksCounter.Add(0);
        }
        protected bool HasNextTrack()
        {
            if (tracks.Count > 1)
                foreach (int c in tracksCounter)
                    if (c == 0)
                        return true;

            return false;
        }
        protected void PlayNextTrack()
        {
            if (!randomMode)
            {
                do
                {
                    currentTrack++;
                    if (currentTrack >= tracks.Count)
                    {
                        InitializeCounters();
                        currentTrack = 0;
                        break;
                    }
                } while (tracksCounter[currentTrack] > 0);
                PlayTrack();
            }
            else
            {
                Random rnd = new Random();
                int index = rnd.Next(0, tracks.Count);
                while (tracksCounter[index] > 0)
                {
                    index++;
                    if (index >= tracks.Count)
                    {
                        index = 0;
                        //break;
                    }
                }
                currentTrack = index;
                PlayTrack();
            }
        }
        protected void currentStream_WaitToStartToPlay(object sender, EventArgs e)
        {
            int buffered = (int)(((double)currentStream.AvailableLength / (double)currentStream.Length) * 100);
            buffered = (buffered > 10) ? 10 : buffered;
            ChangeStatus("Buffering... " + (buffered*10) + "%");
            if (buffered >= 10)
            {
                currentStream.NewDataAvailable -= currentStream_WaitToStartToPlay;
                System.Threading.Thread.Sleep(100);
                //lblStatus.Text = "Loaded " + track.Title;
                //lblStatus.Refresh();
                stream = bass.LoadStream(currentStream.GetBuffer());
                stream.End += new EventHandler(stream_End);

                Play();
                ChangeStatus(null);
                
            }
        }
        protected void currentStream_WaitForBuffer(object sender, EventArgs e)
        {
            int buffered = (int)(((double)(currentStream.AvailableLength - stream.Position) / (double)(currentStream.Length - stream.Position)) * 100);
            buffered = (buffered > 10) ? 10 : buffered;
            ChangeStatus("Buffering... " + (buffered * 10) + "%");
            if (buffered >= 10)
            {
                currentStream.NewDataAvailable -= currentStream_WaitForBuffer;
                stream.Play(false, 0);
                ChangeStatus(null);
            }
        }
        protected void ChangeStatus(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new AnonimousMethod(delegate() { this.ChangeStatus(msg); }));
                return;
            }

            if (!string.IsNullOrEmpty(msg))
            {
                lblStatus.Text = msg;
                lblStatus.Visible = true;
                lblStatus.Refresh();
            }
            else
                lblStatus.Visible = false;

            if (stream != null)
            {
                switch (stream.ActivityState)
                { 
                    case State.Paused:
                        btnPlay.Enabled = true;
                        btnStop.Enabled = false;
                        btnPause.Enabled = false;
                        btnNext.Visible = false;
                        break;
                    case State.Playing:
                        btnPlay.Enabled = false;
                        btnStop.Enabled = true;
                        btnPause.Enabled = true;
                        if (tracks.Count > 1)
                            btnNext.Visible = true;

                        break;
                    case State.Stopped:
                        btnPlay.Enabled = true;
                        btnStop.Enabled = false;
                        btnPause.Enabled = false;
                        btnNext.Visible = false;
                        break;
                
                }
            }
            else
            {
                btnPlay.Enabled = false;
                btnStop.Enabled = false;
                btnPause.Enabled = false;
                btnNext.Visible = false;
            }
        }
        protected void stream_End(object sender, EventArgs e)
        {
            if (stream.Position < stream.Length)
            {
                currentStream.NewDataAvailable += new EventHandler<EventArgs>(currentStream_WaitForBuffer);
            }
            else
            {
                //stream.Position = 0;
                //stream.Play(false, 0);
                Facade.PlayingTrack = null;
                ChangeStatus(null);
                if (HasNextTrack())
                {
                    PlayNextTrack();
                }
                else if (randomMode)
                {
                    InitializeCounters();
                    PlayNextTrack();
                }
            }
        }

        private void ResetStream()
        {
            if (stream != null)
            {
                if (stream.ActivityState == State.Playing)
                {
                    stream.Stop();
                    //stream.Progress -= new BASSProgessHandler(Progress);
                    stream.End -= stream_End;
                }
                stream.Dispose();
            }

            if (currentStream != null)
                if (currentStream.CanRead)
                    currentStream.Close();

            if (currentStream != null)
            {
                currentStream.Dispose();
                currentStream = null;
            }
            stream = null;
        }
        private bool CheckStream()
        {
            if (stream == null)
                return false;
            return true;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Play();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            Pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        int loadImageTries;
        private void LoadImage()
        {
            loadImageTries = 0;
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.LoadImageRun));
        }

        private void LoadImageRun(object stateInfo)
        {
            try
            {
                if (tracks[currentTrack] != null)
                    if (!string.IsNullOrEmpty(tracks[currentTrack].Cover))
                    {
                        Image img = Facade.Spotify.Image(tracks[currentTrack].Cover);
                        this.Invoke(new AnonimousMethod(delegate()
                        {
                            this.pictureBox1.Image = img;
                        }));
                    }
            }
            catch
            {
                loadImageTries++;
                if (loadImageTries <= 3)
                    LoadImageRun(stateInfo);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (tracks.Count <= 1)
                return;

            if (HasNextTrack())
                PlayNextTrack();
            else if (randomMode)
            {
                InitializeCounters();
                PlayNextTrack();
            }
        }

        private void btnVolume_Click(object sender, EventArgs e)
        {
            pnlVolume.Visible = !pnlVolume.Visible;
        }

        private void barVolume_Scroll(object sender, EventArgs e)
        {
            bass.StreamVolume = barVolume.Value * 10;
            if (bass.StreamVolume > 0)
                chkMute.Checked = false;
            else
                chkMute.Checked = true;
        }
        void barVolume_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            pnlVolume.Visible = false;
        }
        private void chkMute_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMute.Checked)
                bass.StreamVolume = 0;
            else
                bass.StreamVolume = barVolume.Value * 10;

            pnlVolume.Visible = false;
        }

        public new void Dispose()
        {
            if (stream != null)
                ResetStream();
            base.Dispose();
        }
    }
}
