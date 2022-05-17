using System.Collections.Generic;
using System.Linq;
using OpenTK;

namespace Breakout_Game.Game.Utils{
    public static class Utils{
        
        public static bool IsValueInListExists<T>(IEnumerable<T> list, T obj){
            //Check if object is in a list
            return list.Any(n => n.Equals(obj));
        }

        public static bool IsPointIsInRect(Vector2 rectBasePos, float rectWidth, float rectHeight, Vector2 pointToCheck){
            return (pointToCheck.X >= rectBasePos.X && pointToCheck.X <= rectBasePos.X + rectWidth) &&
                   (pointToCheck.Y >= rectBasePos.Y && pointToCheck.Y <= rectBasePos.Y + rectHeight);
        }

        public static (int xMouse, int yMouse) Map(int x, int y){
            int xMouse =
                x * (GameBase.WindowOrthoMaxWidth - GameBase.WindowOrthoMinWidth) / Program.WindowWidth +
                GameBase.WindowOrthoMinWidth;
            int yMouse = -(y * (GameBase.WindowOrthoMaxHeight - GameBase.WindowOrthoMinHeight) / Program.WindowHeight +
                         GameBase.WindowOrthoMinHeight);
            return (xMouse, yMouse);
        }
    }
}