using System;
using System.Collections.Generic;
using Breakout_Game.Game.Utils;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Breakout_Game.Game.Forms{
    internal class Ball : BaseForm{

        private const float LenghtHeightBall = 70.0f;
        internal const float Radius = LenghtHeightBall / 2;

        public Ball(Vector2 origin, string textureName = "brick_lvl_two.bmp") :
            base((new List<Vector2>() {
                {origin},
                {new Vector2(origin.X, origin.Y - LenghtHeightBall)},
                {new Vector2(origin.X + LenghtHeightBall, origin.Y - LenghtHeightBall)},
                {new Vector2(origin.X + LenghtHeightBall, origin.Y)}
            }), textureName){
        }

        public override Dictionary<SideObject, List<Vector2>> GetSides(){
            Dictionary<SideObject, List<Vector2>> sides = new Dictionary<SideObject, List<Vector2>>();

            var i = 0;
            foreach (SideObject side in Enum.GetValues(typeof(SideObject))) {
                sides[side] = new List<Vector2>() {
                    {this._points[i]}, //0 Point
                    {this._points[(i + 1 > 3) ? 0 : i + 1]} //1 Point
                };
                i++;
            }

            return sides;
        }

        public override void Update(){
        }

        public override void Draw(){
            GL.PushMatrix();

            base.Draw(PrimitiveType.TriangleFan);

            GL.PopMatrix();
        }
    }
}