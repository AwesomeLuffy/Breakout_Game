using System.Collections.Generic;
using System.Drawing;
using OpenTK;

namespace Breakout_Game.Game.Menu{
    public class MenuLevel: IMenu{
        
        internal List<Text.Text> _texts = new List<Text.Text>();
        
        private const int MenuWidth = 150;
        private const int MenuHeight = 30;
        //TODO Text base pos
        public MenuLevel(){
            this._texts.Add(new Text.Text(MenuManager.StartPoint,
                MenuWidth,
                MenuHeight,
                "Niveau 1",
                Color.DimGray,
                solidBrush: new SolidBrush(Color.White)));
            
            this._texts.Add(new Text.Text(MenuManager.AddStartPointVerticalGap(MenuManager.StartPoint, 20),
                MenuWidth,
                MenuHeight,
                "Niveau 2",
                Color.DimGray,
                solidBrush: new SolidBrush(Color.White)));

            this._texts.Add(
                new Text.Text(MenuManager.AddStartPointVerticalGap(MenuManager.StartPoint, (20 + MenuHeight * 2)),
                MenuWidth,
                MenuHeight,
                "Niveau 3",
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