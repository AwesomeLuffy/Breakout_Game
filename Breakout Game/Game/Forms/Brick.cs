using System;
using System.Collections.Generic;
using System.Threading;
using Breakout_Game.Game.Events;
using Breakout_Game.Game.Utils;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using PrimitiveType = OpenTK.Graphics.OpenGL.PrimitiveType;

namespace Breakout_Game.Game.Forms{
    internal class Brick : BaseForm, IEditableTexture{
        #region Attributes

        public const float LenghtBrick = 50.0f;
        public const float HeightBrick = 20.0f;
        
        // private const string LevelOneTextureName = "brick_lvl_one.bmp";
        private const string LevelTwoTextureName = "brick_lvl_two.bmp";
        private const string LevelOneTextureName = "imgTest.bmp";
        private const string LevelThreeTextureName = "brick_lvl_three.bmp";
        private const string IndestructibleTextureName = "indestructible.bmp";
        
        private byte _level;
        
        private string _textureName;

        private bool IsInvincible = false;
        
        
        internal byte Level{
            get => this._level;
            set => this._level = (byte) (value > 4 ? 0 : value);
            }

        internal bool IsInDestruction{ get; set; } = false;

        internal bool IsActive{ get; set; } = true;

        #endregion

        #region Constructors

        public Brick(Vector2 origin, byte level = 1) :
            this(
                points: (new List<Vector2>() {
                    {origin},
                    {new Vector2(origin.X + LenghtBrick, origin.Y)},
                    {new Vector2(origin.X + LenghtBrick, origin.Y + HeightBrick)},
                    {new Vector2(origin.X, origin.Y + HeightBrick)}
                }),
                level: level,
                texture:
                ((level == 4)
                    ? IndestructibleTextureName
                    : ((level == 3)
                        ? LevelThreeTextureName
                        : ((level == 2) ? LevelTwoTextureName : LevelOneTextureName)))){
            this.IsInvincible = (this.Level == 4);
        }

        public Brick(List<Vector2> points, byte level, string texture) : base(points, texture){
            
            this.Level = level;
        }
        
        

        #endregion


        /*Sides Documentation
         *
         *             TOP
         * 
         * -D-   T1            T0    -C-
         * L0    |-------------| R1
         *       |             |
         * Left  |             |  Right
         *       |             | 
         * L1    |-------------| R0
         *-A-  B0            B1    -B-
         *0:0       Bottom
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

        internal void RemoveLevel(){
            this.Level -= 1;
            Game.CallEvent(new BrickDamage(this, 1));
        }

        internal void DestructBrick(){
            this.IsInDestruction = true;
            //TODO
            int i = 5;
            var task = new Thread(() => {
                while (i > 0) {
                    i--;
                    System.Threading.Thread.Sleep(5000);
                }

            });
            task.Start();
            if(i == 0)
            {
                task.Abort();
            }
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