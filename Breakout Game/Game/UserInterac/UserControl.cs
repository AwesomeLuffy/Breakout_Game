using System;
using Breakout_Game.Game;
using Breakout_Game.Game.Forms;
using Breakout_Game.Game.Utils;
using OpenTK;
using OpenTK.Input;

namespace Breakout_Game.Game.UserInterac{
    internal static class UserControl{

        internal static void AnyKeyDown(){
            var state = Keyboard.GetState();
            if (state.IsKeyDown(Key.Right)){
                foreach (var renderable in Game.Renderables) {
                    if (renderable is Racket racket) {
                        racket.SetDirection(Direction.Right).Update();
                    }
                }
            }
            else if (state.IsKeyDown(Key.Left)) {
                foreach (var renderable in Game.Renderables) {
                    if (renderable is Racket racket) {
                        racket.SetDirection(Direction.Left).Update();
                    }
                }
            }
            else if (state.IsKeyDown(Key.P) || state.IsKeyDown(Key.Escape)) {
                //TODO Pause
            }
            else if (state.IsKeyDown(Key.Space)){
                //TODO START
            }
        }
        
    }
}