﻿using System;
using Breakout_Game.Game.Forms;
using Breakout_Game.Game.Levels;

namespace Breakout_Game.Game.Events{
    public static class EventListener{

        public static void InitEventListener(){
            CreateFormEvent.Handler += OnFormCreate;
            BrickDamage.Handler += OnBrickDamage;
            BrickDestroyAnimationFinished.Handler += OnBrickDestroyAnimationFinished;
            RacketUpdate.Handler += OnRacketUpdate;
        }

        private static void OnFormCreate(object sender, EventArgs e){
            if (!(sender is CreateFormEvent form)) return;
            if (!(form.GetForm() is Brick)) return;
            Brick brick = form.GetForm() as Brick;
            if (brick != null) {

            }

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
            foreach (var bricks in LevelManager._levels[Game.ActualLevelNumber].bricks) {
                bricks.Remove(brickDestroyAnimationFinished.Brick);
            }
        }

        private static void OnRacketUpdate(object sender, EventArgs e){
            if(!(sender is RacketUpdate racketUpdate)) return;
        }
    }
}