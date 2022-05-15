using System;
using System.Collections.Generic;
using System.Drawing;
using Breakout_Game.Game.Text;
using OpenTK;

namespace Breakout_Game.Game.Menu{
    public class MenuPause : IMenu{

        internal List<Text.Text> _texts = new List<Text.Text>();

        private const int MenuWidth = 100;
        private const int MenuHeight = 30;

        public MenuPause(){
            this._texts.Add(new Text.Text(MenuManager.StartPoint, 100, 30, "Reprendre", Color.DimGray,
                solidBrush: new SolidBrush(Color.White)));
            
            this._texts.Add(new Text.Text(MenuManager.AddStartPointVerticalGap(MenuManager.StartPoint, 20),
                100,
                30,
                "Quitter",
                Color.DimGray,
                solidBrush: new SolidBrush(Color.White)));
        }
        
        

        public void Draw(){
            foreach (var text in this._texts) {
                text.Draw();
            }
        }
    }
}