using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Structures;

namespace StardropPoolMinigame.Players.Opponents
{
    class Shot
    {
		private int _angleAccuracy;

		private int _complexity;

		private int _confidence;

		private int _powerAccuracy;

		public Shot(
			int angleAccuracy,
			int complexity,
			int confidence,
			int powerAccuracy,
			QuadTree<EntityPhysics> state,
			Table table)
		{
			_angleAccuracy = angleAccuracy;
			_complexity = complexity;
			_confidence = confidence;
			_powerAccuracy = powerAccuracy;

			GenerateGraph(state, table);
		}

		private void GenerateGraph(QuadTree<EntityPhysics> state, Table table)
		{

		}
    }
}
