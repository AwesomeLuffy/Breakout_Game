using System;
using Breakout_Game.Game;
using Breakout_Game.Game.Forms;
using Breakout_Game.Game.Utils;
using OpenTK.Input;

namespace Breakout_Game.Game.UserInterac{
    internal static class UserControl{

        internal static void OnKeyDown(object sender, KeyboardKeyEventArgs args){
            switch (args.Key) {
                case Key.Left:
                    foreach (var renderable in Game.Renderables) {
                        if (renderable is Racket racket) {
                            racket.SetDirection(Direction.Left).Update();
                        }
                    }
                    break;
                case Key.Right:
                    foreach (var renderable in Game.Renderables) {
                        if (renderable is Racket racket) {
                            racket.SetDirection(Direction.Right).Update();
                        }
                    }
                    break;
                case Key.P:
                case Key.Escape:
                    Game.GameAction("pause");
                    break;
            }
        }
        
    }
}