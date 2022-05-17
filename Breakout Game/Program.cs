using OpenTK;
using OpenTK.Graphics;

namespace Breakout_Game{
    internal static class Program{
        public const int WindowWidth = 1200;
        public const int WindowHeight = 600;
        public static void Main(string[] args){

            Game.Game.GetInstance(new GameWindow(
                WindowWidth,
                WindowHeight,
                GraphicsMode.Default,
                "Breakout Game")
            );
            
        }
    }
}