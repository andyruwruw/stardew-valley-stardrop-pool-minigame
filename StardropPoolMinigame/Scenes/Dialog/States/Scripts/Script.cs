using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Utilities;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes.Dialog.Scripts
{
    abstract class Script : IScript
    {
        /// <summary>
        /// <see cref="IList"/> of <see cref="IRecitations"/>, or dialog lines for <see cref="Script"/>
        /// </summary>
        protected IList<IRecitation> _recitations;

        /// <summary>
        /// Index of current <see cref="IRecitation"/>
        /// </summary>
        protected int _index;

        public Script()
        {
            this._recitations = new List<IRecitation>();
            this._index = -1;

            this.AddRecitations();
        }

        /// <inheritdoc cref="IScript.GetNext"/>
        public IRecitation GetNext()
        {
            if (this._index >= this._recitations.Count - 1)
            {
                return null;
            }

            this._index += 1;
            IRecitation next = this._recitations[this._index];
            
            return next;
        }

        /// <inheritdoc cref="IScript.GetLast"/>
        public IRecitation GetLast()
        {
            if (this._index <= 0)
            {
                return this._recitations[this._index];
            }

            this._index -= 1;
            IRecitation last = this._recitations[this._index];
            
            return last;
        }

        /// <summary>
        /// <para>Overridable function for adding <see cref="IRecitation">IRecitations</see> to <see cref="Script"/></para>
        /// <para>Automatically called at instantiation</para>
        /// </summary>
        protected abstract void AddRecitations();

        public static IScript GetScript(ISceneCreator nextScene)
        {
            if (nextScene is GameSceneCreator)
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

        public static Script GetIntroduction(NPCName name)
        {
            switch (name)
            {
                case NPCName.Sebastian:
                    return new IntroductionSebastian();
                case NPCName.Abigail:
                    return new IntroductionAbigail();
                case NPCName.Gus:
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
