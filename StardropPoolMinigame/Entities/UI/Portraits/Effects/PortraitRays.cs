using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
	internal class PortraitRays : Entity
	{
		public PortraitRays(
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
			SetDrawer(new PortraitRaysDrawer(this));
		}

		public override string GetId()
		{
			return $"portrait-rays-{_id}";
		}

		public override float GetTotalHeight()
		{
			return Textures.PORTRAIT_RAYS.Height;
		}

		public override float GetTotalWidth()
		{
			return Textures.PORTRAIT_RAYS.Width;
		}

		protected override void InitializeFilters()
		{
			_filters = new List<IFilter>();
			_filters.Add(new Rotate($"{GetId()}-animation", 400));
		}
	}
}