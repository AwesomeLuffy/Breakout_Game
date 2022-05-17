using System.Collections.Generic;
using System.Linq;
using OpenTK;

namespace Breakout_Game.Game.Utils{
    public static class Utils{
        
        /// <summary>
        /// Check if a value exists in a list
        /// </summary>
        /// <param name="list">List of object (any type allowed)</param>
        /// <param name="obj">The object to check</param>
        /// <typeparam name="T">Your type</typeparam>
        /// <returns></returns>
        public static bool IsValueInListExists<T>(IEnumerable<T> list, T obj){
            //Check if object is in a list
            return list.Any(n => n.Equals(obj));
        }

        /// <summary>
        /// Check if a point [Vector2] is in a rectangle
        /// </summary>
        /// <param name="rectBasePos">Area (rectangle)  base position</param>
        /// <param name="rectWidth">Width of the rectangle</param>
        /// <param name="rectHeight">Height of the rectangle</param>
        /// <param name="pointToCheck">Point to check</param>
        /// <returns></returns>
        public static bool IsPointIsInRect(Vector2 rectBasePos, float rectWidth, float rectHeight, Vector2 pointToCheck){
            return (pointToCheck.X >= rectBasePos.X && pointToCheck.X <= rectBasePos.X + rectWidth) &&
                   (pointToCheck.Y >= rectBasePos.Y && pointToCheck.Y <= rectBasePos.Y + rectHeight);
        }

        /// <summary>
        /// Map a point in a Window to actual Ortho
        /// </summary>
        /// <param name="x">Actual X to Map</param>
        /// <param name="y">Actual Y to Map</param>
        /// <returns></returns>
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