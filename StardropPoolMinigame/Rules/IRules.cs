using Microsoft.Xna.Framework;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Structures;
using System;
using System.Collections.Generic;
using StardropPoolMinigame.Scenes.States;

namespace StardropPoolMinigame.Rules
{
    /// <summary>
    /// Specifies what game events are brought about by different events
    /// </summary>
	interface IRules
    {
        /// <summary>
        /// Generates the initial <see cref="IGraph"/> of <see cref="Ball">Balls</see> for this <see cref="IRule"/>.
        /// </summary>
        /// <param name="tableTopLeft"><see cref="Vector2"/> of the top-left of the <see cref="Table"/></param>
        /// <param name="cueBallStart"><see cref="Vector2"/> of the cue <see cref="Ball"/> placement for this <see cref="Table"/></param>
        /// <param name="footSpot"><see cref="Vector2"/> of the foot spot, or placement of the <see cref="Ball">Balls</see></param>
        /// <param name="rackOrientation"><see cref="Direction"/> the <see cref="Ball">Balls</see> are oriented.</param>
        /// <returns><see cref="IList"/> of <see cref="Ball">Balls</see> and <see cref="QuadTree{T}"/> of <see cref="Ball">Balls</see></returns>
        Tuple<IList<Ball>, QuadTree<EntityPhysics>> GenerateInitialBalls(
			Vector2 tableTopLeft,
			Vector2 cueBallStart,
			Vector2 footSpot,
			Direction rackOrientation);

		/// <summary>
		/// Whether this <see cref="IRule"/> clarifies that players have separate cue <see cref="Ball"/>.
		/// </summary>
		/// <returns>Whether <see cref="IPlayer"/> has separate cue <see cref="Ball"/></returns>
		bool HasPlayerSpecificCueBalls();

        /// <summary>
        /// Determines what happens when a <see cref="Ball"/> is pocketed.
        /// </summary>
        /// <param name="turn">Current <see cref="Turn"/> state</param>
        /// <param name="ball"><see cref="Ball"/> pocketed</param>
        /// <param name="pocket"><see cref="TableSegment"/> the <see cref="Ball"/> was pocketed in</param>
        /// <param name="remaining">An <see cref="IList"/> of remaining <see cref="Ball">Balls</see></param>
        void BallPocketed(
            Turn turn,
			Ball ball,
            TableSegment pocket,
            IList<EntityPhysics> remaining);

        /// <summary>
        /// Determines what happens after the first <see cref="Ball"/> is struck by the cue <see cref="Ball"/>.
        /// </summary>
        /// <param name="turn">Current <see cref="Turn"/> state</param>
        /// <param name="ball">First <see cref="Ball"/> hit by the cue <see cref="Ball"/></param>
        void FirstBallHit(Turn turn, Ball ball);

		/// <summary>
		/// Determines what happens if no <see cref="Ball"/> is struck by the cue <see cref="Ball"/>.
		/// </summary>
		void NoBallHit(Turn turn);
	}
}