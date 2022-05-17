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

        private const int TimeSleepSpecialBrick = 3000;

        private static List<List<bool>> _emplacement;


        internal static Level Level;

        internal static void GenerateLevel(int actual){
            switch (actual) {
                case 1:
                    GenerateFirstLevel();
                    break;
                case 2:
                    GenerateSecondLevel();
                    break;
                default:
                    GenerateThirdLevel();
                    break;
            }

            if (Level.HaveSpecial) {
                RandomChangeBrickLevel();
            }

            Log.Send("Level", "Level " + actual + " generated", LogType.Info);
        }

        //List -> [Column][Row]
        private static void GenerateFirstLevel(){
            InitDefaultListTo();


            for (int j = 1; j < 4; j++) {
                for (int i = 0; i < 9; i++) {
                    _emplacement[j][i] = false;
                }
            }


            Level = new Level(_emplacement);
        }

        private static void GenerateSecondLevel(){
            InitDefaultListTo();
            for (int j = 0; j < 4; j++) {
                for (int i = 0; i < 8; i++) {
                    if ((j == 1 && i > 2 && i < 6) || (j == 2 && i > 1 && i < 7) || j == 3 && i != 0) {
                        _emplacement[j][i] = false;
                    }
                }
            }

            Level = new Level(_emplacement, true);
        }

        private static void GenerateThirdLevel(){
            InitDefaultListTo();
            for (int j = 1; j < 3; j++) {
                for (int i = 2; i < 7; i++) {
                    if (i != 4) {
                        _emplacement[j][i] = false;
                    }
                }
            }

            Level = new Level(_emplacement, true);
        }

        internal static void NextLevel(ref int actual){
            actual += (actual > -1 && actual < 4) ? 1 : 0;
            Game.GameAction(GameAction.GenerateLevel, new object[] {Game.ActualLevelNumber});
        }

        private static void RandomChangeBrickLevel(){
            if (!Level.HaveSpecial) {
                return;
            }

            void UpdateBrick(){
                try {
                    foreach (List<Brick> bricks in Level.bricks) {
                        foreach (Brick brick1 in bricks) {
                            if (brick1 == null) {
                                continue;
                            }
                            

                            if (brick1.IsSpecial) {
                                if (new Random().Next(1, 3) == 2) {


                                    if (brick1.Level == 3) {
                                        continue;
                                    }

                                    if (brick1.AddLevel()) {
                                        Thread.Sleep(TimeSleepSpecialBrick);
                                    }

                                }
                            }
                        }
                    }
                }
                catch (Exception e) {
                    Log.Send("LeveLManager", "Thread planted : " + e, LogType.Error);
                }
            }

            int actualLvlNumber = Game.ActualLevelNumber;
            new Thread(() => {
                Log.Send("LevelManager", "Thread Randomizer Change Brick started!", LogType.Info);
                while (actualLvlNumber == Game.ActualLevelNumber) {
                    Thread.Sleep(TimeSleepSpecialBrick);
                    if (!Game.IsGamePause && Game.IsGameStarted) {
                        UpdateBrick();
                    }
                }
            }).Start();
        }

        internal static bool IsLevelFinished(){
            foreach (List<Brick> bricks in LevelManager.Level.bricks) {
                foreach (var brick in bricks) {
                    if (brick == null) {
                        return true;
                    }

                    if (!(brick!.IsInvincible)) {
                        return false;
                    }
                }
            }

            return true;
        }

        private static void InitDefaultListTo(bool to = true){
            _emplacement = Enumerable.Range(0, Levels.Level.MaxBrickInColumn).Select(i =>
                Enumerable.Repeat(to, Levels.Level.MaxBrickInARow).ToList()).ToList();
        }
    }
}