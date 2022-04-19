using System.Collections.Generic;
using System.Linq;

namespace Breakout_Game.Audio{
    public static class AudioManager{
        private static readonly IList<Audio> Audios;

        public static readonly Audio TestSoundLoop = new Audio("audioTest.wav", true);
        public static readonly Audio TestSound = new Audio("audio2Test.wav");
        public static readonly Audio TestNextSound = new Audio("audio3Test.wav");


        static AudioManager()
        {
            Audios = new List<Audio>()
            {
                TestSoundLoop,
                TestSound,
                TestNextSound
            };
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