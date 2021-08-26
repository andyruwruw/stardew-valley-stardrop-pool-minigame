using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Players
{
    class ComputerOpponent : Player
    {
        private int _confidence;

        private int _complexity;

        private int _angleAccuracy;

        private int _powerAccuracy;

        public ComputerOpponent(
            string name,
            long playerId,
            string music,
            int confidence,
            int complexity,
            int angleAccuracy,
            int powerAccuracy
        ) : base(
            name,
            false,
            false,
            playerId,
            music)
        {
            this._confidence = confidence;
            this._complexity = complexity;
            this._angleAccuracy = angleAccuracy;
            this._powerAccuracy = powerAccuracy;
        }

        public int GetConfidence()
        {
            return this._confidence;
        }

        public int GetComplexity()
        {
            return this._complexity;
        }

        public int GetAngleAccuracy()
        {
            return this._angleAccuracy;
        }

        public int GetPowerAccuracy()
        {
            return this._powerAccuracy;
        }

        public static ComputerOpponent GetComputerOpponentFromName(OpponentType name)
        {
            switch (name)
            {
                case OpponentType.Sebastian:
                    return new Sebastian();
                case OpponentType.Abigail:
                    return new Abigail();
                case OpponentType.Gus:
                    return new Gus();
                default:
                    return new Sam();
            }
        }
    }
}
