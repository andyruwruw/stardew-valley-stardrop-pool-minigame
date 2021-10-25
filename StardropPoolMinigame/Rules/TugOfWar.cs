using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Scenes.States;
using System.Collections.Generic;

namespace StardropPoolMinigame.Rules
{
    class TugOfWar : RuleSet
    {
        public TugOfWar() : base()
        {
        }

		/// <inheritdoc cref="IRules.BallPocketed"/>
		public override void BallPocketed(
			Turn turn,
			Ball ball,
			TableSegment pocket,
			IList<EntityPhysics> remaining)
        {
		}
	}
}