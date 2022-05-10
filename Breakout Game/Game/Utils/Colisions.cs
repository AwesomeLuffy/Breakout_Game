﻿using System;
using System.Collections.Generic;
using Breakout_Game.Game.Forms;
using Breakout_Game.Game.Levels;
using Breakout_Game.Game.UserInterac;
using OpenTK;

namespace Breakout_Game.Game.Utils
{
    internal static class Colisions
    {
        public static Collisions collisions = new Collisions();
        public static void checkColisions()
        {
            SideObject sideCollision;
            if (Game.ball != null)
            {
                var listLineBall = Game.ball.GetSides();

                foreach (var lineBall in listLineBall)
                {
                    foreach (List<Brick> firstBrick in LevelManager.Level.bricks) {
                        foreach (Brick brick in firstBrick)
                        {
                            var listLineBrick = brick.GetSides();
                            foreach (var lineBrick in listLineBrick)
                            {
                                if (collisions.Intersection(lineBrick.Value, lineBall.Value))
                                {
                                    Game.ball.invertDirection();
                                    return;
                                }
                            }
                        }
                    }

                    foreach(var renderable in Game.Renderables){
                        if(renderable is Racket racket){
                            var listLineRenderable = racket.GetSides();
                            foreach (var lineRenderable in listLineRenderable)
                            {
                                if (collisions.Intersection(lineRenderable.Value, lineBall.Value)) {
                                    (var isKeyDown, var direction) = UserControl.IsRightOrLeftPress();
                                    if (isKeyDown) {
                                        //TODO If Right or If Left -> if(direction == Direction.Right){//TODO}
                                    }
                                    Game.ball.invertDirection(true);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}