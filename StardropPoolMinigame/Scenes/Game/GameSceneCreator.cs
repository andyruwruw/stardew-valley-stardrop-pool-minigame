using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Rules;

namespace StardropPoolMinigame.Scenes
{
    class GameSceneCreator : ISceneCreator
    {
        private IPlayer _player1;

        private IPlayer _player2;

        private IRules _rules;

        private Table _table;

        public GameSceneCreator(
            IPlayer player1,
            IPlayer player2,
            IRules rules = null,
            Table table = null)
        {
            this._player1 = player1;
            this._player2 = player2;
            this._rules = rules;
            this._table = table;
        }

        public IScene GetScene()
        {
            return new GameScene(
                this._player1,
                this._player2,
                this._rules,
                this._table);
        }
    }
}
