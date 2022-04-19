using System;
using System.Collections.Generic;
using System.Drawing;
using Breakout_Game.Game.Utils;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Breakout_Game.Game.Forms{
    internal class Racket : Brick{

        private float _incrementFactor = 7.0f; //Speed
        private float horizontalMove = .0f;
        private Direction Direction;
        private static readonly Color DefaultBackground = Color.LightGray;
        


        public Racket() : base(new Vector2(0, -130)){
            
        }

        public void SetDirection(Direction direction){
            if (direction == this.Direction) return;
            this.Direction = direction;
            this._incrementFactor *= -1.0f;
        }

        public override void Update(){
            this.horizontalMove += this._incrementFactor;
        }

        public override void Draw(){
            GL.PushMatrix();

            GL.Translate(this.horizontalMove, 0.0f, 0.0f);
            
            base.Draw(PrimitiveType.Quads);

            GL.PopMatrix();
            
        }
    }
}