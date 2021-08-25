using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Render.Drawers
{
    class PortraitDrawer : Drawer
    {
        public PortraitDrawer(Portrait portrait) : base(portrait)
        {
        }

        protected override Texture2D GetTileSheet()
        {
            switch (((Portrait)this._entity).GetName())
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

        protected override Rectangle GetRawSource()
        {
            if (((Portrait)this._entity).GetName() == OpponentType.Sam)
            {
                switch (((Portrait)this._entity).GetEmotion())
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
            if (((Portrait)this._entity).GetName() == OpponentType.Sebastian)
            {
                switch (((Portrait)this._entity).GetEmotion())
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
            if (((Portrait)this._entity).GetName() == OpponentType.Abigail)
            {
                switch (((Portrait)this._entity).GetEmotion())
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
            if (((Portrait)this._entity).GetName() == OpponentType.Gus)
            {
                switch (((Portrait)this._entity).GetEmotion())
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

        protected override Color GetRawColor()
        {
            if (((Portrait)this._entity).IsSilhouette())
            {
                return Color.Black;
            }
            return Color.White;
        }
    }
}
