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
    }
}