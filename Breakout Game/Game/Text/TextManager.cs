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

        public static readonly Text Text1 = new Text(
                new Vector2(-100, 100),    
                250,
                5,
                "text-1",
                Color.Black,
                new Font(FontFamily.GenericSansSerif, 11),
                new SolidBrush(Color.Yellow)
            );
        public static readonly Text Text2 = new Text(
            new Vector2(-100, -100),    
            250,
            5,
            "text-2",
            Color.Black
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
                Text1,
                Text2,
                CompteurPoint,
                CompteurBall
            };
        }
        public static void init() { }
    }
}
