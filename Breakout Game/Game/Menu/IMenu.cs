using System.Collections.Generic;
using Breakout_Game.Game.Forms;

namespace Breakout_Game.Game.Menu{
    internal interface IMenu : IDrawable{
        abstract List<Text.Text> Texts{ get; set; }
        void DoAction(int textPosition);
    }
}