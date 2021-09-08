namespace StardropPoolMinigame.Scenes.Game
{
    class TurnResults
    {
        private bool _victory;

        private bool _defeat;

        private bool _scratch;

        private int _ballsPocketed;

        private int _pointsScored;

        private int _pointsGiven;

        public TurnResults()
        {
            this._victory = false;
            this._defeat = false;
            this._scratch = false;
            this._ballsPocketed = 0;
            this._pointsScored = 0;
            this._pointsGiven = 0;
        }

        public bool IsVictory()
        {
            return this._victory;
        }

        public void SetVictory()
        {
            this._victory = true;
        }

        public bool IsDefeat()
        {
            return this._defeat;
        }

        public void SetDefeat()
        {
            this._defeat = true;
        }

        public bool IsScratch()
        {
            return this._scratch;
        }

        public void SetScratch()
        {
            this._scratch = true;
        }

        public int GetBallsPocketed()
        {
            return this._ballsPocketed;
        }

        public void PocketedBall()
        {
            this._ballsPocketed += 1;
        }

        public int GetPointsScored()
        {
            return this._pointsScored;
        }

        public void ScorePoint()
        {
            this._pointsScored += 1;
        }

        public int GetPointsGiven()
        {
            return this._pointsGiven;
        }

        public void GivePoint()
        {
            this._pointsGiven += 1;
        }
    }
}
