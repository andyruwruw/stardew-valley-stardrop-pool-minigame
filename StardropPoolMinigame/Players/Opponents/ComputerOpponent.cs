using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Players
{
    class ComputerOpponent : Player
    {
        protected NPCName _type;

        protected int _confidence;

        protected int _complexity;

        protected int _angleAccuracy;

        protected int _powerAccuracy;

        public ComputerOpponent(
            string name,
            NPCName type,
            long playerId,
            string music,
            int confidence,
            int complexity,
            int angleAccuracy,
            int powerAccuracy
        ) : base(
            name,
            false,
            true,
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

        public NPCName GetNPCName()
        {
            return this._type;
        }

        public static ComputerOpponent GetComputerOpponentFromName(NPCName name)
        {
            switch (name)
            {
                case NPCName.Sebastian:
                    return new Sebastian();
                case NPCName.Abigail:
                    return new Abigail();
                case NPCName.Gus:
                    return new Gus();
                default:
                    return new Sam();
            }
        }
    }
}
