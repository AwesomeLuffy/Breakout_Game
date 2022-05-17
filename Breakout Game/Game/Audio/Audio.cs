using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using System;
using System.Collections.Generic;
using System.Threading;
using Breakout_Game.Game.Utils;

namespace Breakout_Game.Audio{
    public class Audio{
        #region Attributs
        internal static AudioContext audioContex = new AudioContext();
        private int bufferSound;
        private int sourceSound;

        private FichierWAV audioFile;

        private bool isLoop;

        private float volume;
        
        private Thread thread;
        #endregion

        public Audio(string path, bool isLooping = false) {
            audioFile = new FichierWAV("../../audios/" + path);
            this.isLoop = isLooping;
            init(); 
        }
        ~Audio() {
            AL.SourceStop(sourceSound);
            AL.DeleteSource(sourceSound);
            AL.DeleteBuffer(bufferSound);
        }
        private void init()
        {
            bufferSound = AL.GenBuffer();
            sourceSound = AL.GenSource();
            AL.BufferData(bufferSound, audioFile.getFormatSonAL(), 
                audioFile.getDonneesSonores(), audioFile.getQteDonneesSonores(), 
                audioFile.getFrequence());
            AL.Source(sourceSound, ALSourcei.Buffer, bufferSound);
            if (this.isLoop)
            {
                AL.Source(sourceSound, ALSourceb.Looping, true);
            }
            volume = 0.5f;
            AL.Listener(ALListenerf.Gain, volume);
        }
        public void setGainLower()
        {
            AL.Source(this.sourceSound, ALSourcef.Gain, 0.1f);
        }
        public void setVolume(int value)
        {
            volume = value / 100.0f;
            AL.Listener(ALListenerf.Gain, volume);
        }
        public void play()
        {
            Console.WriteLine("yyyyyyyy");
            Log.Send("Audio", this.audioFile.nomFichier + " played", LogType.Info);
            thread = new Thread(() => AL.SourcePlay(this.sourceSound));
            thread.Start();
        }
        public void stop()
        {
            AL.SourceStop(sourceSound);
            thread.Abort();
            Console.WriteLine("uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu");
        }
        public bool isPlaying()
        {
            return (AL.GetSourceState(this.sourceSound) == ALSourceState.Playing);
        }
        public void waitForPlaying(Audio nameNextSound)
        {
            ALSourceState isSoundEnd;
            this.play();
            do
            {
                isSoundEnd = (AL.GetSourceState(this.getSource()));
            } while (isSoundEnd == ALSourceState.Playing);
            nameNextSound.play();
        }
        public int getSource()
        {
            return this.sourceSound;
        }
    }
}