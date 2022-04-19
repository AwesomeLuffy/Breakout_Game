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

        public static readonly Text TestText = new Text(
                220,
                25, 
                "TXT HERE",
                new PointF(0.0f, 0.0f)
            );

        static TextManager()
        {
            Texts = new List<Text>()
            {
                TestText
            };
        }
        public static void init() { }
    }
}
