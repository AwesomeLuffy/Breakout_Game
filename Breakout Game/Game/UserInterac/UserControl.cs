using System;
using Breakout_Game.Game;
using Breakout_Game.Game.Forms;
using Breakout_Game.Game.Levels;
using Breakout_Game.Game.Utils;
using OpenTK;
using OpenTK.Input;

namespace Breakout_Game.Game.UserInterac{
    internal static class UserControl{

        private static KeyboardState _keyboardState;

        internal static void AnyKeyDown(){
            _keyboardState = Keyboard.GetState();
            
            if (!(_keyboardState.IsAnyKeyDown)) {
                return; 
            }
            if (_keyboardState.IsKeyDown(Key.Right)) {
                if (Game.IsGamePause) return;
                foreach (var renderable in Game.Renderables) {
                    if (renderable is Racket racket) {
                        racket.SetDirection(Direction.Right).Update();
                    }
                }
            }
            else if (_keyboardState.IsKeyDown(Key.Left)) {
                if (Game.IsGamePause) return;
                foreach (var renderable in Game.Renderables) {
                    if (renderable is Racket racket) {
                        racket.SetDirection(Direction.Left).Update();
                    }
                }
            }
            else if (_keyboardState.IsKeyDown(Key.P) || _keyboardState.IsKeyDown(Key.Escape)) {
                Game.IsGamePause = (!Game.IsGamePause);
                System.Threading.Thread.Sleep(100);
            }
            else if (_keyboardState.IsKeyDown(Key.Space)) {
                Game.IsGameStarted = true;
            }
        }

        internal static (bool, Direction) IsRightOrLeftPress(){
            _keyboardState = Keyboard.GetState();
            if (_keyboardState.IsKeyDown(Key.Right)) {
                return (true, Direction.Right);
            }
            if (_keyboardState.IsKeyDown(Key.Left)) {
                return (true, Direction.Left);
            }

            return (false, Direction.None);
        }
        
    }
}