using Breakout_Game.Game;
using OpenTK;
using OpenTK.Graphics;

namespace Breakout_Game{
    internal class Program{
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