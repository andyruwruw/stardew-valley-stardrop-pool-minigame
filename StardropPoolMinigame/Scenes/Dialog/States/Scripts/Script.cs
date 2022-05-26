using System.Collections.Generic;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Scenes.Dialog.Scripts
{
	internal abstract class Script : IScript
	{
		/// <summary>
		/// Index of current <see cref="IRecitation"/>
		/// </summary>
		protected int _index;

		/// <summary>
		/// <see cref="IList"/> of <see cref="IRecitations"/>, or dialog lines for <see cref="Script"/>
		/// </summary>
		protected IList<IRecitation> _recitations;

		public Script()
		{
			_recitations = new List<IRecitation>();
			_index = -1;

			AddRecitations();
		}

		/// <inheritdoc cref="IScript.GetLast"/>
		public IRecitation GetLast()
		{
			if (_index <= 0) return _recitations[_index];

			_index -= 1;
			var last = _recitations[_index];

			return last;
		}

		/// <inheritdoc cref="IScript.GetNext"/>
		public IRecitation GetNext()
		{
			if (_index >= _recitations.Count - 1) return null;

			_index += 1;
			var next = _recitations[_index];

			return next;
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

		public static IScript GetScript(ISceneCreator nextScene)
		{
			if (nextScene is GameSceneCreator)
			{
				var opponent = ((GameSceneCreator) nextScene).GetPlayer2();

				if (Save.GetWins(((ComputerOpponent) opponent).GetNPCName()) == 0
					&& Save.GetLosses(((ComputerOpponent) opponent).GetNPCName()) == 0)
					return GetIntroduction(((ComputerOpponent) opponent).GetNPCName());

				if (opponent is Sam)
				{
					if (Save.GetWinsAgainstSam() == 0 && Save.GetLossesAgainstSam() == 0) return new IntroductionSam();
				}
				else if (opponent is Sebastian)
				{
					if (Save.GetWinsAgainstSebastian() == 0 && Save.GetLossesAgainstSebastian() == 0)
						return new IntroductionSebastian();
				}
				else if (opponent is Abigail)
				{
					if (Save.GetWinsAgainstAbigail() == 0 && Save.GetLossesAgainstAbigail() == 0)
						return new IntroductionAbigail();
				}
				else if (opponent is Gus)
				{
					if (Save.GetWinsAgainstGus() == 0 && Save.GetLossesAgainstGus() == 0) return new IntroductionGus();
				}

				return null;
			}

			return null;
		}

		public static bool QueueDialog()
		{
			return true;
		}

		/// <summary>
		/// <para>Overridable function for adding <see cref="IRecitation">IRecitations</see> to <see cref="Script"/></para>
		/// <para>Automatically called at instantiation</para>
		/// </summary>
		protected abstract void AddRecitations();
	}
}