using System;
using System.Collections.Generic;
using Breakout_Game.Game.Utils;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Breakout_Game.Game.Forms{
    internal class Ball : BaseForm
    {
        #region Attributs
        private float verticalMove;
        private float verticalIncrement;
        private float horizontalMove;
        private float horizontaIncrement;
        private float velocity = 1.0f;
        private int damageValue = 1;
        #endregion // Attributs
        public Ball(List<Vector2> points, string textureName) : base(points, textureName)
        {
            verticalMove = 0.0f;
            verticalIncrement = 1.5f;
            horizontalMove = 0.0f;
            horizontaIncrement = 1.5f;
        }
        public override void Draw()
        {
            GL.PushMatrix();
            GL.Translate(horizontalMove, horizontalMove, 0.0f);
            base.Draw(PrimitiveType.Polygon);
            GL.PopMatrix();
        }
        public override Dictionary<SideObject, List<Vector2>> GetSides()
        {
            throw new NotImplementedException();
        }
        public override void Update()
        {
            if(verticalMove + verticalIncrement >= 150.0f - _points[0].Y ||
                )
            {

            }
        }
    }
}