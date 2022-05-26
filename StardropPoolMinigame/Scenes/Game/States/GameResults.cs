using System;
using System.Collections.Generic;
using System.Linq;
using StardropPoolMinigame.Players;

namespace StardropPoolMinigame.Scenes.Game.States
{
    internal class GameResults
    {
        private int _turns;

		private IList<IPlayer> _players;

		private IList<IList<Tuple<int, bool>>> _ballsPocketedPerTurn;

		private IList<IList<bool>> _scratches;

        public GameResults(IList<IPlayer> players)
		{
			_turns = 0;
		}
	}
}