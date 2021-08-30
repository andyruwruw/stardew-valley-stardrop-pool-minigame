using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Players
{
    class ComputerOpponent : Player
    {
        protected OpponentType _type;

        protected int _confidence;

        protected int _complexity;

        protected int _angleAccuracy;

        protected int _powerAccuracy;

        public ComputerOpponent(
            string name,
            OpponentType type,
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
            this._type = type;
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

        public OpponentType GetOpponentType()
        {
            return this._type;
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
