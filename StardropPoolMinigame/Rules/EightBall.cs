using System.Collections.Generic;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Scenes.States;

namespace StardropPoolMinigame.Rules
{
	internal class EightBall : RuleSet
	{
		/// <inheritdoc cref="RuleSet.BallPocketed"/>
		public override void BallPocketed(
			Turn turn,
			Ball ball,
			TableSegment pocket,
			IList<EntityPhysics> remaining)
		{
			if (ball.GetNumber() == 0)
			{
				turn.SetIsScratch();

				if (turn.IsVictory())
				{
					turn.SetVictory(false);
					turn.SetDefeat();
				}
			}
			else
			{
				if (ball.GetNumber() == 8)
				{
					if (turn.GetCurrentPlayer().GetBallType() == BallType.Any)
					{
						turn.SetDefeat();
					}
					else
					{
						foreach (Ball reaminingBall in remaining)
						{
							if (reaminingBall.GetBallType() == turn.GetCurrentPlayer().GetBallType())
							{
								turn.SetDefeat();
							}
						}

						if (!turn.IsDefeat())
						{
							turn.IsVictory();
						}
					}
				}
				else
				{
					if (turn.GetCurrentPlayer().GetBallType() == BallType.Any)
					{
						turn.GetCurrentPlayer().SetBallType(ball.GetBallType());
						turn.GetCurrentPlayersOpponent().SetBallType(ball.GetBallType() == BallType.Solid ? BallType.Stripped : BallType.Solid);

						turn.SetIsNewBallTypes();
						turn.AddPointScored();
					}
					else
					{
						if (ball.GetBallType() == turn.GetCurrentPlayer().GetBallType())
						{
							turn.AddPointScored();
						}
						else
						{
							turn.AddPointGiven();
						}
					}
				}
			}
		}

		/// <inheritdoc cref="RuleSet.FirstBallHit"/>
		public override void FirstBallHit(Turn turn, Ball ball)
		{
			if (turn.GetCurrentPlayer().GetBallType() != BallType.Any)
			{
				if (turn.GetCurrentPlayer().GetBallType() != ball.GetBallType())
				{
					turn.SetIsScratch();
				}
			}
		}

		/// <inheritdoc cref="RuleSet.NoBallHit"/>
		public override void NoBallHit(Turn turn)
		{
			turn.SetIsScratch();
		}
	}
}