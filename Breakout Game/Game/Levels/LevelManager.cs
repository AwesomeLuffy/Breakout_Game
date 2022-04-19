using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Breakout_Game.Game.Levels{
    public static class LevelManager{
        
        /*LEFT/RIGHT/TOP Extremity -> Lvl 4 - Indestructible
         *First LEFT/RIGHT/TOP Extremity -> Lvl 3
         *Second LEFT/RIGHT/TOP Extremity -> Lvl 2
         *Else -> Lvl 1
         */

        private static List<List<bool>> _emplacement = Enumerable.Range(0, Level.MaxBrickInColumn).Select(i =>
            Enumerable.Repeat(true, Level.MaxBrickInARow).ToList()).ToList();

        internal static List<Level> _levels = new List<Level>();


        internal static void GenerateFirstLevel(){
                _levels.Add(new Level(_emplacement));
            }

        internal static void NextLevel(ref int actual){
            actual += (actual > -1 && actual < _levels.Count) ? 1 : 0;
        }



    }
}