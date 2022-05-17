using System.Collections.Generic;
using System.Linq;
using Breakout_Game.Game.Utils;

namespace Breakout_Game.Audio{
    public static class AudioManager{
        private static readonly IList<Audio> Audios;

        // public static readonly Audio BackgroundSound = new Audio("audioTest.wav", true);
        public static readonly Audio BackgroundSound = new Audio("Background.wav", true);
        public static readonly Audio DestructionSound = new Audio("Destruction.wav");
        public static readonly Audio BouncSound = new Audio("Bounce.wav");
        public static readonly Audio GameOverSound = new Audio("GameOver.wav");
        public static readonly Audio VictorySound = new Audio("Victory.wav");

        static AudioManager()
        {
            Audios = new List<Audio>()
            {
                BackgroundSound,
                DestructionSound,
                BouncSound,
                GameOverSound,
                VictorySound
            };
            Log.Send("AudioManager", "Audios Loaded !", LogType.Success);
        }

        /// <summary>
        /// init method, called to init the static constructor to not instanciate it when we need it and not create lag
        /// </summary>

        public static void init(){ }
        public static bool isAnyAudioPlaying()
        {
            return Audios.Any(sound => sound.isPlaying());
        }
    }
}