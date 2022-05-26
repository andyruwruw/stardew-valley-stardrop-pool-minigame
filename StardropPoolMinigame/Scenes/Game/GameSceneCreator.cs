using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Rules;

namespace StardropPoolMinigame.Scenes
{
	/// <inheritdoc cref="ISceneCreator"/>
	internal class GameSceneCreator : ISceneCreator
	{
		/// <summary>
		/// Stored parameter for <see cref="GameScene"/> creation
		/// </summary>
		private readonly IPlayer _player1;

		/// <summary>
		/// Stored parameter for <see cref="GameScene"/> creation
		/// </summary>
		private readonly IPlayer _player2;

		/// <summary>
		/// Stored parameter for <see cref="GameScene"/> creation
		/// </summary>
		private readonly IRules _rules;

		/// <summary>
		/// Stored parameter for <see cref="GameScene"/> creation
		/// </summary>
		private readonly Table _table;

		/// <summary>
		/// Instantiates <see cref="GameSceneCreator"/>.
		/// </summary>
		/// <param name="player1">Stored parameter for <see cref="GameScene"/> creation</param>
		/// <param name="player2">Stored parameter for <see cref="GameScene"/> creation</param>
		/// <param name="rules">Stored parameter for <see cref="GameScene"/> creation</param>
		/// <param name="table">Stored parameter for <see cref="GameScene"/> creation</param>
		public GameSceneCreator(
			IPlayer player1,
			IPlayer player2,
			IRules rules = null,
			Table table = null)
		{
			_player1 = player1;
			_player2 = player2;
			_rules = rules;
			_table = table;
		}

		/// <inheritdoc cref="ISceneCreator.GetScene"/>
		public IScene GetScene()
		{
			return new GameScene(
				_player1,
				_player2,
				_rules,
				_table);
		}

		public IPlayer GetPlayer2()
		{
			return _player2;
		}
	}
}