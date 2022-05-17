using System;
using System.Collections.Generic;
using System.Drawing;
using Breakout_Game.Game.Text;
using Breakout_Game.Game.Utils;
using OpenTK;

namespace Breakout_Game.Game.Menu{
    public class MenuPause : IMenu{

        public List<Text.Text> Texts {get; set;}

        private const int MenuWidth = 100;
        private const int MenuHeight = 30;

        public MenuPause(){
            this.Texts = new List<Text.Text> {
                new Text.Text(
                    MenuManager.StartPoint,
                    100,
                    30,
                    "Reprendre",
                    Color.DimGray,
                    solidBrush: new SolidBrush(Color.White)),
            };
            this.Texts.Add(new Text.Text(
                MenuManager.AddVerticalGap(MenuManager.StartPoint, this.Texts[0].getHeight() + 20),
                100,
                30,
                "Retour",
                Color.DimGray,
                solidBrush: new SolidBrush(Color.White)));
        }

        public void DoAction(int textPosition){
            switch (textPosition) {
                case 0 : {
                    Game.GameAction(GameAction.Resume);
                    return;
                }
                case 1: {
                    Game.GameAction(GameAction.Back);
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