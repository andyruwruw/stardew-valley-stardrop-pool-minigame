using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
	internal class PortraitFire : Entity
	{
		public PortraitFire(
			Origin origin,
			Vector2 anchor,
			float layerDepth,
			IFilter enteringTransition,
			IFilter exitingTransition
		) : base(
			origin,
			anchor,
			layerDepth,
			enteringTransition,
			exitingTransition)
		{
			SetDrawer(new PortraitFireDrawer(this));
		}

		public override string GetId()
		{
			return $"portrait-fire-{_id}";
		}

		public override float GetTotalHeight()
		{
			return Textures.PortraitFire.FRAME_1.Height;
		}

		public override float GetTotalWidth()
		{
			return Textures.PortraitFire.FRAME_1.Width;
		}

		protected override void InitializeFilters()
		{
			_filters = new List<IFilter>();
			_filters.Add(new PortraitFireAnimation($"{GetId()}-animation"));
		}
	}
}