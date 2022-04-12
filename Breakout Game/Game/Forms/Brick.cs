using System.Collections.Generic;
using Breakout_Game.Game.Utils;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using PrimitiveType = OpenTK.Graphics.OpenGL.PrimitiveType;

namespace Breakout_Game.Forms{
    internal class Brick : BaseForm{
        #region Attributes

        

        #endregion

        public Brick(List<Vector2> points) : base(points, "imgTest.bmp"){
            
        }

        protected override Dictionary<SideObject, List<Vector2>> GetSides(){
            return null;
        }

        public override void Update(){
        }

        public override void Draw(){
            GL.PushMatrix();
            
            base.Draw(PrimitiveType.Quads);
            
            GL.PopMatrix();
        }
    }
}