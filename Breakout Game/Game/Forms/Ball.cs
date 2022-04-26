using System;
using System.Collections.Generic;
using Breakout_Game.Game.Texture;
using Breakout_Game.Game.Utils;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Breakout_Game.Game.Forms
{
    internal class Ball : BaseForm
    {
        #region Attributs
        private float verticalMove;
        private float verticalIncrement;
        private float horizontalMove;
        private float horizontaIncrement;
        private int damageValue = 1;
        private int textureID;
        #endregion
        public Ball(Vector2 basePosition, int width, int height, string textureName) :
            this(
                points: (new List<Vector2>()
                {
                    {new Vector2(basePosition.X, basePosition.Y - height)},
                    {new Vector2(basePosition.X + width, basePosition.Y - height)},
                    {new Vector2(basePosition.X + width, basePosition.Y)},
                    {basePosition}
                }),
                textureName: textureName)
        {
        }

        public Ball(List<Vector2> points, string textureName) : base(points, textureName)
        {
            verticalMove = 0.0f;
            horizontalMove = 0.0f;
            verticalIncrement = 1.5f;
            horizontaIncrement = 1.0f;

            textureID = RessourceLoader.GenId();
            RessourceLoader.LoadTexture(textureID, textureName);
        }
        public override void Draw()
        {
            GL.PushMatrix();
            GL.Translate(horizontalMove, horizontalMove, 0.0f);
            base.Draw(PrimitiveType.Quads);
            GL.PopMatrix();
        }
        public override Dictionary<SideObject, List<Vector2>> GetSides()
        {
            Dictionary<SideObject, List<Vector2>> listSide = new Dictionary<SideObject, List<Vector2>>();

            List<Vector2> points = new List<Vector2>()
            {
                {new Vector2(_points[0].X + horizontalMove, _points[0].Y + verticalMove)},
                {new Vector2(_points[1].X + horizontalMove, _points[1].Y + verticalMove)},
                {new Vector2(_points[2].X + horizontalMove, _points[2].Y + verticalMove)},
                {new Vector2(_points[3].X + horizontalMove, _points[3].Y + verticalMove)}
            };

            listSide[SideObject.Bottom] = new List<Vector2> { points[0], points[1] };
            listSide[SideObject.Top] = new List<Vector2> { points[3], points[2] };
            listSide[SideObject.Left] = new List<Vector2> { points[0], points[3] };
            listSide[SideObject.Right] = new List<Vector2> { points[1], points[2] };

            return listSide;
        }
        public override void Update()
        {
            //Console.WriteLine("========================================");
            //Console.WriteLine("points[0].X = " + _points[0].X.ToString());
            //Console.WriteLine("points[0].Y = " + _points[0].Y.ToString());
            //Console.WriteLine("points[1].X = " + _points[1].X.ToString());
            //Console.WriteLine("points[1].Y = " + _points[1].Y.ToString()); 
            //Console.WriteLine("points[2].X = " + _points[2].X.ToString());
            //Console.WriteLine("points[2].Y = " + _points[2].Y.ToString());
            //Console.WriteLine("points[3].X = " + _points[3].X.ToString());
            //Console.WriteLine("points[3].Y = " + _points[3].Y.ToString());
            //Console.WriteLine("========================================");
            //Console.WriteLine("horizontalMove     = " + horizontalMove.ToString()); 
            //Console.WriteLine("horizontaIncrement = " + horizontaIncrement.ToString());
            //Console.WriteLine("verticalMove       = " + verticalMove.ToString());
            //Console.WriteLine("verticalIncrement  = " + verticalIncrement.ToString());


            if (verticalMove + verticalIncrement >= 150.0f - _points[3].Y
                || verticalMove + verticalIncrement <= -150.0f - _points[0].Y)
            {
                verticalIncrement *= -1.0f;
            }
            if (horizontalMove + horizontaIncrement >= 300.0f - _points[2].X
                || horizontalMove + horizontaIncrement <= -300.0f - _points[3].X)
            {
                horizontaIncrement *= -1.0f;
            }

            horizontalMove += horizontaIncrement;
            verticalMove += verticalIncrement;
        }
        public void invertDirection()
        {
            horizontaIncrement *= -1.0f;
            verticalIncrement *= -1.0f;
        }
        public int getDommage()
        {
            return damageValue;
        }
    }
}