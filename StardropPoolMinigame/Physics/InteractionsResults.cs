using System.Collections.Generic;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Behaviors.Physics
{
    class InteractionsResults
	{
		private IList<EntityPhysics> _interactedWith;

		public InteractionsResults()
		{
			_interactedWith = new List<EntityPhysics>();
		}

		public void SetInteractedWith(IList<EntityPhysics> others)
		{
			_interactedWith = others;
		}

		public void AddInteractedWith(EntityPhysics other)
		{
			_interactedWith.Add(other);
		}

		public IList<EntityPhysics> GetInteractedWith()
		{
			return _interactedWith;
		}
    }
}
