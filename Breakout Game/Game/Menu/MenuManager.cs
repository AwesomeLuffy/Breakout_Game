using Breakout_Game.Game.Utils;
using OpenTK;

namespace Breakout_Game.Game.Menu{
    public static class MenuManager{
        
        internal static readonly Vector2 StartPoint = new Vector2(-80, 40);

        internal static IMenu ActualMenu = new MenuStart();


        internal static void ChangeMenu(string name = "pause"){
            ActualMenu = name switch {
                "pause" => new MenuPause(),
                "start" => new MenuStart(),
                "level" => new MenuLevel(),
                _ => ActualMenu
            };
            Log.Send("MenuManager", "Actual Menu changed to " + ActualMenu.ToString(), LogType.Info);
        }
        internal static Vector2 AddStartPointVerticalGap(Vector2 point, int value){
            return new Vector2(point.X, point.Y - (point.Y + value));
        }

    }
}