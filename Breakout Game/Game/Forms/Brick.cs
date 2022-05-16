using System;
using System.Collections.Generic;
using System.Threading;
using Breakout_Game.Game.Events;
using Breakout_Game.Game.Levels;
using Breakout_Game.Game.Utils;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using PrimitiveType = OpenTK.Graphics.OpenGL.PrimitiveType;

namespace Breakout_Game.Game.Forms{
    internal class Brick : BaseForm, IEditableTexture{
        #region Attributes

        public const float LenghtBrick = 50.0f;
        public const float HeightBrick = 20.0f;
        
        // internal const string LevelOneTextureName = "brick_lvl_one.bmp";
        internal const string LevelOneTextureName = "bleu.png";
        internal const string LevelTwoTextureName = "brick_lvl_two.bmp";
        internal const string LevelThreeTextureName = "brick_lvl_three.bmp";
        internal const string IndestructibleTextureName = "indestructible.bmp";
        
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

        public Brick(Vector2 origin, byte level = 1, string textureName = Brick.LevelOneTextureName) :
            this(
                points: (new List<Vector2>() {
                    {origin},
                    {new Vector2(origin.X + LenghtBrick, origin.Y)},
                    {new Vector2(origin.X + LenghtBrick, origin.Y + HeightBrick)},
                    {new Vector2(origin.X, origin.Y + HeightBrick)}
                }),
                level: level,
                texture: textureName){
        }

        public Brick(List<Vector2> points, byte level, string texture) : base(points, texture){
            this.Level = level;
            this.IsInvincible = (this.Level == 4);
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
        
        internal static string GetTextureFromLevel(int lvl){
            return lvl switch {
                1 => Brick.LevelOneTextureName,
                2 => Brick.LevelTwoTextureName,
                3 => Brick.LevelThreeTextureName,
                4 => Brick.IndestructibleTextureName,
                _ => Brick.LevelOneTextureName
            };

        }

        internal bool AddLevel(){
            if (this.Level + 1 > 3) {
                return false;
            }
            this.Level += 1;
            this.ChangeTexture(Brick.GetTextureFromLevel(this.Level));
            return true;
        }

        internal void RemoveLevel(){
            this.Level -= 1;
            Game.CallEvent(new BrickDamage(this, 1));
        }

        internal void DestructBrickAnimation(){
            this.IsInDestruction = true;
            
            new Thread(() => {
                lock (this) {
                    this.ChangeTexture(LevelThreeTextureName);
                    System.Threading.Thread.Sleep(2000);
                    this.ChangeTexture(LevelTwoTextureName);
                    System.Threading.Thread.Sleep(2000);
                    this.ChangeTexture(LevelOneTextureName);
                    System.Threading.Thread.Sleep(2000);
                }
                Game.CallEvent(new BrickDestroyAnimationFinished(this));
                this.IsInDestruction = false;
            }).Start();
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