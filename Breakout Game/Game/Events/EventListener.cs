using System;
using Breakout.Game;

namespace Breakout_Game.Game.Events{
    public static class EventListener{

        public static void InitEventListener(){ }

        
        public static void OnTestEv(object sender, EventArgs e){
            Console.WriteLine("Work");
        }

        public static void OnFormCreate(object sender, EventArgs e){
            CreateFormEvent form = sender as CreateFormEvent;
            if (form != null) Console.WriteLine("Form created !" + form.GetTypeInstance());
        }
    }
}