using System;
using System.Collections.Generic;
using System.Drawing;
using Breakout_Game.Game.Forms;
using Breakout_Game.Game.Texture;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Breakout_Game.Game.Text{
    public class Text : IRenderable{
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
        
        private readonly int textureID;
        #endregion
        internal Text(int width, int height, string text, Color background, Font police, SolidBrush solidBrush, PointF position){

            this.textureID = RessourceLoader.GenId(); //Génération de l'ID de la texture pour le texte
            
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
            RessourceLoader.CreateText(this.textureID, this._data); //Création du texte
            RessourceLoader.LoadText(this.textureID, this._data); // Chargement du texte
        }

        public void setText(string text){
            this._data["text"] = text;
            RessourceLoader.LoadText(this.textureID, this._data);
        } //TODO -> Exemple d'utilisation pour charger le texte et les nouvelles valeurs

        public void Draw(){
            #region Commentaire
            //// Créer une image BMP pour recevoir le texte converti par le graphique
            //Bitmap bmpTxt = new Bitmap((int)this._data["width"], (int)this._data["height"], System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            //// Convertir le texte en graphique
            //Graphics graphique = Graphics.FromImage(bmpTxt);
            //graphique.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            //graphique.Clear((Color)this._data["background"]);
            //graphique.DrawString(this._data["text"].ToString(), (Font)this._data["police"], (SolidBrush)this._data["solidBrush"], (PointF)this._data["position"]);

            //// Extraire les données de l'image BMP
            //Rectangle zoneTexte = new Rectangle(0, 0, (int)this._data["width"], (int)this._data["height"]);
            //System.Drawing.Imaging.BitmapData dataTxt = bmpTxt.LockBits(zoneTexte, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            //// Appliquer les données de l'image BMP à la texture
            //GL.BindTexture(TextureTarget.Texture2D, textureID);
            //GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, 0, (int)this._data["width"], (int)this._data["height"], PixelFormat.Bgra, PixelType.UnsignedByte, dataTxt.Scan0);

            //// Libérer les données de l'image BMP
            //bmpTxt.UnlockBits(dataTxt);
            #endregion
            Vector2 pointA = new Vector2(((PointF)this._data["position"]).X, ((PointF)this._data["position"]).Y);
            Vector2 pointB = new Vector2(((PointF)this._data["position"]).X + (int)this._data["width"], ((PointF)this._data["position"]).Y);
            Vector2 pointC = new Vector2(((PointF)this._data["position"]).X + (int)this._data["width"], ((PointF)this._data["position"]).Y + (int)this._data["height"]);
            Vector2 pointD = new Vector2(((PointF)this._data["position"]).X, ((PointF)this._data["position"]).Y + (int)this._data["height"]);

            GL.BindTexture(TextureTarget.Texture2D, this.textureID);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 1.0f);
            GL.Vertex2(pointA.X, pointA.Y);
            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex2(pointB.X, pointB.Y);
            GL.TexCoord2(1.0f, 0.0f);
            GL.Vertex2(pointC.X, pointC.Y);
            GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex2(pointD.X, pointD.Y);
            GL.End();
        }
    }
}