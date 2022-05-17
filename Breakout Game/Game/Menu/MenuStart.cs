using System.Collections.Generic;
using System.Drawing;
using Breakout_Game.Game.Utils;

namespace Breakout_Game.Game.Menu{
    public class MenuStart : IMenu{
        
        public List<Text.Text> Texts{ get; set; }

        private const int MenuWidth = 100;
        private const int MenuHeight = 30;

        public MenuStart(){
            this.Texts = new List<Text.Text> {
                new Text.Text(MenuManager.StartPoint, MenuWidth, MenuHeight, "Commencer", Color.DimGray,
                    solidBrush: new SolidBrush(Color.White)),
            };
            
            this.Texts.Add(new Text.Text(
                MenuManager.AddVerticalGap(MenuManager.StartPoint, this.Texts[0].getHeight() + 20),
                MenuWidth,
                MenuHeight,
                "Retour",
                Color.DimGray,
                solidBrush: new SolidBrush(Color.White)));
        }

        public void DoAction(int textPosition){
            switch (textPosition) {
                case 0:
                    Game.GameAction(GameAction.Start);
                    return;
                case 1:
                    Game.GameAction(GameAction.Back);
                    return;
            }
        }

        public void Draw(){
            foreach (var text in this.Texts) {
                text.Draw();
            }
        }
    }
}