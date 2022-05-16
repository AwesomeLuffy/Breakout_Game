using System;
using System.Collections.Generic;
using System.Linq;
using Breakout_Game.Game.Forms;
using OpenTK;

namespace Breakout_Game.Game.Levels{
    internal class Level{
        
        public const int MaxBrickInARow = 9;
        public const int MaxBrickInColumn = 2;
        
        private const float HorizontalGap = 10;
        private const float VerticalGap = 5;
        private const float StartX = -270;
        private const float StartY = 120;

        internal int NumberOfBricks{ get; set; }
        internal bool haveSpecial{ get; set; }


        internal List<List<Brick>> bricks = new List<List<Brick>>();
        public Level(List<List<bool>> emplacement, bool haveSpecial = false){
            this.InitList();
            this.haveSpecial = haveSpecial;
            
            Vector2 originPoint = new Vector2(StartX, StartY);
            for (int i = 0; i < emplacement.Count; i++) {

                for (int j = 0; j < emplacement[i].Count; j++) {

                    if (emplacement[i][j]) {
                        this.bricks[i][j] = BrickFactory.CreateBrick(originPoint,
                        (byte) ((j == MaxBrickInARow - 1 || j == 0) ? 4 :
                            ((j == MaxBrickInARow - 2 || j == 1) ? 3 :
                                ((j == MaxBrickInARow - 3 || j == 2) ? 2 : 1)))
                        );
                        if (this.haveSpecial) {
                            if (!this.bricks[i][j].IsInvincible) {
                                if (new Random().Next(2, 4) == 3) {
                                    this.bricks[i][j].IsSpecial = true;
                                }
                            } 
                        }
                    }

                    originPoint.X += Brick.LenghtBrick + HorizontalGap;
                }
                originPoint.X = StartX;
                
                originPoint.Y -= Brick.HeightBrick + VerticalGap;
            }
        }

        private void InitList(){
            Brick defaultBrick = new Brick(new Vector2(0, 0));
            for (int i = 0; i < MaxBrickInColumn; i++) {
                this.bricks.Add(new List<Brick>());
            }

            for (int i = 0; i < this.bricks.Count; i++) {
                for (int j = 0; j < MaxBrickInARow; j++) {
                    this.bricks[i].Add(defaultBrick);
                }
            }
        }
    }
}