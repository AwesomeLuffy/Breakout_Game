using System;
using System.Collections.Generic;
using System.Linq;

namespace Breakout_Game.Game.Levels{
    public static class LevelManager{
        
        /*LEFT/RIGHT/TOP Extremity -> Lvl 4 - Indestructible
         *First LEFT/RIGHT/TOP Extremity -> Lvl 3
         *Second LEFT/RIGHT/TOP Extremity -> Lvl 2
         *Else -> Lvl 1
         */

        private static List<List<bool>> _emplacement = Enumerable.Range(0, Level.MaxBrickInColumn).Select(i =>
            Enumerable.Repeat(true, Level.MaxBrickInARow).ToList()).ToList();

        private static List<Level> _levels = new List<Level>();


        internal static void CreateFirstLevel(){
            _levels.Add(new Level(_emplacement));
        }

        internal static Level GetFirstLevel(){
            return _levels[0] ?? throw new Exception("Level not initilized");
        }



    }
}