using System;
using Breakout_Game.Game;
using Breakout_Game.Game.Forms;
using Breakout_Game.Game.Levels;
using Breakout_Game.Game.Menu;
using Breakout_Game.Game.Utils;
using OpenTK;
using OpenTK.Input;

namespace Breakout_Game.Game.UserInterac{
    internal static class UserControl{

        private static KeyboardState _keyboardState;
        private static MouseEventArgs _mouseEventArgs;

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
                MenuManager.ChangeMenu();
                Game.IsGamePause = (!Game.IsGamePause);
                System.Threading.Thread.Sleep(300);
            }
            else if (_keyboardState.IsKeyDown(Key.Space)) {
                Game.IsGameStarted = true;
            }
        }

        internal static void OnMouseDown(object sender, MouseEventArgs args){
            _mouseEventArgs = args;
            var (xMouse, yMouse) = Utils.Utils.Map(_mouseEventArgs.X, _mouseEventArgs.Y);
            
            if (args.Mouse.IsButtonDown(MouseButton.Left)) {

                Log.Send("UserControl", "Left Mouse Button clicked !", LogType.Info);
                if (Game.IsGamePause || !Game.IsGameStarted) {
                    int i = 0;
                    foreach (var actualMenuText in MenuManager.ActualMenu.Texts) {
                        if (Utils.Utils.IsPointIsInRect(
                                actualMenuText.getPosition(),
                                actualMenuText.getWidth(),
                                actualMenuText.getHeight(), new Vector2(xMouse, yMouse))) {
                            MenuManager.ActualMenu.DoAction(i);
                        }

                        i++;
                    }
                }

                System.Threading.Thread.Sleep(300);
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