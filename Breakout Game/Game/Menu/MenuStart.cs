using System.Collections.Generic;
using System.Drawing;

namespace Breakout_Game.Game.Menu{
    public class MenuStart : IMenu{
        
        public List<Text.Text> Texts{ get; set; }

        private const int MenuWidth = 100;
        private const int MenuHeight = 30;

        public MenuStart(){
            this.Texts = new List<Text.Text> {
                new Text.Text(MenuManager.StartPoint, 100, 30, "Commencer", Color.DimGray,
                    solidBrush: new SolidBrush(Color.White)),
                new Text.Text(MenuManager.AddVerticalGap(MenuManager.StartPoint, 20),
                    100,
                    30,
                    "Quitter",
                    Color.DimGray,
                    solidBrush: new SolidBrush(Color.White))
            };
        }
        
        public void DoAction(int textPosition){}

        public void Draw(){
            foreach (var text in this.Texts) {
                text.Draw();
            }
        }
    }
}