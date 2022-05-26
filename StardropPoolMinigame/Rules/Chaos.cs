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
	class Chaos : RuleSet
    {
        public Chaos() : base()
        {
        }

		public override void BallPocketed(
			Turn turn,
			Ball ball,
			TableSegment pocket,
			IList<EntityPhysics> remaining)
        {
		}
	}
}