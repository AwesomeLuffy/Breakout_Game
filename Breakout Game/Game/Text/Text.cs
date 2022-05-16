using System;
using System.Collections.Generic;
using System.Drawing;
using Breakout_Game.Game.Forms;
using Breakout_Game.Game.Texture;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Breakout_Game.Game.Text{
    public class Text : IDrawable{
        #region Attributes
        /*
         * Data Dict Composition
         * 
         * width -> Int
         * height -> Int
         * text -> string
         * background -> Color
         * police -> Font
         * solid_brush -> SolidBrush
         * position -> PointF
        */

        private Dictionary<string, object> _data;

        private List<Vector2> points;

        private readonly int textureID;
        #endregion
        internal Text(Vector2 basePos, int width, int height, string text, Color background = new Color(), Font police = null, SolidBrush solidBrush = null){

            this.textureID = RessourceLoader.GenId(); //Génération de l'ID de la texture pour le texte

            background = (background == Color.Empty) ? Color.LightGray : background;
            police = (police == null) ? new Font(FontFamily.GenericSansSerif, 11) : police;
            solidBrush = solidBrush ?? new SolidBrush(Color.Red);
            PointF position = new PointF(0.0f, 2.0f);

            if (_data == null)
            {
                this._data = new Dictionary<string, object>(); //Création de la dictionnary 
            }

            _data.Add("width", width);
            _data.Add("height", height);
            _data.Add("text", text);
            _data.Add("background", background);
            _data.Add("police", police);
            _data.Add("solid_brush", solidBrush);
            _data.Add("position", position);
            
            points = ConstructPosition(basePos, (int) this._data["width"], (int) this._data["height"]);
                        
            RessourceLoader.CreateText(this.textureID, this._data); //Création du texte
            RessourceLoader.LoadText(this.textureID, this._data); // Chargement du texte          

        }
        private static List<Vector2> ConstructPosition(Vector2 origin, int width, int height){
            List<Vector2> listPoint = new List<Vector2>
            {
                new Vector2(origin.X, origin.Y),
                new Vector2(origin.X + width, origin.Y),
                new Vector2(origin.X + width, origin.Y + height),
                new Vector2(origin.X, origin.Y + height),

            };
            return listPoint;
        }
        public void setText(string text){
            this._data["text"] = text;
            RessourceLoader.LoadText(this.textureID, this._data);
        } //TODO -> Exemple d'utilisation pour charger le texte et les nouvelles valeurs
        
        public void Draw(){
            GL.BindTexture(TextureTarget.Texture2D, this.textureID);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 1.0f);
            GL.Vertex2(points[0].X, points[0].Y);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex2(points[1].X, points[1].Y);
            GL.TexCoord2(1.0f, 0.0f);
            GL.Vertex2(points[2].X, points[2].Y);
            GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex2(points[3].X, points[3].Y);
            GL.End();
        }

        public object getPosition()
        {
            return points[0];
        }
        public object getWidth()
        {
            return _data["width"];
        }
        public object getHeight()
        {
            return _data["height"];
        }
    }
}