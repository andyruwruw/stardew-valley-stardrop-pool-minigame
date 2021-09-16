using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Scenes;
using Rectangle = StardropPoolMinigame.Primitives.Rectangle;

namespace StardropPoolMinigame.Render
{
	/// <summary>
	/// Renders entries onto the screen
	/// </summary>
	internal class Renderer
	{
		private IList<IEntity> _entities;

		public Renderer()
		{
			InitializeStaticEntities();
		}

		/// <summary>
		/// Draws all entities for scenes
		/// </summary>
		/// <param name="batch">XNA Framework SpriteBatch</param>
		/// <param name="entering">Scene in entry transition</param>
		/// <param name="current">Current scene</param>
		/// <param name="exiting">Scene in exit transition</param>
		public void Draw(
			SpriteBatch batch,
			IScene entering,
			IScene current,
			IScene exiting)
		{
			batch.Begin(
				SpriteSortMode.FrontToBack,
				BlendState.AlphaBlend,
				SamplerState.PointClamp,
				null,
				null);

			DrawStaticEntities(batch);

			if (entering != null) DrawEntities(batch, entering.GetEntities());

			if (current != null) DrawEntities(batch, current.GetEntities());

			if (exiting != null) DrawEntities(batch, exiting.GetEntities());

			batch.End();
		}

		/// <summary>
		/// Draws the provided set of entries
		/// </summary>
		/// <param name="batch">XNA Framework SpriteBatch</param>
		/// <param name="entities">Entities to be drawn</param>
		private void DrawEntities(SpriteBatch batch, IList<IEntity> entities)
		{
			var drawers = GetDrawersFromEntities(entities);

			foreach (var drawer in drawers)
				if (drawer.ShouldDraw())
					drawer.Draw(batch);
		}

		/// <summary>
		/// Draws entries that are always present
		/// </summary>
		/// <param name="batch">XNA Framework SpriteBatch</param>
		private void DrawStaticEntities(SpriteBatch batch)
		{
			DrawEntities(batch, _entities);
		}

		/// <summary>
		/// Retrieves list of drawers for a set of entries
		/// </summary>
		/// <param name="entities">Entities to be drawn</param>
		/// <returns>List of drawers</returns>
		private IList<IDrawer> GetDrawersFromEntities(IList<IEntity> entities)
		{
			IList<IDrawer> drawers = new List<IDrawer>();

			foreach (var entity in entities) drawers.Add(entity.GetDrawer());

			return drawers;
		}

		/// <summary>
		/// Creates static entries
		/// </summary>
		private void InitializeStaticEntities()
		{
			_entities = new List<IEntity>();

			// Background
			_entities.Add(new Solid(
				new Rectangle(
					new Vector2(RenderConstants.AdjustedScreen.Margin.Width(),
						RenderConstants.AdjustedScreen.Margin.Height()),
					(int) RenderConstants.AdjustedScreen.Width(),
					(int) RenderConstants.AdjustedScreen.Height()),
				0.0000f,
				null,
				null,
				Color.Black,
				true));

			// Foreground
			if (!DevConstants.DisableMarginSolids)
			{
				_entities.Add(new Solid(
					new Rectangle(
						new Vector2(0, 0),
						(int) RenderConstants.AdjustedScreen.Margin.Width(),
						RenderConstants.Viewport.Height()),
					0.9000f,
					null,
					null,
					Textures.Color.Solid.MARGIN,
					true));

				_entities.Add(new Solid(
					new Rectangle(
						new Vector2(
							RenderConstants.AdjustedScreen.Margin.Width() + RenderConstants.AdjustedScreen.Width(), 0),
						(int) RenderConstants.AdjustedScreen.Margin.Width(),
						RenderConstants.Viewport.Height()),
					0.9000f,
					null,
					null,
					Textures.Color.Solid.MARGIN,
					true));

				_entities.Add(new Solid(
					new Rectangle(
						new Vector2(RenderConstants.AdjustedScreen.Margin.Width(), 0),
						(int) RenderConstants.AdjustedScreen.Width(),
						(int) RenderConstants.AdjustedScreen.Margin.Height()),
					0.9000f,
					null,
					null,
					Textures.Color.Solid.MARGIN,
					true));

				_entities.Add(new Solid(
					new Rectangle(
						new Vector2(RenderConstants.AdjustedScreen.Margin.Width(),
							RenderConstants.AdjustedScreen.Height() + RenderConstants.AdjustedScreen.Margin.Height()),
						(int) RenderConstants.AdjustedScreen.Width(),
						(int) RenderConstants.AdjustedScreen.Margin.Height()),
					0.9000f,
					null,
					null,
					Textures.Color.Solid.MARGIN,
					true));
			}
		}
	}
}