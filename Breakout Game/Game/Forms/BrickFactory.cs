using System.Diagnostics;
using OpenTK;

namespace Breakout_Game.Game.Forms{
    internal static class BrickFactory{

        internal static Brick CreateBrick(Vector2 origin, byte level, bool isSpe = false){
            return new Brick(origin, level, Brick.GetTextureFromLevel(level), isSpe);
        }
    }
}