using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Structures;
using System.Collections.Generic;

namespace StardropPoolMinigame.Render.Drawers
{
    class QuadTreeDrawer<T> : Drawer
    {
        public QuadTreeDrawer(QuadTree<T> tree) : base(tree)
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
            if (DevConstants.DEBUG_VISUALS)
            {
                this.DrawDebugVisuals(batch);
            }
        }

        protected override void DrawDebugVisuals(SpriteBatch batch)
        {
            IList<QuadTree<T>> unvisited = new List<QuadTree<T>>();
            unvisited.Add(((QuadTree<T>)this._entity));

            while (unvisited.Count > 0)
            {
                QuadTree<T> current = unvisited[0];

                if (current.IsSubdivided())
                {
                    unvisited.Add(current.GetNorthWestQuadrant());
                    unvisited.Add(current.GetNorthEastQuadrant());
                    unvisited.Add(current.GetSouthWestQuadrant());
                    unvisited.Add(current.GetSouthEastQuadrant());
                } else
                {
                    DrawDebugLine(
                        batch,
                        ((Primitives.Rectangle)current.GetBoundary()).GetNorthWestCorner(),
                        ((Primitives.Rectangle)current.GetBoundary()).GetNorthEastCorner(),
                        Color.Orange,
                        1);

                    DrawDebugLine(
                        batch,
                        ((Primitives.Rectangle)current.GetBoundary()).GetNorthEastCorner(),
                        ((Primitives.Rectangle)current.GetBoundary()).GetSouthEastCorner(),
                        Color.Orange,
                        1);

                    DrawDebugLine(
                        batch,
                        ((Primitives.Rectangle)current.GetBoundary()).GetSouthEastCorner(),
                        ((Primitives.Rectangle)current.GetBoundary()).GetSouthWestCorner(),
                        Color.Orange,
                        1);

                    DrawDebugLine(
                        batch,
                        ((Primitives.Rectangle)current.GetBoundary()).GetSouthWestCorner(),
                        ((Primitives.Rectangle)current.GetBoundary()).GetNorthWestCorner(),
                        Color.Orange,
                        1);

                    foreach (IEntity point in current.GetPoints())
                    {
                        DrawDebugPoint(
                            batch,
                            point.GetAnchor(),
                            Color.Black);
                    }
                }

                unvisited.RemoveAt(0);
            }
        }

        protected override Rectangle GetRawSource()
        {
            return Game1.staminaRect.Bounds;
        }
    }
}
