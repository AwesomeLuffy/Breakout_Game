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

        //public static readonly Text TestText = new Text(
        //        220,
        //        25,
        //        "TXT HERE",
        //        new PointF(0.0f, 0.0f)
        //    );
        //public static readonly Text TestDefaultText = new Text(
        //        220,
        //        25,
        //        "OTHER TXT HERE",
        //        new PointF(0.0f, -50.0f)
        //    );
        public static readonly Text Text1 = new Text(
                220,
                40,
                "TXT 2",
                new PointF(0.0f, 0.0f),
                Color.Black,
                new Font(FontFamily.GenericSansSerif, 11),
                new SolidBrush(Color.Yellow)
            );
        public static readonly Text Text2 = new Text(
                220,
                40,
                "TXT 1",
                new PointF(-250.0f, 0.0f),
                Color.Black,
                new Font(FontFamily.GenericSansSerif, 11),
                new SolidBrush(Color.Yellow)
            );
        //public static readonly Text Text3 = new Text(
        //        220,
        //        40,
        //        "TXT 3",
        //        new PointF(-100.0f, -100.0f),
        //        Color.Black,
        //        new Font(FontFamily.GenericSansSerif, 11),
        //        new SolidBrush(Color.Yellow)
        //    );

        static TextManager()
        {
            Texts = new List<Text>()
            {
                Text1,
                Text2
                //Text3
            };
        }
        public static void init() { }
    }
}
