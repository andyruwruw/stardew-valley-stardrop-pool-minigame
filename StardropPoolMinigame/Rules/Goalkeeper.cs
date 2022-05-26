using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Scenes.States;
using StardropPoolMinigame.Structures;
using System;
using System.Collections.Generic;

namespace StardropPoolMinigame.Rules
{
    internal class Goalkeeper : RuleSet
    {
        public Goalkeeper() : base()
        {
        }

		/// <inheritdoc cref="RuleSet.HasPlayerSpecificCueBalls"/>
		public override bool HasPlayerSpecificCueBalls()
		{
			return true;
		}

		/// <inheritdoc cref="RuleSet.BallPocketed"/>
		public override void BallPocketed(
			Turn turn,
			Ball ball,
			TableSegment pocket,
			IList<EntityPhysics> remaining)
        {
		}
	}
}