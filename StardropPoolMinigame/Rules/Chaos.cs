using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Structures;
using System;
using System.Collections.Generic;

namespace StardropPoolMinigame.Rules
{
    class Chaos : RuleSet
    {
        public Chaos() : base()
        {
        }

        public override Tuple<IList<Ball>, QuadTree<EntityPhysics>> GenerateInitialBalls(Vector2 tableTopLeft, Vector2 cueBallStart, Vector2 footSpot, Direction rackOrientation)
        {
            QuadTree<EntityPhysics> quadTree = new QuadTree<EntityPhysics>(
                new Primitives.Rectangle(
                    new Vector2(0, 0),
                    RenderConstants.MinigameScreen.WIDTH,
                    RenderConstants.MinigameScreen.HEIGHT));

            Ball cueBall = new Ball(
                Vector2.Add(tableTopLeft, cueBallStart),
                RenderConstants.Scenes.Game.LayerDepth.BALL,
                null,
                null,
                0);
            quadTree.Insert(cueBall.GetAnchor(), cueBall);

            return new Tuple<IList<Ball>, QuadTree<EntityPhysics>>(new List<Ball> { cueBall }, quadTree);
        }

        public override IList<GameEvent> NoBallHit(IList<Ball> remaining)
        {
            IList<GameEvent> events = new List<GameEvent>();

            return events;
        }

        public override IList<GameEvent> FirstBallHit(IPlayer player, Ball ball)
        {
            IList<GameEvent> events = new List<GameEvent>();

            return events;
        }

        public override IList<GameEvent> BallPocketed(
            IPlayer player,
            Ball ball,
            TableSegment pocket,
            IList<Ball> remaining,
            TableSegment target = null)
        {
            IList<GameEvent> events = new List<GameEvent>();

            return events;
        }
    }
}
