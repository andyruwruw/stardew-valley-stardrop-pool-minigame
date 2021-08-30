using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Structures;
using System.Collections.Generic;

namespace StardropPoolMinigame.Rules
{
    class NineBall : RuleSet
    {
        public NineBall() : base()
        {
        }

        public override Table GenerateTable()
        {
            return new Table(
                Origin.CenterCenter,
                new Vector2(RenderConstants.MinigameScreen.WIDTH / 2, RenderConstants.MinigameScreen.HEIGHT / 2),
                0.0030f,
                null,
                null);
        }

        public override QuadTree GenerateInitialBalls()
        {
            QuadTree quadTree = new QuadTree(new Primitives.Rectangle(new Vector2(0, 0), 2, 2));

            return quadTree;
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
            IList<Ball> balls,
            Pocket pocket,
            IList<Ball> remaining,
            Pocket target = null)
        {
            IList<GameEvent> events = new List<GameEvent>();

            return events;
        }
    }
}
