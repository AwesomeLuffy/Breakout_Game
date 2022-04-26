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
        public static readonly Text Text3 = new Text(
            new Vector2(-100, -100),    
            5,
            290,
            "text-3",
            Color.Black
        );
        public static readonly Text Text4 = new Text(
            new Vector2(100, -100),    
            5,
            290,
            "text-4",
            Color.Black
        );

        static TextManager()
        {
            Texts = new List<Text>()
            {
                Text1,
                Text2,
                Text3,
                Text4
            };
        }
        public static void init() { }
    }
}
