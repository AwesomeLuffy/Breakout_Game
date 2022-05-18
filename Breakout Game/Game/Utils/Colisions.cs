using System;
using System.Collections.Generic;
using Breakout_Game.Game.Forms;
using Breakout_Game.Game.Levels;
using Breakout_Game.Game.UserInterac;

namespace Breakout_Game.Game.Utils{
    internal static class Colisions{
        public static readonly Collisions collisions = new Collisions();

        public static bool checkColisions(){
            if (Game.Ball != null) {
                var listLineBall = Game.Ball.GetSides();

                foreach (var lineBall in listLineBall) {
                    try {
                        foreach (List<Brick> firstBrick in LevelManager.Level.bricks) {
                            foreach (Brick brick in firstBrick) {
                                if (brick == null) {
                                    continue;
                                }

                                var listLineBrick = brick.GetSides();
                                foreach (var lineBrick in listLineBrick) {
                                    if (collisions.Intersection(lineBall.Value, lineBrick.Value) 
                                        || collisions.Intersection(lineBrick.Value, lineBall.Value)) {
                                        brick.RemoveLevel();
                                        if (!brick.IsInvincible) {
                                            Game.PointCounter += 5;
                                        }
                                        string SideColision;
                                        switch (lineBrick.Key) {
                                            case SideObject.Bottom:
                                            case SideObject.Top:
                                                SideColision = "Verticale";
                                                break;
                                            case SideObject.Left:
                                            case SideObject.Right:
                                                SideColision = "Horizontale";
                                                break;
                                            default:
                                                SideColision = "Default";
                                                break;
                                        }

                                        Game.Ball.invertDirection(SideColision);
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception e) {
                        return false;
                    }

                    var listLineRenderable = Game.Racket.GetSides();
                    foreach (var lineRenderable in listLineRenderable) {
                        if (collisions.Intersection(lineRenderable.Value, lineBall.Value) || 
                            collisions.Intersection(lineBall.Value, lineRenderable.Value)) {
                            var (isKeyDown, direction) = UserControl.IsRightOrLeftPress();
                            if (isKeyDown) {
                                Game.Ball.angleDirection(direction);
                            }
                            else {
                                switch (lineRenderable.Key) {
                                    case SideObject.Bottom:
                                    case SideObject.Top:
                                        Game.Ball.invertDirection("Default", true);
                                        break;
                                    case SideObject.Left:
                                    case SideObject.Right:
                                        Game.Ball.invertDirection("Horizontale", true);
                                        break;
                                }
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