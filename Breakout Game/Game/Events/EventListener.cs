using System;
using Breakout_Game.Game.Forms;

namespace Breakout_Game.Game.Events{
    public static class EventListener{

        public static void InitEventListener(){
            CreateFormEvent.Handler += OnFormCreate;
        }

        
        public static void OnTestEv(object sender, EventArgs e){
            Console.WriteLine("Work");
        }

        public static void OnFormCreate(object sender, EventArgs e){
            CreateFormEvent form = sender as CreateFormEvent;
            if (form != null) {
                if (form.GetForm() is Brick) {
                    Brick brick = form.GetForm() as Brick;
                    if (brick != null) {

                    }
                }
            }
 
        }
    }
}