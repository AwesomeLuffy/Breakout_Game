using System;
using System.Collections.Generic;
using Breakout_Game.Audio;
using Breakout_Game.Game.Forms;
using Breakout_Game.Game.Levels;
using Breakout_Game.Game.UserInterac;
using OpenTK;

namespace Breakout_Game.Game.Utils{
    internal static class Colisions{
        public static readonly Collisions collisions = new Collisions();

        public static bool checkColisions(){
            if (Game.ball != null) {
                var listLineBall = Game.ball.GetSides();

                foreach (var lineBall in listLineBall) {
                    foreach (List<Brick> firstBrick in LevelManager.Level.bricks) {
                        foreach (Brick brick in firstBrick) {
                            if (brick == null) {
                                continue;
                            }

                            var listLineBrick = brick.GetSides();
                            foreach (var lineBrick in listLineBrick) {
                                if (collisions.Intersection(lineBrick.Value, lineBall.Value)) {
                                    brick.RemoveLevel();
                                    if (!brick.IsInvincible) {
                                        Game.PointCounter += 5;
                                    }

                                    string SideColision;
                                    int gapX = 0;
                                    int gapY = 0;
                                    switch (lineBrick.Key) {
                                        case SideObject.Bottom:
                                        case SideObject.Top:
                                            SideColision = "Verticale";
                                            gapX = 1;
                                            break;
                                        case SideObject.Left:
                                        case SideObject.Right:
                                            SideColision = "Horizontale";
                                            gapY = 1;
                                            break;
                                        default:
                                            SideColision = "Default";
                                            break;
                                    }
                                    //Patching colision bug
                                    // Game.ball.horizontalMove -= gapX * Game.ball.horizontalIncrement * 10;
                                    // Game.ball.verticalMove -= gapY * Game.ball.verticalIncrement * 10;
                                    Game.ball.invertDirection(SideColision);
                                    return true;
                                }
                            }
                        }
                    }

                    var listLineRenderable = Game.Racket.GetSides();
                    foreach (var lineRenderable in listLineRenderable) {
                        if (collisions.Intersection(lineRenderable.Value, lineBall.Value)) {
                            (var isKeyDown, var direction) = UserControl.IsRightOrLeftPress();
                            if (isKeyDown) {
                                Game.ball.angleDirection(direction);
                            }
                            else {
                                Game.ball.invertDirection("Default", true);
                            }

                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}