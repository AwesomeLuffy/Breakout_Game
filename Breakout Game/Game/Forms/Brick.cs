using System;
using System.Collections.Generic;
using Breakout_Game.Game.Utils;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using PrimitiveType = OpenTK.Graphics.OpenGL.PrimitiveType;

namespace Breakout_Game.Game.Forms{
    internal class Brick : BaseForm{
        #region Attributes

        private byte _level;
        internal byte Level{
            get => this._level;
            set => this._level = (byte) (value > 3 ? 0 : value);
            }

        internal bool IsInDestruction{ get; set; } = false;

        internal bool IsActive{ get; set; } = true;

        #endregion

        #region Constructors

        public Brick(List<Vector2> points) : this(points, 1, "imgTest.bmp"){
        }

        public Brick(List<Vector2> points, byte level) : this(points, level, "imgTest.bmp"){}

        public Brick(List<Vector2> points, string texture) : this(points, 1, texture){}

        public Brick(List<Vector2> points, byte level, string texture) : base(points, texture){
            this.Level = level;
        }

        #endregion


        /*Sides Documentation
         *
         *             TOP
         * 0:0
         * -A-   T1            T0    -D-
         * L0    |-------------| R1
         *       |             |
         * Left  |             |  Right
         *       |             | 
         * L1    |-------------| R0
         *-B-  B0            B1    -C-
         *          Bottom
         * 
         * Creation order is -A- > -B- > -C- > -D-
         */
        public override Dictionary<SideObject, List<Vector2>> GetSides(){
            Dictionary<SideObject, List<Vector2>> sides = new Dictionary<SideObject, List<Vector2>>();

            var i = 0;
            foreach (SideObject side in Enum.GetValues(typeof(SideObject))) {
                sides[side] = new List<Vector2>() {
                    {this._points[i]},//0 Point
                    {this._points[(i + 1 > 3) ? 0 : i + 1]}//1 Point
                };
                i++;
            }
            
            return sides;

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