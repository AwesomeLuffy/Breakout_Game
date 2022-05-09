using System;
using System.Collections.Generic;
using OpenTK;

namespace Breakout_Game.Game.Utils{

    internal class Collisions{

        public bool Intersection(List<Vector2> droiteTriangle, List<Vector2> droiteCarre){
            // **************************************************
            // Méthodes trouvées sur le web
            // Traduite en français pour aider à la compréhension
            // **************************************************

            /*
             * Une droite est représentée par cette équation : y = ax + b
             * où "a" représente la pente et "b" est le décalage de "y" à l'origine
             * 
             * NOTE : Une division par zéro a pour résultat l'INFINI.
             * Si une droite est verticale, l'équation pour trouver "a" retournera l'INFINI
             * */
            bool siIntersection = false;

            // Calculer les valeur "a" pour chacune de deux droites
            float a_Triangle = (droiteTriangle[1].Y - droiteTriangle[0].Y) /
                               (droiteTriangle[1].X - droiteTriangle[0].X);
            float a_Carre = (droiteCarre[1].Y - droiteCarre[0].Y) / (droiteCarre[1].X - droiteCarre[0].X);

            // Calculer les valeur "b" pour chacune de deux droites
            float b_Triangle = droiteTriangle[1].Y - a_Triangle * droiteTriangle[1].X;
            float b_Carre = droiteCarre[1].Y - a_Carre * droiteCarre[1].X;

            // Calculer les valeurs "x" et "y" pour le point d'intersection des deux lignes
            float x = (b_Carre - b_Triangle) / (a_Triangle - a_Carre);
            float y = a_Triangle * x + b_Triangle;

            // **************
            // Début des test
            if (float.IsInfinity(a_Triangle) && float.IsInfinity(a_Carre)) {
                // Si les deux valeurs "a" sont l'INFINI, alors on a deux droites verticales.
                // Si les deux droites partagent le même "x", alors on vérifie alors la valeur "y".
                siIntersection = (droiteTriangle[0].X == droiteCarre[0].X) && (
                    (droiteCarre[0].Y <= droiteTriangle[0].Y && droiteTriangle[0].Y <= droiteCarre[1].Y)
                    || (droiteCarre[0].Y <= droiteTriangle[1].Y && droiteTriangle[1].Y <= droiteCarre[1].Y)
                );
            }
            else if (float.IsInfinity(a_Triangle) && !float.IsInfinity(a_Carre)) {
                // La droite du triangle EST vertical et celle de la caisse NE L'EST PAS
                x = droiteTriangle[0].X;
                y = b_Carre * x + b_Carre;

                siIntersection = (
                    ((droiteTriangle[0].Y <= droiteTriangle[1].Y && this.LTE(droiteTriangle[0].Y, y) &&
                      this.GTE(droiteTriangle[1].Y, y)) || (droiteTriangle[0].Y >= droiteTriangle[1].Y &&
                                                            this.GTE(droiteTriangle[0].Y, y) &&
                                                            this.LTE(droiteTriangle[1].Y, y))) &&
                    ((droiteCarre[0].X <= droiteCarre[1].X && this.LTE(droiteCarre[0].X, x) &&
                      this.GTE(droiteCarre[1].X, x)) ||
                     (droiteCarre[0].X >= droiteCarre[1].X && this.GTE(droiteCarre[0].X, x) &&
                      this.LTE(droiteCarre[1].X, x))) &&
                    ((droiteCarre[0].Y <= droiteCarre[1].Y && this.LTE(droiteCarre[0].Y, y) &&
                      this.GTE(droiteCarre[1].Y, y)) ||
                     (droiteCarre[0].Y >= droiteCarre[1].Y && this.GTE(droiteCarre[0].Y, y) &&
                      this.LTE(droiteCarre[1].Y, y)))
                );
            }
            else if (!float.IsInfinity(a_Triangle) && float.IsInfinity(a_Carre)) {
                // La droite du triangle N'EST PAS vertical et celle de la caisse L'EST
                x = droiteCarre[0].X;
                y = a_Triangle * x + b_Triangle;

                siIntersection = (
                    ((droiteTriangle[0].X <= droiteTriangle[1].X && this.LTE(droiteTriangle[0].X, x) &&
                      this.GTE(droiteTriangle[1].X, x)) || (droiteTriangle[0].X >= droiteTriangle[1].X &&
                                                            this.GTE(droiteTriangle[0].X, x) &&
                                                            this.LTE(droiteTriangle[1].X, x))) &&
                    ((droiteTriangle[0].Y <= droiteTriangle[1].Y && this.LTE(droiteTriangle[0].Y, y) &&
                      this.GTE(droiteTriangle[1].Y, y)) || (droiteTriangle[0].Y >= droiteTriangle[1].Y &&
                                                            this.GTE(droiteTriangle[0].Y, y) &&
                                                            this.LTE(droiteTriangle[1].Y, y))) &&
                    ((droiteCarre[0].Y <= droiteCarre[1].Y && this.LTE(droiteCarre[0].Y, y) &&
                      this.GTE(droiteCarre[1].Y, y)) ||
                     (droiteCarre[0].Y >= droiteCarre[1].Y && this.GTE(droiteCarre[0].Y, y) &&
                      this.LTE(droiteCarre[1].Y, y)))
                );
            }

            // Finalement, vérifier si le point d'interception est à l'intérieur de tous les points
            if (!siIntersection) {
                siIntersection = (
                    ((droiteTriangle[0].X <= droiteTriangle[1].X && this.LTE(droiteTriangle[0].X, x) &&
                      this.GTE(droiteTriangle[1].X, x)) || (droiteTriangle[0].X >= droiteTriangle[1].X &&
                                                            this.GTE(droiteTriangle[0].X, x) &&
                                                            this.LTE(droiteTriangle[1].X, x))) &&
                    ((droiteTriangle[0].Y <= droiteTriangle[1].Y && this.LTE(droiteTriangle[0].Y, y) &&
                      this.GTE(droiteTriangle[1].Y, y)) || (droiteTriangle[0].Y >= droiteTriangle[1].Y &&
                                                            this.GTE(droiteTriangle[0].Y, y) &&
                                                            this.LTE(droiteTriangle[1].Y, y))) &&
                    ((droiteCarre[0].X <= droiteCarre[1].X && this.LTE(droiteCarre[0].X, x) &&
                      this.GTE(droiteCarre[1].X, x)) ||
                     (droiteCarre[0].X >= droiteCarre[1].X && this.GTE(droiteCarre[0].X, x) &&
                      this.LTE(droiteCarre[1].X, x))) &&
                    ((droiteCarre[0].Y <= droiteCarre[1].Y && this.LTE(droiteCarre[0].Y, y) &&
                      this.GTE(droiteCarre[1].Y, y)) ||
                     (droiteCarre[0].Y >= droiteCarre[1].Y && this.GTE(droiteCarre[0].Y, y) &&
                      this.LTE(droiteCarre[1].Y, y))));
            }

            return siIntersection;
        }

