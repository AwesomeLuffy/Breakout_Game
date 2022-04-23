using System;
using Breakout_Game.Game.Forms;

namespace Breakout_Game.Game.Events{
    public static class EventListener{

        public static void InitEventListener(){
            CreateFormEvent.Handler += OnFormCreate;
            BrickDamage.Handler += OnBrickDamage;
        }

        public static void OnFormCreate(object sender, EventArgs e){
            if (!(sender is CreateFormEvent form)) return;
            if (!(form.GetForm() is Brick)) return;
            Brick brick = form.GetForm() as Brick;
            if (brick != null) {

            }

        }

        public static void OnBrickDamage(object sender, EventArgs e){
            if (!(sender is BrickDamage brickDamage)) return;
            if (brickDamage.IsCancelled()) return;
            if (brickDamage.Brick.Level == 0) {
                brickDamage.Brick.DestructBrick();
            }
        }
    }
}