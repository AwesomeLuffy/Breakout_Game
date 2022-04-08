using System.Collections.Generic;
using System.Linq;

namespace Breakout_Game.Game.Utils{
    public static class Utils{
        
        public static bool IsValueInListExists<T>(IEnumerable<T> list, T obj){
            //Check if object is in a list
            return list.Any(n => n.Equals(obj));
        }
    }
}