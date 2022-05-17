using System;
using System.Collections.Generic;
using System.Drawing;
using Breakout_Game.Game.Utils;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Breakout_Game.Game.Forms{
    internal class Racket : Brick{

        private float _incrementFactor = 4.0f; //Speed
        private float HorizontalMove{ get; set; }
        private Direction _direction;
        private static readonly Color DefaultBackground = Color.LightGray;
        private static readonly Vector2 BasePose = new Vector2(-15, -130);
        
        public Racket() : base(BasePose, textureName: "brick_blue.bmp")
        {
            this.HorizontalMove = BasePose.X;
        }
        
        public override Dictionary<SideObject, List<Vector2>> GetSides(){
            Dictionary<SideObject, List<Vector2>> sides = new Dictionary<SideObject, List<Vector2>>();

            var i = 0;
            foreach (SideObject side in Enum.GetValues(typeof(SideObject))) {
                sides[side] = new List<Vector2>() {
                    {new Vector2(this._points[i].X + this.HorizontalMove, this._points[i].Y)},//0 Point
                    
                    {new Vector2(this._points[(i + 1 > 3) ? 0 : i + 1].X + this.HorizontalMove,
                    this._points[(i + 1 > 3) ? 0 : i + 1].Y)}//1 Point
                };
                i++;
            }
            return sides;
        }

        public Racket SetDirection(Direction direction){
            if (direction == this._direction) return this;
            this._direction = direction;
            this._incrementFactor *= -1.0f;
            return this;
        }

        public override void Update(){ 
            if (this.HorizontalMove + _incrementFactor >= 300.0f - _points[2].X
                || this.HorizontalMove + _incrementFactor <= -300.0f - _points[3].X) {
                return;
            }
            this.HorizontalMove += this._incrementFactor;
        }

        public override void Draw(){
            GL.PushMatrix();
            GL.Translate(this.HorizontalMove, 0.0f, 0.0f);
            base.Draw(PrimitiveType.Quads);
            GL.PopMatrix();
        }

        internal void SetBasePos(){
            this.HorizontalMove = BasePose.X;
        }

    }
}