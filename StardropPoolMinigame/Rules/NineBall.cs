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
    internal class NineBall : RuleSet
    {
        public NineBall() : base()
        {
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