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

            if (_keyboardState.IsKeyDown(Key.Right) || _keyboardState.IsKeyDown(Key.A)) {
                if (Game.IsGamePause) return;
                Game.Racket.SetDirection(Direction.Right).Update();
            }
            else if (_keyboardState.IsKeyDown(Key.Left) || _keyboardState.IsKeyDown(Key.D)) {
                if (Game.IsGamePause) return;
                Game.Racket.SetDirection(Direction.Left).Update();
            }
            else if (_keyboardState.IsKeyDown(Key.P) || _keyboardState.IsKeyDown(Key.Escape)) {
                MenuManager.ChangeMenu();
                Game.IsGamePause = (!Game.IsGamePause);
                System.Threading.Thread.Sleep(300);
            }
            else if (_keyboardState.IsKeyDown(Key.Space)) {
                Game.GameAction(GameAction.Start);
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