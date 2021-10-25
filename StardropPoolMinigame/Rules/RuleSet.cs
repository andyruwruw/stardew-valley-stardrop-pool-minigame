using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Primitives;
using StardropPoolMinigame.Scenes.States;
using StardropPoolMinigame.Structures;

namespace StardropPoolMinigame.Rules
{
	abstract class RuleSet : IRules
    {
		/// <inheritdoc cref="IRules.GenerateInitialBalls"/>
		public virtual Tuple<IList<Ball>, QuadTree<EntityPhysics>> GenerateInitialBalls(
			Vector2 tableTopLeft,
			Vector2 cueBallStart,
			Vector2 footSpot,
			Direction rackOrientation)
		{
			var quadTree = new QuadTree<EntityPhysics>(
				new Primitives.Rectangle(
					new Vector2(0, 0),
					RenderConstants.MinigameScreen.Width,
					RenderConstants.MinigameScreen.Height));

			var cueBall = new Ball(
				Vector2.Add(tableTopLeft, cueBallStart),
				RenderConstants.Scenes.Game.LayerDepth.Ball,
				null,
				null,
				0);
			quadTree.Insert(cueBall.GetAnchor(), cueBall);

			var ballsInRow = 1;
			var ballsFinishedInRow = 0;
			var row = 0;

			for (var ballNumber = 1; ballNumber <= 15; ballNumber++)
			{
				var adjustedBallNumber = ballNumber;

				if (ballNumber == 5)
				{
					adjustedBallNumber = 8;
				}
				else if (ballNumber > 5 && ballNumber <= 8)
				{
					adjustedBallNumber = ballNumber - 1;
				}

				var startingPosition = Vector2.Add(tableTopLeft, footSpot);

				var totalRowWidth = ballsInRow * GameConstants.Ball.Radius * 2 + (ballsInRow - 1);
				var halfRowWidth = totalRowWidth / 2;

				var finishedRowWidth = ballsFinishedInRow * GameConstants.Ball.Radius * 2 + ballsFinishedInRow;

				var rowOffset = row * GameConstants.Ball.Radius * 2 / 11 * 10 *
					(rackOrientation == Direction.West || rackOrientation == Direction.North ? -1 : 1);
				var colOffset =
					halfRowWidth * (rackOrientation == Direction.West || rackOrientation == Direction.North ? 1 : -1) +
					finishedRowWidth *
					(rackOrientation == Direction.West || rackOrientation == Direction.North ? -1 : 1) +
					GameConstants.Ball.Radius;

				if (rackOrientation == Direction.West || rackOrientation == Direction.East)
				{
					var anchor = Vector2.Add(startingPosition, new Vector2(rowOffset, colOffset));

					quadTree.Insert(
						anchor,
						new Ball(
							anchor,
							RenderConstants.Scenes.Game.LayerDepth.Ball,
							null,
							null,
							adjustedBallNumber));
				}
				else
				{
					var anchor = Vector2.Add(startingPosition, new Vector2(colOffset, rowOffset));

					quadTree.Insert(
						anchor,
						new Ball(
							anchor,
							RenderConstants.Scenes.Game.LayerDepth.Ball,
							null,
							null,
							adjustedBallNumber));
				}

				ballsFinishedInRow += 1;

				if (ballsFinishedInRow >= ballsInRow)
				{
					ballsInRow += 1;
					ballsFinishedInRow = 0;
					row += 1;
				}
			}

			return new Tuple<IList<Ball>, QuadTree<EntityPhysics>>(new List<Ball> { cueBall }, quadTree);
		}

		/// <inheritdoc cref="IRules.HasPlayerSpecificCueBalls"/>
		public virtual bool HasPlayerSpecificCueBalls()
		{
			return false;
		}

		/// <inheritdoc cref="IRules.BallPocketed"/>
		public abstract void BallPocketed(
			Turn turn,
			Ball ball,
			TableSegment pocket,
			IList<EntityPhysics> remaining);

		/// <inheritdoc cref="IRules.FirstBallHit"/>
		public virtual void FirstBallHit(Turn turn, Ball ball)
		{
			return;
		}

		/// <inheritdoc cref="IRules.NoBallHit"/>
		public virtual void NoBallHit(Turn turn)
		{
			return;
		}

		/// <summary>
		/// Retrieves default <see cref="RuleSet"/>.
		/// </summary>
		/// <returns>Default <see cref="RuleSet"/></returns>
        public static IRules GetDefaultRules()
		{
			return new EightBall();
		}
    }
}