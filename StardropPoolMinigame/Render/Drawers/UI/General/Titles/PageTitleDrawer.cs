using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
	internal class PageTitleDrawer : Drawer
	{
		public PageTitleDrawer(PageTitle title) : base(title)
		{
		}

		public override void Draw(
			SpriteBatch batch,
			Vector2? overrideDestination = null,
			Rectangle? overrideSource = null,
			Color? overrideColor = null,
			float? overrideRotation = null,
			Vector2? overrideOrigin = null,
			float? overrideScale = null,
			SpriteEffects? overrideEffects = null,
			float? overrideLayerDepth = null)
		{
			((PageTitle) _entity).GetText().GetDrawer().Draw(
				batch,
				overrideDestination,
				overrideSource,
				overrideColor,
				overrideRotation,
				overrideOrigin,
				overrideScale,
				overrideEffects,
				overrideLayerDepth);
		}

		protected override Rectangle GetRawSource()
		{
			return Textures.Characters.LowercaseA;
		}
	}
}