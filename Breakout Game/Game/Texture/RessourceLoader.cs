using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using Breakout_Game.Game.Utils;
using OpenTK.Graphics.OpenGL;
using PixelFormat = OpenTK.Graphics.OpenGL.PixelFormat;

namespace Breakout_Game.Game.Texture{
    internal static class RessourceLoader{
        #region Attributes
        
        #endregion
        
        private static Dictionary<string, int> _ressourceLoaderId = new Dictionary<string, int>();
        
        internal static int GenId(){
            int text;
            GL.GenTextures(1, out text);//Fill text to the value of the ID
            return text;
        }
        
        internal static int CheckAndLoadTexture(string textureName){
            int textId;
            
            if(!(RessourceLoader._ressourceLoaderId.ContainsKey(textureName))) {
                textId = RessourceLoader.GenId();
                RessourceLoader._ressourceLoaderId[textureName] = textId;
            }
            else {
                textId = RessourceLoader._ressourceLoaderId[textureName];
            }
            
            RessourceLoader.LoadTexture(textId, textureName);
            
            Log.Send("RessourceLoader", "Ressource " + textureName + " with ID (" + textId + ") loaded !", LogType.Info);

            return textId;
        }

        #region Assets

        /// <summary>
        /// Load Texture of a from (for BaseForm Class)
        /// </summary>
        /// <param name="textureId">TextureID getted by GenId() method of this class</param>
        /// <param name="textureName">Texture Name (file.bmp) in assets directory</param>
        internal static void LoadTexture(int textureId, string textureName){
            GL.BindTexture(TextureTarget.Texture2D, textureId);
            BitmapData bdata = LoadImage("../../assets/" + textureName);
            
            //Console.WriteLine(textureName);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb,
                bdata.Width, bdata.Height, 0, PixelFormat.Bgr, PixelType.UnsignedByte, bdata.Scan0);

            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            
        }
        
        private static BitmapData LoadImage(string name){
            Bitmap bmpImg = new Bitmap(name);
            Rectangle rect = new Rectangle(0, 0, bmpImg.Width, bmpImg.Height);

            BitmapData bmpData = bmpImg.LockBits(rect, ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb); //Lock Pic in Mem in readonly

            bmpImg.UnlockBits(bmpData);

            return bmpData;
        }

        #endregion

        #region Text

        /// <summary>
        /// CreateText, call this method when create the inital text (in the constructor)
        /// </summary>
        /// <param name="textureId">TextureID getted by GenId() method of this class</param>
        /// <param name="data">Data of the text field</param>
        internal static void CreateText(int textureId, Dictionary<string, object> data){
            if (!IsLibraryExpected(data)) return;
            
            GL.BindTexture(TextureTarget.Texture2D, textureId);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
                (int) TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
                (int) TextureMagFilter.Linear);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, (int) data["width"], (int) data["height"], 0, PixelFormat.Rgba,
                PixelType.UnsignedByte, IntPtr.Zero);
        }

        /// <summary>
        /// To Load a Text texture and all attributes that associated with it in the Data Dictionnaries
        /// </summary>
        /// <param name="textureId">TextureID getted by GenId() method of this class</param>
        /// <param name="data">Data of the text field</param>
        internal static void LoadText(int textureId, Dictionary<string, object> data){
            if (!IsLibraryExpected(data))  return;
            
            Bitmap bmpTxt = new Bitmap((int) data["width"], (int) data["height"],
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            Graphics graphics = Graphics.FromImage(bmpTxt);
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            graphics.Clear((Color)data["background"]);

            graphics.DrawString(
                (string) data["text"],
                (Font) data["police"],
                (SolidBrush) data["solid_brush"],
                (PointF) data["position"]
                );
            
            Rectangle rectangle = new Rectangle(0, 0, (int) data["width"], (int) data["height"]);

            BitmapData dataTxt = bmpTxt.LockBits(rectangle,
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.BindTexture(TextureTarget.Texture2D, textureId);
            GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, 0, (int) data["width"], (int) data["height"],
                PixelFormat.Bgra, PixelType.UnsignedByte, dataTxt.Scan0);

            bmpTxt.UnlockBits(dataTxt);
        }

        private static bool IsLibraryExpected(IReadOnlyDictionary<string, object> data){
            return data["width"] is int &&
                   data["height"] is int &&
                   data["text"] is string &&
                   data["background"] is Color &&
                   data["police"] is Font &&
                   data["solid_brush"] is SolidBrush &&
                   data["position"] is PointF;
        }

        #endregion
    }
}