using Breakout_Game.Game.Utils;
using OpenTK;

namespace Breakout_Game.Game.Menu{
    public static class MenuManager{
        
        internal static readonly Vector2 StartPoint = new Vector2(-60, 80);

        internal static IMenu ActualMenu = new MenuLevel();

        internal static bool IsAnyMenuActive = false;


        internal static void ChangeMenu(string name = "pause"){
            ActualMenu = name switch {
                "pause" => new MenuPause(),
                "start" => new MenuStart(),
                "level" => new MenuLevel(),
                _ => ActualMenu
            };
            Log.Send("MenuManager", "Actual Menu changed to " + ActualMenu, LogType.Info);
        }
        internal static Vector2 AddVerticalGap(Vector2 point, int value){
            return new Vector2(point.X, point.Y - value);
        }

    }
}