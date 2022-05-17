using System;
using System.Collections.Generic;
using System.Drawing;
using Breakout_Game.Game.Events;
using Breakout_Game.Game.Utils;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Breakout_Game.Game.Forms{
    internal class Racket : Brick{

        private float _incrementFactor = 4.0f; //Speed
        private float horizontalMove = .0f;
        private Direction Direction;
        private static readonly Color DefaultBackground = Color.LightGray;
        
        public Racket() : base(new Vector2(-30, -130), textureName: "brick_blue.bmp"){    
        }

        public override Dictionary<SideObject, List<Vector2>> GetSides(){
            Dictionary<SideObject, List<Vector2>> sides = new Dictionary<SideObject, List<Vector2>>();

            var i = 0;
            foreach (SideObject side in Enum.GetValues(typeof(SideObject))) {
                sides[side] = new List<Vector2>() {
                    {new Vector2(this._points[i].X + this.horizontalMove, this._points[i].Y)},//0 Point
                    
                    {new Vector2(this._points[(i + 1 > 3) ? 0 : i + 1].X + this.horizontalMove,
                    this._points[(i + 1 > 3) ? 0 : i + 1].Y)}//1 Point
                };
                i++;
            }
            return sides;
        }

        public Racket SetDirection(Direction direction){
            if (direction == this.Direction) return this;
            this.Direction = direction;
            this._incrementFactor *= -1.0f;
            return this;
        }

        public override void Update(){ 
            if (horizontalMove + _incrementFactor >= 300.0f - _points[2].X
                || horizontalMove + _incrementFactor <= -300.0f - _points[3].X) {
                return;
            }
            this.horizontalMove += this._incrementFactor;
        }

        public override void Draw(){
            GL.PushMatrix();
            GL.Translate(this.horizontalMove, 0.0f, 0.0f);
            base.Draw(PrimitiveType.Quads);
            GL.PopMatrix();
        }

        public Direction ImpactDirection(){
            //TODO
            return Direction.Left;
        }
    }
}