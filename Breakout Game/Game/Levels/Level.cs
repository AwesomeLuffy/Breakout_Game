using System;
using System.Collections.Generic;
using System.Linq;
using Breakout_Game.Game.Forms;
using OpenTK;

namespace Breakout_Game.Game.Levels{
    internal class Level{
        
        public const int MaxBrickInARow = 9;
        public const int MaxBrickInColumn = 6;
        
        private const float HorizontalGap = 10;
        private const float VerticalGap = 5;
        private const float StartX = -270;
        private const float StartY = 140;

        public int NumberOfBricks{ get; set; }
        
        internal List<List<Brick>> bricks = new List<List<Brick>>();
        
        public Level(List<List<bool>> emplacement){
            this.InitList();
            
            Vector2 originPoint = new Vector2(StartX, StartY);
            //TODO THREADING
            for (int i = 0; i < emplacement.Count; i++) {

                for (int j = 0; j < emplacement[i].Count; j++) {
                    if (emplacement[i][j]) {
                        
                        this.bricks[i].Insert(j, new Brick(originPoint,
                        (byte) ((j == MaxBrickInARow - 1 || j == 0) ? 4 :
                            ((j == MaxBrickInARow - 2 || j == 1) ? 3 :
                                ((j == MaxBrickInARow - 3 || j == 2) ? 2 : 1)))
                        ));
                    }

                    originPoint.X += Brick.LenghtBrick + HorizontalGap;
                }
                originPoint.X = StartX;
                
                originPoint.Y -= Brick.HeightBrick + VerticalGap;
            }
        }

        private void InitList(){
            for (int i = 0; i < MaxBrickInARow + 1; i++) {
                this.bricks.Insert(i, new List<Brick>());
            }
        }
    }
}