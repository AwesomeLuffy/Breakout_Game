using System;
using Breakout_Game.Audio;
using Breakout_Game.Game.Forms;
using Breakout_Game.Game.Levels;
using Breakout_Game.Game.Utils;

namespace Breakout_Game.Game.Events{
    public static class EventListener{

        public static void InitEventListener(){
            CreateFormEvent.Handler += OnFormCreate;
            BrickDamage.Handler += OnBrickDamage;
            BrickDestroyAnimationFinished.Handler += OnBrickDestroyAnimationFinished;
        }

        private static void OnFormCreate(object sender, EventArgs e){
            if (!(sender is CreateFormEvent form)) return;
            if (!(form.GetForm() is Brick)) return;
            Brick brick = form.GetForm() as Brick;
            Log.Send("EventListener", "Brick created !", LogType.Info);

        }

        private static void OnBrickDamage(object sender, EventArgs e){
            if (!(sender is BrickDamage brickDamage)) return;
            if (brickDamage.IsCancelled()) return;
            if (brickDamage.Brick.Level == 0) {
                brickDamage.Brick.DestructBrickAnimation();
            }
        }

        private static void OnBrickDestroyAnimationFinished(object sender, EventArgs e){
            if(!(sender is BrickDestroyAnimationFinished brickDestroyAnimationFinished)) return;
            foreach (var bricks in LevelManager.Level.bricks) {
                bricks.Remove(brickDestroyAnimationFinished.Brick);
            }
            Game.PointCounter += 5;
            AudioManager.DestructionSound.play();
            Log.Send("Event", "Brick destroyed", LogType.Info);
            if (LevelManager.IsLevelFinished()) {
                LevelManager.NextLevel(ref Game.ActualLevelNumber);
                Game.GameAction(GameAction.GenerateLevel, new object[]{Game.ActualLevelNumber});
            }
        }
    }
}