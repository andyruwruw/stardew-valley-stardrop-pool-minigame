namespace StardropPoolMinigame.Scenes.States
{
    internal class TurnResults
    {
        private int _ballsPocketed;

        private bool _defeat;

        private int _pointsGiven;

        private int _pointsScored;

        private bool _scratch;

        private bool _victory;

        public TurnResults()
        {
            this._victory = false;
            this._defeat = false;
            this._scratch = false;
            this._ballsPocketed = 0;
            this._pointsScored = 0;
            this._pointsGiven = 0;
        }

        public int GetBallsPocketed()
        {
            return this._ballsPocketed;
        }

        public int GetPointsGiven()
        {
            return this._pointsGiven;
        }

        public int GetPointsScored()
        {
            return this._pointsScored;
        }

        public void GivePoint()
        {
            this._pointsGiven += 1;
        }

        public bool IsDefeat()
        {
            return this._defeat;
        }

        public bool IsScratch()
        {
            return this._scratch;
        }

        public bool IsVictory()
        {
            return this._victory;
        }

        public void PocketedBall()
        {
            this._ballsPocketed += 1;
        }

        public void ScorePoint()
        {
            this._pointsScored += 1;
        }

        public void SetDefeat()
        {
            this._defeat = true;
        }

        public void SetScratch()
        {
            this._scratch = true;
        }

        public void SetVictory()
        {
            this._victory = true;
        }
    }
}