using StardewValley;
using StardropPoolMinigame.Objects;
using StardropPoolMinigame.Rules;
using StardropPoolMinigame.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Scenes
{
    class GameScene : IScene
    {
        private IRules _rules;

        private bool _hasNewScene;

        private IScene _newScene;

        private ITable _table;

        private QuadTree _balls;

        public GameScene(IRules rules = null)
        {
            if (rules == null)
            {
                this._rules = new EightBall();
            } else
            {
                this._rules = rules;
            }

            this._table = this._rules.GenerateTable();
            this._balls = this._rules.GenerateInitialBalls();
        }

        public void Start()
        {
            Game1.changeMusicTrack("poppy");
        }

        public void ReceiveLeftClick(int x, int y, bool playSound = true)
        {
        }

        public bool HasNewScene()
        {
            return this._hasNewScene;
        }

        public IScene GetNewScene()
        {
            this._hasNewScene = false;
            return this._newScene;
        }

        public IList<IBall> GetBalls()
        {
            return this._balls.Query();
        }

        public ITable GetTable()
        {
            return this._table;
        }
    }
}
