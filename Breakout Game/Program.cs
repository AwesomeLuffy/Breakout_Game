using OpenTK;
using OpenTK.Graphics;

namespace Breakout_Game{
    internal static class Program{
        public static void Main(string[] args){
            
            Game.Game.GetInstance(new GameWindow(
                1200,
                600,
                GraphicsMode.Default,
                "Breakout Game")
            );
            
        }
    }
}