        // ****************************
        // Méthodes trouvées sur le web
        // Celles-ci permettent d'ajuster la précision lors des différentes comparaisons possibles.
        // ****************************

        /// <summary>
        /// Less Than or Equal: Tells you if the left value is less than or equal to the right value
        /// with floating point precision error taken into account.
        /// </summary>
        /// <param name="leftVal">The value on the left side of comparison operator</param>
        /// <param name="rightVal">The value on the right side of comparison operator</param>
        /// <returns>True if the left value and right value are within 0.000001 of each other, or if leftVal is less than rightVal</returns>
        private bool LTE(float leftVal, float rightVal){
            return (this.EE(leftVal, rightVal) || leftVal < rightVal);
        }

        /// <summary>
        /// Greather Than or Equal: Tells you if the left value is greater than or equal to the right value
        /// with floating point precision error taken into account.
        /// </summary>
        /// <param name="leftVal">The value on the left side of comparison operator</param>
        /// <param name="rightVal">The value on the right side of comparison operator</param>
        /// <returns>True if the left value and right value are within 0.000001 of each other, or if leftVal is greater than rightVal</returns>
        private bool GTE(float leftVal, float rightVal){
            return (this.EE(leftVal, rightVal) || leftVal > rightVal);
        }

        /// <summary>
        /// Equal-Equal: Tells you if two doubles are equivalent even with floating point precision errors
        /// </summary>
        /// <param name="Val1">First double value</param>
        /// <param name="Val2">Second double value</param>
        /// <returns>true if they are within 0.000001 of each other, false otherwise.</returns>
        private bool EE(float Val1, float Val2){
            return (Math.Abs(Val1 - Val2) < 0.000001f);
        }

        /// <summary>
        /// Equal-Equal: Tells you if two doubles are equivalent even with floating point precision errors
        /// </summary>
        /// <param name="Val1">First double value</param>
        /// <param name="Val2">Second double value</param>
        /// <param name="Epsilon">The delta value the two doubles need to be within to be considered equal</param>
        /// <returns>true if they are within the epsilon value of each other, false otherwise.</returns>
        private bool EE(float Val1, float Val2, float Epsilon){
            return (Math.Abs(Val1 - Val2) < Epsilon);
        }
    }
}