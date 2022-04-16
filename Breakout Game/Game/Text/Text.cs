using System.Collections.Generic;
using Breakout_Game.Game.Forms;
using Breakout_Game.Game.Texture;

namespace Breakout_Game.Game.Text{
    internal class Text : IRenderable{
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
        internal Text(){

            this.textureID = RessourceLoader.GenId(); //Génération de l'ID de la texture pour le texte
            //TODO -> Assign each value in data dictionnary

            this._data = new Dictionary<string, object>(); //Création de la dictionnary 

            RessourceLoader.CreateText(this.textureID, this._data); //Création du texte
        }

        public void setText(string text){
            this._data["text"] = text;
            RessourceLoader.LoadText(this.textureID, this._data);
        } //TODO -> Exemple d'utilisation pour charger le texte et les nouvelles valeurs

        public void Draw(){
        }
    }
}