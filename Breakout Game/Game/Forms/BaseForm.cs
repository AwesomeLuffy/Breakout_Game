using System;
using System.Collections.Generic;
using System.Linq;
using Breakout_Game.Game.Events;
using Breakout_Game.Game.Texture;
using Breakout_Game.Game.Utils;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Breakout_Game.Game.Forms{
    internal abstract class BaseForm : IRenderable{
        #region Attributes
        


        private readonly List<Vector2> _coordinates; //Texture
        protected readonly List<Vector2> _points; //Form Position
        private Vector3 _colorRGB;


        private int _textureId;

        #endregion

        protected BaseForm(List<Vector2> points, string textureName){
            if (!(points.Count() <= 4)) return;
            
            this._textureId = RessourceLoader.CheckAndLoadTexture(textureName);
            
            this._points = points;

            this._coordinates = new List<Vector2>() {
                new Vector2(.0f, 1.0f),
                new Vector2(1.0f, 1.0f),
                new Vector2(1.0f, .0f),
                new Vector2(.0f, .0f)
            };

            this._colorRGB = new Vector3(.0f, .5f, .8f);
            
            Game.CallEvent(new CreateFormEvent(this));

        }



        #region Getter
        

        public abstract Dictionary<SideObject, List<Vector2>> GetSides();

        #endregion

        #region Updating

        public virtual void ChangeTexture(string textureName){
            if (!(this is IEditableTexture)) {
                Console.WriteLine("This Form is not Editable !");
                return;
            }
            this._textureId = RessourceLoader.CheckAndLoadTexture(textureName);
        }

        public abstract void Update();

        protected void Draw(PrimitiveType type){
            GL.BindTexture(TextureTarget.Texture2D, this._textureId);
            GL.Begin(type);

            if (type is PrimitiveType.TriangleFan) {
                // for (int i = 0; i < 360; i++)
                // {
                //     GL.Vertex2((this._points[0].X + Ball.Radius) + Math.Cos(i) * Ball.Radius, (this._points[0].Y - Ball.Radius) + Math.Sin(i) * Ball.Radius);
                // }
            }
            else if(type is PrimitiveType.Quads){
                for (int i = 0; i < this._points.Count(); i++) {
                    GL.TexCoord2(this._coordinates[i]);
                    GL.Vertex2(this._points[i]);
                }
            }



            GL.End();
        }

        public abstract void Draw();

        #endregion

    }
}