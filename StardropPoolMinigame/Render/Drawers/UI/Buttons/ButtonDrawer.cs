using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Entities;

namespace StardropPoolMinigame.Render.Drawers
{
	internal class ButtonDrawer : Drawer
	{
		public ButtonDrawer(Button button) : base(button)
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
			((Button) _entity).GetText().GetDrawer().Draw(
				batch,
				overrideDestination,
				overrideSource,
				GetRawColor(),
				overrideRotation,
				overrideOrigin,
				overrideScale,
				overrideEffects,
				overrideLayerDepth);
		}

		protected override Color GetRawColor()
		{
			if (((Button) _entity).IsDisabled()) return Textures.Color.Solid.DISABLED;

			if (_entity.IsHovered()) return Textures.Color.Solid.HOVER_ACCENT;

			return Color.White;
		}

		protected override Rectangle GetRawSource()
		{
			return Textures.Characters.LowercaseA;
		}
	}
}