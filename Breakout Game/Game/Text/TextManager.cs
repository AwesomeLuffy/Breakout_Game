using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout_Game.Game.Text
{
    public static class TextManager
    {
        private static IList<Text> Texts;

        public static readonly Text CompteurNiveau = new Text(
            new Vector2(230, -80),    
            80,
            30,
            (Game.ActualLevelNumber.ToString() + " lvl")
        );
        public static readonly Text CompteurPoint = new Text(
            new Vector2(230, -140),    
            80,
            30,
            (Game.PointCounter.ToString() + " pts")
        );
        public static readonly Text CompteurBall = new Text(
            new Vector2(230, -110),    
            80,
            30,
            Game.BallCounter.ToString() + " ball"
            
        );

        static TextManager()
        {
            Texts = new List<Text>()
            {
                CompteurNiveau,
                CompteurPoint,
                CompteurBall
            };
        }
        public static void init() { }
    }
}
