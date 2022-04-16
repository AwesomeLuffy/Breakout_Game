﻿using System.Collections.Generic;
using System.Linq;
using Breakout_Game.Game.Events;
using Breakout_Game.Game.Texture;
using Breakout_Game.Game.Utils;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Breakout_Game.Game.Forms{
    internal abstract class BaseForm : IUpdatable{
        #region Attributes

        private List<Vector2> _coordinates; //Texture
        protected List<Vector2> _points; //Form Position
        private Vector3 _colorRGB;

        private readonly int textureId;

        #endregion

        protected BaseForm(List<Vector2> points, string textureName){
            if (!(points.Count() <= 4)) return;
            
            this.textureId = RessourceLoader.GenId();
            RessourceLoader.LoadTexture(this.textureId, textureName);
            
            this._points = points;

            this._coordinates = new List<Vector2>() {
                new Vector2(.0f, 1.0f),
                new Vector2(1.0f, 1.0f),
                new Vector2(1.0f, .0f),
                new Vector2(.0f, .0f)
            };

            this._colorRGB = new Vector3(.0f, .5f, .8f);
            
            Breakout_Game.Game.Game.CallEvent(new CreateFormEvent(this));

        }

        #region Getter
        

        public abstract Dictionary<SideObject, List<Vector2>> GetSides();

        #endregion

        #region Updating

        public abstract void Update();

        protected void Draw(PrimitiveType type){
            GL.BindTexture(TextureTarget.Texture2D, this.textureId);
            GL.Begin(type);

            for (int i = 0; i < this._points.Count(); i++) {
                GL.TexCoord2(this._coordinates[i]);
                GL.Vertex2(this._points[i]);
            }

            GL.End();
        }

        public abstract void Draw();

        #endregion

    }
}