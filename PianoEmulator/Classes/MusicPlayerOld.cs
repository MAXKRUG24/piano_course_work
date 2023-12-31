﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PianoEmulator.Classes
{
    public class MusicPlayerOld
    {
        public bool IsBeingPlayed = false;
        private bool IsLooping = false;
        public string FileName;
        public string TrackName;
        private long lngVolume = 500; //between 0-1000

        public MusicPlayerOld(string fileName)
        {
            TrackName = fileName;
            if (fileName.Contains("\\"))
                FileName = fileName;
            else
                FileName = AppDomain.CurrentDomain.BaseDirectory + fileName;
        }

        private void PlayWorker()
        {
            StringBuilder sb = new StringBuilder();
            int result = mciSendString("open \"" + FileName + "\" type waveaudio  alias " + TrackName, sb, 0, IntPtr.Zero);
            mciSendString("play " + TrackName, sb, 0, IntPtr.Zero);
            IsBeingPlayed = true;
            //loop
            sb = new StringBuilder();
            mciSendString("status " + TrackName + " length", sb, 255, IntPtr.Zero);
            int length = Convert.ToInt32(sb.ToString());
            int pos = 0;
            long oldvol = lngVolume;
            

            while (IsBeingPlayed)
            {
                sb = new StringBuilder();
                mciSendString("status " + TrackName + " position", sb, 255, IntPtr.Zero);
                pos = Convert.ToInt32(sb.ToString());
                if (pos >= length)
                {
                    if (!IsLooping)
                    {
                        IsBeingPlayed = false;
                        break;
                    }
                    else
                    {
                        mciSendString("play " + TrackName + " from 0", sb, 0, IntPtr.Zero);
                    }
                }

                Application.DoEvents();
            }
            mciSendString("stop " + TrackName, sb, 0, IntPtr.Zero);
            mciSendString("close " + TrackName, sb, 0, IntPtr.Zero);
        }

        public void Play(bool Looping)
        {
            try
            {
                if (IsBeingPlayed)
                    return;
                if (!File.Exists(FileName))
                {
                    IsBeingPlayed = true;
                    return;
                }
                IsLooping = Looping;
                ThreadStart ts = new ThreadStart(PlayWorker);
                Thread WorkerThread = new Thread(ts);
                WorkerThread.Start();
            }
            catch (Exception ex)
            {
            }
        }

        public void StopPlaying()
        {
            IsBeingPlayed = false;
        }

        //sound api functions
        [DllImport("winmm.dll")]
        static extern int mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

        [DllImport("winmm.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        static extern bool PlaySound(
            string pszSound,
            IntPtr hMod,
            SoundFlags sf);

        // Flags for playing sounds.  For this example, we are reading
        // the sound from a filename, so we need only specify
        // SND_FILENAME | SND_ASYNC

        [Flags]
        public enum SoundFlags : int
        {
            SND_SYNC = 0x0000,  // play synchronously (default)
            SND_ASYNC = 0x0001,  // play asynchronously
            SND_NODEFAULT = 0x0002,  // silence (!default) if sound not found
            SND_MEMORY = 0x0004,  // pszSound points to a memory file
            SND_LOOP = 0x0008,  // loop the sound until next sndPlaySound
            SND_NOSTOP = 0x0010,  // don't stop any currently playing sound
            SND_PURGE = 0x40, // <summary>Stop Playing Wave</summary>
            SND_NOWAIT = 0x00002000, // don't wait if the driver is busy
            SND_ALIAS = 0x00010000, // name is a registry alias
            SND_ALIAS_ID = 0x00110000, // alias is a predefined ID
            SND_FILENAME = 0x00020000, // name is file name
            SND_RESOURCE = 0x00040004  // name is resource name or atom
        }

    }
}