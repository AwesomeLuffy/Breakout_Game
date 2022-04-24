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
                new Vector2(0, 0),    
                220,
                40,
                "text-1",
                Color.Black,
                new Font(FontFamily.GenericSansSerif, 11),
                new SolidBrush(Color.Yellow)
            );

        static TextManager()
        {
            Texts = new List<Text>()
            {
                Text1
            };
        }
        public static void init() { }
    }
}
