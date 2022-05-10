using OpenTK;

namespace Breakout_Game.Game.Menu{
    public static class MenuManager{
        
        internal static readonly Vector2 StartPoint = new Vector2(-80, 40);

        internal static IMenu ActualMenu = new MenuLevel();


        internal static Vector2 AddStartPointVerticalGap(Vector2 point, int value){
            return new Vector2(point.X, point.Y - (point.Y + value));
        }

        //TODO MENU PAUSE
        //TODO START MENU
        
    }
}