using System;
using System.Collections.Generic;
using Breakout_Game.Game.Forms;
using OpenTK;

namespace Breakout_Game.Game.Levels{
    internal class Level{
        
        public const int MaxBrickInARow = 9;
        public const int MaxBrickInColumn = 4;
        
        private const float HorizontalGap = 10;
        private const float VerticalGap = 5;
        private const float StartX = -270;
        private const float StartY = 120;

        internal int NumberOfBricks{ get; set; }
        internal bool HaveSpecial{ get; set; }
        
        internal int LevelNumber{ get; set; }

        internal List<List<Brick>> bricks = new List<List<Brick>>();
        public Level(List<List<bool>> emplacement, bool haveSpecial = false){
            this.InitList();
            this.HaveSpecial = haveSpecial;
            
            Vector2 originPoint = new Vector2(StartX, StartY);
            for (int i = 0; i < emplacement.Count; i++) {

                for (int j = 0; j < emplacement[i].Count; j++) {

                    if (emplacement[i][j]) {
                        this.bricks[i][j] = BrickFactory.CreateBrick(originPoint,
                        (byte) ((j == MaxBrickInARow - 1 || j == 0) ? 4 :
                            ((j == MaxBrickInARow - 2 || j == 1) ? 3 :
                                ((j == MaxBrickInARow - 3 || j == 2) ? 2 : 1)))
                        );
                        if (this.HaveSpecial) {
                            if (!this.bricks[i][j].IsInvincible) {
                                if (new Random().Next(2, 4) == 3) {
                                    this.bricks[i][j].IsSpecial = true;
                                }
                            } 
                        }
                    }
                    else {
                        this.bricks[i][j] = null;
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

            foreach (var t in this.bricks) {
                for (int j = 0; j < MaxBrickInARow; j++) {
                    t.Add(defaultBrick);
                }
            }
        }
    }
}