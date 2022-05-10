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

        private static List<List<bool>> _emplacement = Enumerable.Range(0, Levels.Level.MaxBrickInColumn).Select(i =>
            Enumerable.Repeat(true, Levels.Level.MaxBrickInARow).ToList()).ToList();

        internal static Level Level{ get; private set; }

        internal static void GenerateLevel(ref int actual){
            switch (actual) {
                case 1:
                    GenerateFirstLevel();
                    return;
                case 2: 
                    GenerateSecondLevel();
                    return;
                case 3:
                    GenerateThirdLevel();
                    break;
                default:
                    break;
            }
            
        }


        private static void GenerateFirstLevel(){
            Level = new Level(_emplacement);
        }

        private static void GenerateSecondLevel(){
            Level = new Level(_emplacement);
        }
        
        private static void GenerateThirdLevel(){
            Level = new Level(_emplacement);
        }

        private static void NextLevel(ref int actual){
            actual += (actual > -1 && actual < 4) ? 1 : 0;
        }

        internal static void RandomChangeBrickLevel(){
        }



    }
}