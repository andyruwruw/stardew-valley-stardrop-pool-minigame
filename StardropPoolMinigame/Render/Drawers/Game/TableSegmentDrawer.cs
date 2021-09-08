using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Primitives;
using System.Collections.Generic;

namespace StardropPoolMinigame.Render.Drawers
{
    class TableSegmentDrawer : Drawer
    {
        public TableSegmentDrawer(TableSegment tableSegment) : base(tableSegment)
        {
        }

        public override void Draw(
            SpriteBatch batch,
            Vector2? overrideDestination = null,
            Microsoft.Xna.Framework.Rectangle? overrideSource = null,
            Color? overrideColor = null,
            float? overrideRotation = null,
            Vector2? overrideOrigin = null,
            float? overrideScale = null,
            SpriteEffects? overrideEffects = null,
            float? overrideLayerDepth = null)
        {
            if (((TableSegment)this._entity).GetTableSegmentType() != TableSegmentType.Felt)
            {
                Vector2 destination = this.GetDestination(overrideDestination);

                // Back
                batch.Draw(
                    this.GetTileset(),
                    destination,
                    Textures.GetTableSegmentBackFromType(((TableSegment)this._entity).GetTableSegmentType()),
                    this.GetColor(overrideColor),
                    this.GetRotation(overrideRotation),
                    this.GetOrigin(overrideOrigin),
                    this.GetScale(overrideScale),
                    this.GetEffects(overrideEffects),
                    this.GetLayerDepth(overrideLayerDepth));

                // Front
                batch.Draw(
                    this.GetTileset(),
                    destination,
                    Textures.GetTableSegmentFrontFromType(((TableSegment)this._entity).GetTableSegmentType()),
                    this.GetColor(overrideColor),
                    this.GetRotation(overrideRotation),
                    this.GetOrigin(overrideOrigin),
                    this.GetScale(overrideScale),
                    this.GetEffects(overrideEffects),
                    LayerDepthConstants.Game.TABLE_FRONT);

                // Shadow
                batch.Draw(
                    this.GetTileset(),
                    new Vector2(destination.X + (RenderConstants.Entities.TableSegment.BORDER * RenderConstants.TileScale()), destination.Y + (RenderConstants.Entities.TableSegment.BORDER * RenderConstants.TileScale())),
                    Textures.GetTableSegmentBackFromType(((TableSegment)this._entity).GetTableSegmentType()),
                    Textures.Color.Shader.SHADOW,
                    this.GetRotation(overrideRotation),
                    this.GetOrigin(overrideOrigin),
                    this.GetScale(overrideScale),
                    this.GetEffects(overrideEffects),
                    this.GetLayerDepth(overrideLayerDepth) - 0.0001f);
            } else
            {
                Vector2 destination = this.GetDestination(overrideDestination);

                // Draw 4 Felt Tiles
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        batch.Draw(
                        this.GetTileset(),
                        new Vector2(
                            destination.X + (Textures.Table.FELT.Width * j * RenderConstants.TileScale()),
                            destination.Y + (Textures.Table.FELT.Height * i * RenderConstants.TileScale())),
                        Textures.Table.FELT,
                        this.GetColor(overrideColor),
                        this.GetRotation(overrideRotation),
                        this.GetOrigin(overrideOrigin),
                        this.GetScale(overrideScale),
                        this.GetEffects(overrideEffects),
                        this.GetLayerDepth(overrideLayerDepth));
                    }
                }
            }

            if (DevConstants.DEBUG_VISUALS)
            {
                this.DrawDebugVisuals(batch);
            }
        }

        protected override void DrawDebugVisuals(SpriteBatch batch)
        {
            IList<Line> bounceableSurfaces = ((TableSegment)this._entity).GetBounceableSurfaces();

            foreach (Line line in bounceableSurfaces)
            {
                DrawDebugLine(
                    batch,
                    line.GetStart(),
                    line.GetEnd(),
                    Color.Pink,
                    1);
            }

            IList<Circle> pockets = ((TableSegment)this._entity).GetPockets();

            foreach (Circle pocket in pockets)
            {
                DrawDebugCircle(
                    batch,
                    pocket.GetCenter(),
                    pocket.GetRadius(),
                    Color.Coral);
            }
        }

        protected override Microsoft.Xna.Framework.Rectangle GetRawSource()
        {
            return Textures.Table.Edge.Back.NORTH;
        }
    }
}