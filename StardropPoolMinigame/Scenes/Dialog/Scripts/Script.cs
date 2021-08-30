using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Players;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes.Dialog.Scripts
{
    abstract class Script : IScript
    {
        protected IList<Recitation> _recitations;

        protected int _index;

        public Script()
        {
            this._recitations = new List<Recitation>();
            this._index = -1;

            this.AddRecitations();
        }

        public Recitation GetNext()
        {
            if (this._index >= this._recitations.Count - 1)
            {
                return null;
            }

            this._index += 1;
            Recitation next = this._recitations[this._index];
            
            return next;
        }

        public Recitation GetLast()
        {
            if (this._index <= 0)
            {
                return this._recitations[this._index];
            }

            this._index -= 1;
            Recitation last = this._recitations[this._index];
            
            return last;
        }

        public abstract OpponentType GetCharacter();

        protected abstract void AddRecitations();

        public static IScript GetScript(IScene nextScene)
        {
            if (nextScene is GameScene)
            {
                IPlayer opponent = ((GameScene)nextScene).GetPlayers()[1];

                if (Save.GetWins(((ComputerOpponent)opponent).GetOpponentType()) == 0
                    && Save.GetLosses(((ComputerOpponent)opponent).GetOpponentType()) == 0)
                {
                    return GetIntroduction(((ComputerOpponent)opponent).GetOpponentType());
                }

                if (opponent is Sam)
                {
                    if (Save.GetWinsAgainstSam() == 0 && Save.GetLossesAgainstSam() == 0)
                    {
                        return new IntroductionSam();
                    }
                } else if (opponent is Sebastian)
                {
                    if (Save.GetWinsAgainstSebastian() == 0 && Save.GetLossesAgainstSebastian() == 0)
                    {
                        return new IntroductionSebastian();
                    }
                } else if (opponent is Abigail)
                {
                    if (Save.GetWinsAgainstAbigail() == 0 && Save.GetLossesAgainstAbigail() == 0)
                    {
                        return new IntroductionAbigail();
                    }
                } else if (opponent is Gus)
                {
                    if (Save.GetWinsAgainstGus() == 0 && Save.GetLossesAgainstGus() == 0)
                    {
                        return new IntroductionGus();
                    }
                }

                return null;
            }

            return null;
        }

        public static Script GetIntroduction(OpponentType name)
        {
            switch (name)
            {
                case OpponentType.Sebastian:
                    return new IntroductionSebastian();
                case OpponentType.Abigail:
                    return new IntroductionAbigail();
                case OpponentType.Gus:
                    return new IntroductionGus();
                default:
                    return new IntroductionSam();
            }
        }

        public static bool QueueDialog()
        {
            return true;
        }
    }
}
