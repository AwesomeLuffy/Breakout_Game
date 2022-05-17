using System;
using System.Collections.Generic;
using Breakout_Game.Audio;
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
        private float horizontalIncrement;
        private int damageValue = 1;
        private int textureID;
        public bool isActivated;
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
                textureName: textureName){ }

        public Ball(List<Vector2> points, string textureName) : base(points, textureName)
        {
            verticalMove = 0.0f;
            horizontalMove = 0.0f;
            verticalIncrement = 1.5f;
            horizontalIncrement = 0.0f;//1.5
            isActivated = true;

            textureID = RessourceLoader.GenId();
            RessourceLoader.LoadTexture(textureID, textureName);
        }
        public override void Draw()
        {
            GL.PushMatrix();
            GL.Translate(horizontalMove, verticalMove, 0.0f);
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
            if (horizontalMove + horizontalIncrement >= 300.0f - _points[2].X
                || horizontalMove + horizontalIncrement <= -300.0f - _points[3].X)
            {
                horizontalIncrement *= -1.0f;
            }
            if (verticalMove + verticalIncrement >= 150.0f - _points[3].Y)
            {
                verticalIncrement *= -1.0f;
            }
            if (verticalMove + verticalIncrement <= -150.0f)
            {
                isActivated = false;
                Game.BallCounter -= 1;
                if (Game.BallCounter <= 0)
                {
                    Game.IsGameOVer = true;
                }
            }

            horizontalMove += horizontalIncrement;
            verticalMove += verticalIncrement;
        }
        public void invertDirection(string typeInversion, bool Gap = false)
        {
            if (typeInversion == "Default")
            {
                if (horizontalIncrement > 0)
                {
                    horizontalIncrement = 1.5f;
                }
                else
                {
                    horizontalIncrement = -1.5f;
                }
                verticalIncrement *= -1.0f;
            }
            else if (typeInversion == "Verticale")
            {
                verticalIncrement *= -1.0f;
            }
            else if (typeInversion == "Horizontale")
            {
                horizontalIncrement *= -1.0f;
            }
            
            
            if (Gap) {
                this.horizontalMove += this.horizontalIncrement + 0.8f;
                this.verticalMove += this.verticalIncrement + 0.8f;
            }
        }

        public void angleDirection(Direction direction)
        {
            if (direction == Direction.Right)
            {
                if (horizontalIncrement > 0)
                {
                    horizontalIncrement = 2.5f;
                }
                else
                {
                    horizontalIncrement = -0.5f;
                }
            }
            else if (direction == Direction.Left)
            {
                if (horizontalIncrement < 0)
                {
                    horizontalIncrement = -2.5f;
                }
                else
                {
                    horizontalIncrement = 0.5f;
                }
            }
        }
        public int getDommage()
        {
            return damageValue;
        }
    }
}