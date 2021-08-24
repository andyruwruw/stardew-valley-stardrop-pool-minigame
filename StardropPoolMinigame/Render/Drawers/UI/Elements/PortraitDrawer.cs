using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Render.Drawers
{
    class PortraitDrawer: IDrawer
    {
        private Portrait _entity;

        public PortraitDrawer(Portrait portrait)
        {
            this._entity = portrait;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(
                this.GetTileSheet(),
                this.GetDestination(),
                this.GetSource(),
                this.GetColor(),
                this.GetRotation(),
                this.GetOrigin(),
                this.GetScale(),
                this.GetEffects(),
                this.GetLayerDepth());
        }

        public Portrait GetEntity()
        {
            return this._entity;
        }

        public Texture2D GetTileSheet()
        {
            switch (this._entity.GetName())
            {
                case OpponentType.Sebastian:
                    return Textures.PortraitSebastianTilesheet;
                case OpponentType.Abigail:
                    return Textures.PortraitAbigailTilesheet;
                case OpponentType.Gus:
                    return Textures.PortraitGusTilesheet;
                default:
                    return Textures.PortraitSamTilesheet;
            }
        }

        public Vector2 GetDestination()
        {
            Vector2 topLeft = this._entity.GetTopLeft();
            return new Vector2(topLeft.X * RenderConstants.TileScale() + RenderConstants.AdjustedScreenWidthMargin(), topLeft.Y * RenderConstants.TileScale() + RenderConstants.AdjustedScreenHeightMargin());
        }

        public Rectangle GetSource()
        {
            if (this._entity.GetName() == OpponentType.Sam)
            {
                switch (this._entity.GetEmotion())
                {
                    case PortraitEmotion.Blush:
                    case PortraitEmotion.Glad:
                    case PortraitEmotion.Laugh:
                    case PortraitEmotion.Smurk:
                        return Textures.PORTRAIT_SAM_LAUGH_BOUNDS;
                    case PortraitEmotion.Sad:
                        return Textures.PORTRAIT_SAM_SAD_BOUNDS;
                    case PortraitEmotion.Glare:
                        return Textures.PORTRAIT_SAM_GLARE_BOUNDS;
                    case PortraitEmotion.Confused:
                    case PortraitEmotion.Frustrated:
                        return Textures.PORTRAIT_SAM_FRUSTRATED_BOUNDS;
                    case PortraitEmotion.Oops:
                        return Textures.PORTRAIT_SAM_OOPS_BOUNDS;
                    case PortraitEmotion.StraightFace:
                        return Textures.PORTRAIT_SAM_STRAIGHT_FACE_BOUNDS;
                    case PortraitEmotion.Suprised:
                    case PortraitEmotion.Shock:
                        return Textures.PORTRAIT_SAM_SHOCK_BOUNDS;
                    case PortraitEmotion.Embarassed:
                        return Textures.PORTRAIT_SAM_EMBARASSED_BOUNDS;
                    default:
                        return Textures.PORTRAIT_SAM_DEFAULT_BOUNDS;
                }
            }
            if (this._entity.GetName() == OpponentType.Sebastian)
            {
                switch (this._entity.GetEmotion())
                {
                    case PortraitEmotion.Confused:
                    case PortraitEmotion.Sad:
                        return Textures.PORTRAIT_SEBASTIAN_SAD_BOUNDS;
                    case PortraitEmotion.Blush:
                        return Textures.PORTRAIT_SEBASTIAN_BLUSH_BOUNDS;
                    case PortraitEmotion.Frustrated:
                    case PortraitEmotion.Oops:
                    case PortraitEmotion.Shock:
                    case PortraitEmotion.Embarassed:
                    case PortraitEmotion.Suprised:
                    case PortraitEmotion.Glare:
                        return Textures.PORTRAIT_SEBASTIAN_GLARE_BOUNDS;
                    case PortraitEmotion.Glad:
                        return Textures.PORTRAIT_SEBASTIAN_GLAD_BOUNDS;
                    case PortraitEmotion.Laugh:
                    case PortraitEmotion.Smurk:
                        return Textures.PORTRAIT_SEBASTIAN_SMURK_BOUNDS;
                    case PortraitEmotion.StraightFace:
                    default:
                        return Textures.PORTRAIT_SEBASTIAN_DEFAULT_BOUNDS;
                }
            }
            if (this._entity.GetName() == OpponentType.Abigail)
            {
                switch (this._entity.GetEmotion())
                {
                    case PortraitEmotion.Smurk:
                    case PortraitEmotion.Glad:
                    case PortraitEmotion.Embarassed:
                    case PortraitEmotion.Laugh:
                        return Textures.PORTRAIT_ABIGAIL_LAUGH_BOUNDS;
                    case PortraitEmotion.Sad:
                        return Textures.PORTRAIT_ABIGAIL_SAD_BOUNDS;
                    case PortraitEmotion.Confused:
                        return Textures.PORTRAIT_ABIGAIL_CONFUSED_BOUNDS;
                    case PortraitEmotion.Blush:
                        return Textures.PORTRAIT_ABIGAIL_BLUSH_BOUNDS;
                    case PortraitEmotion.Frustrated:
                    case PortraitEmotion.Oops:
                    case PortraitEmotion.Shock:
                    case PortraitEmotion.Glare:
                        return Textures.PORTRAIT_ABIGAIL_GLARE_BOUNDS;
                    case PortraitEmotion.Suprised:
                        return Textures.PORTRAIT_ABIGAIL_SUPRISED_BOUNDS;
                    case PortraitEmotion.StraightFace:
                    default:
                        return Textures.PORTRAIT_ABIGAIL_DEFAULT_BOUNDS;
                }
            }
            if (this._entity.GetName() == OpponentType.Gus)
            {
                switch (this._entity.GetEmotion())
                {
                    case PortraitEmotion.Suprised:
                    case PortraitEmotion.Embarassed:
                    case PortraitEmotion.Shock:
                    case PortraitEmotion.Laugh:
                        return Textures.PORTRAIT_GUS_LAUGH_BOUNDS;
                    
                    case PortraitEmotion.Oops:
                    case PortraitEmotion.Blush:
                        return Textures.PORTRAIT_GUS_BLUSH_BOUNDS;
                    case PortraitEmotion.Frustrated:
                    case PortraitEmotion.Sad:
                    case PortraitEmotion.Confused:
                    case PortraitEmotion.Glare:
                        return Textures.PORTRAIT_GUS_GLARE_BOUNDS;
                    case PortraitEmotion.StraightFace:
                    case PortraitEmotion.Glad:
                    case PortraitEmotion.Smurk:
                    default:
                        return Textures.PORTRAIT_GUS_DEFAULT_BOUNDS;
                }
            }
            return Textures.PORTRAIT_SAM_DEFAULT_BOUNDS;
        }

        public Color GetColor()
        {
            if (this._entity.IsSilhouette())
            {
                return Color.Black;
            }
            return Color.White;
        }

        public float GetRotation()
        {
            return 0f;
        }

        public Vector2 GetOrigin()
        {
            return new Vector2(0, 0);
        }

        public float GetScale()
        {
            return RenderConstants.TileScale();
        }

        public SpriteEffects GetEffects()
        {
            return SpriteEffects.None;
        }

        public float GetLayerDepth()
        {
            return this._entity.GetLayerDepth();
        }
    }
}
