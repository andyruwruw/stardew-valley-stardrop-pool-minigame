using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Players
{
    internal class ComputerOpponent : Player
    {
        protected int _angleAccuracy;

        protected int _complexity;

        protected int _confidence;

        protected int _powerAccuracy;

        protected NPCName _type;

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

        public int GetAngleAccuracy()
        {
            return this._angleAccuracy;
        }

        public int GetComplexity()
        {
            return this._complexity;
        }

        public int GetConfidence()
        {
            return this._confidence;
        }

        public NPCName GetNPCName()
        {
            return this._type;
        }

        public int GetPowerAccuracy()
        {
            return this._powerAccuracy;
        }
    }
}