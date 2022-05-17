using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Breakout_Game.Game.Forms;
using Breakout_Game.Game.Utils;

namespace Breakout_Game.Game.Levels{
    public static class LevelManager{
        
        /*LEFT/RIGHT/TOP Extremity -> Lvl 4 - Indestructible
         *First LEFT/RIGHT/TOP Extremity -> Lvl 3
         *Second LEFT/RIGHT/TOP Extremity -> Lvl 2
         *Else -> Lvl 1
         */

        private const int TimeSleepSpecialBrick = 20000;
        
        private static List<List<bool>> _emplacement = Enumerable.Range(0, Levels.Level.MaxBrickInColumn).Select(i =>
            Enumerable.Repeat(true, Levels.Level.MaxBrickInARow).ToList()).ToList();

        internal static Level Level{ get; private set; }

        internal static void GenerateLevel(int actual){
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
            if(Level.haveSpecial){ RandomChangeBrickLevel(); }
            Log.Send("Level", "Level " + actual + " generated", LogType.Info);
            
        }

        //List -> [Column][Row]
        private static void GenerateFirstLevel(){
            Level = new Level(_emplacement, true);
            
        }

        private static void GenerateSecondLevel()
        {
            Level = new Level(_emplacement);
        }
        
        private static void GenerateThirdLevel(){
            Level = new Level(_emplacement);
        }

        internal static void NextLevel(ref int actual){
            actual += (actual > -1 && actual < 4) ? 1 : 0;
        }

        private static void RandomChangeBrickLevel(){
            if (!Level.haveSpecial) {
                return;
            }

            int actualLvlNumber = Game.ActualLevelNumber;
            new Thread(() => {
                Log.Send("LevelManager", "Thread Randomizer Change Brick started!", LogType.Info);
                while (actualLvlNumber == Game.ActualLevelNumber) {
                    Thread.Sleep(TimeSleepSpecialBrick);
                    if (!Game.IsGamePause && Game.IsGameStarted) {
                        foreach (var brick in Level.bricks.SelectMany(listBrick => listBrick.Where(brick => brick.IsSpecial))) {
                            if (new Random().Next(1, 3) != 2) continue;
                            if(brick.Level == 3){ continue; }
                            brick.AddLevel();
                            Thread.Sleep(3000);
                        }
                    }
                }
            }).Start();

        }

        internal static bool IsLevelFinished(){
            foreach (List<Brick> bricks in LevelManager.Level.bricks) {
                foreach (var brick in bricks) {
                    if (!brick.IsInvincible) {
                        return false;
                    }
                }
            }

            return true;
        }



    }
}