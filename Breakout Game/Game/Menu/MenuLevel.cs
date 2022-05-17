using System.Collections.Generic;
using System.Drawing;
using Breakout_Game.Game.Utils;
using OpenTK;

namespace Breakout_Game.Game.Menu{
    public class MenuLevel: IMenu{
        
        public List<Text.Text> Texts{ get; set; }
        
        private const int MenuWidth = 150;
        private const int MenuHeight = 30;
        //TODO Text base pos
        public MenuLevel(){
            this.Texts = new List<Text.Text> {
                new Text.Text(MenuManager.StartPoint,
                    MenuWidth,
                    MenuHeight,
                    "Niveau 1",
                    Color.DimGray,
                    solidBrush: new SolidBrush(Color.White)),
                new Text.Text(MenuManager.AddVerticalGap(MenuManager.StartPoint, 20),
                    MenuWidth,
                    MenuHeight,
                    "Niveau 2",
                    Color.DimGray,
                    solidBrush: new SolidBrush(Color.White))
            };

            this.Texts.Add(new Text.Text(
                MenuManager.AddVerticalGap(this.Texts[1].getPosition(), this.Texts[1].getHeight() * 2 + 20),
                MenuWidth,
                MenuHeight,
                "Niveau 3",
                Color.DimGray,
                solidBrush: new SolidBrush(Color.White))
            );
        }

        public void DoAction(int textPosition){
            switch (textPosition) {
                case 0: {
                    Game.GameAction(GameAction.GenerateLevel, new object[]{1});
                    return;
                }
                case 1: {
                    Game.GameAction(GameAction.GenerateLevel, new object[]{2});
                    return;
                }
                case 2: {
                    Game.GameAction(GameAction.GenerateLevel, new object[]{3});
                    return;
                }
            }
        }


        public void Draw(){
            foreach (var text in this.Texts) {
                text.Draw();
            }
        }

    }
}