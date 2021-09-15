using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Render.Drawers
{
    internal class PortraitDrawer : Drawer
    {
        public PortraitDrawer(Portrait portrait) : base(portrait)
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
            base.Draw(
                batch,
                overrideDestination,
                overrideSource,
                overrideColor,
                overrideRotation,
                overrideOrigin,
                overrideScale,
                overrideEffects,
                overrideLayerDepth);

            if (((Portrait)this._entity).IsOnFire())
            {
                ((Portrait)this._entity).GetPortraitFire().GetDrawer().Draw(
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
            if (((Portrait)this._entity).IsShining())
            {
                ((Portrait)this._entity).GetPortraitRays().GetDrawer().Draw(
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
        }

        protected override Color GetRawColor()
        {
            if (((Portrait)this._entity).IsSilhouette())
            {
                return Color.Black;
            }
            if (((Portrait)this._entity).IsDarker())
            {
                return Textures.Color.Shader.SHADOWED;
            }
            return Color.White;
        }

        protected override Rectangle GetRawSource()
        {
            if (((Portrait)this._entity).GetName() == NPCName.Sam)
            {
                switch (((Portrait)this._entity).GetEmotion())
                {
                    case PortraitEmotion.Blush:
                    case PortraitEmotion.Glad:
                    case PortraitEmotion.Laugh:
                    case PortraitEmotion.Smurk:
                        return Textures.Portrait.Sam.LAUGH;
                    case PortraitEmotion.Sad:
                        return Textures.Portrait.Sam.SAD;
                    case PortraitEmotion.Glare:
                        return Textures.Portrait.Sam.GLARE;
                    case PortraitEmotion.Confused:
                    case PortraitEmotion.Frustrated:
                        return Textures.Portrait.Sam.FRUSTRATED;
                    case PortraitEmotion.Oops:
                        return Textures.Portrait.Sam.OOPS;
                    case PortraitEmotion.StraightFace:
                        return Textures.Portrait.Sam.STRAIGHT_FACE;
                    case PortraitEmotion.Suprised:
                    case PortraitEmotion.Shock:
                        return Textures.Portrait.Sam.SHOCK;
                    case PortraitEmotion.Embarassed:
                        return Textures.Portrait.Sam.EMBARASSED;
                    default:
                        return Textures.Portrait.Sam.DEFAULT;
                }
            }
            if (((Portrait)this._entity).GetName() == NPCName.Sebastian)
            {
                switch (((Portrait)this._entity).GetEmotion())
                {
                    case PortraitEmotion.Confused:
                    case PortraitEmotion.Sad:
                        return Textures.Portrait.Sebastian.SAD;
                    case PortraitEmotion.Blush:
                        return Textures.Portrait.Sebastian.BLUSH;
                    case PortraitEmotion.Frustrated:
                    case PortraitEmotion.Oops:
                    case PortraitEmotion.Shock:
                    case PortraitEmotion.Embarassed:
                    case PortraitEmotion.Suprised:
                    case PortraitEmotion.Glare:
                        return Textures.Portrait.Sebastian.GLARE;
                    case PortraitEmotion.Glad:
                        return Textures.Portrait.Sebastian.GLAD;
                    case PortraitEmotion.Laugh:
                    case PortraitEmotion.Smurk:
                        return Textures.Portrait.Sebastian.SMURK;
                    case PortraitEmotion.StraightFace:
                    default:
                        return Textures.Portrait.Sebastian.DEFAULT;
                }
            }
            if (((Portrait)this._entity).GetName() == NPCName.Abigail)
            {
                switch (((Portrait)this._entity).GetEmotion())
                {
                    case PortraitEmotion.Smurk:
                    case PortraitEmotion.Glad:
                    case PortraitEmotion.Embarassed:
                    case PortraitEmotion.Laugh:
                        return Textures.Portrait.Abigail.LAUGH;
                    case PortraitEmotion.Sad:
                        return Textures.Portrait.Abigail.SAD;
                    case PortraitEmotion.Confused:
                        return Textures.Portrait.Abigail.CONFUSED;
                    case PortraitEmotion.Blush:
                        return Textures.Portrait.Abigail.BLUSH;
                    case PortraitEmotion.Frustrated:
                    case PortraitEmotion.Oops:
                    case PortraitEmotion.Shock:
                    case PortraitEmotion.Glare:
                        return Textures.Portrait.Abigail.GLARE;
                    case PortraitEmotion.Suprised:
                        return Textures.Portrait.Abigail.SUPRISED;
                    case PortraitEmotion.StraightFace:
                    default:
                        return Textures.Portrait.Abigail.DEFAULT;
                }
            }
            if (((Portrait)this._entity).GetName() == NPCName.Gus)
            {
                switch (((Portrait)this._entity).GetEmotion())
                {
                    case PortraitEmotion.Suprised:
                    case PortraitEmotion.Embarassed:
                    case PortraitEmotion.Shock:
                    case PortraitEmotion.Laugh:
                        return Textures.Portrait.Gus.LAUGH;
                    case PortraitEmotion.Oops:
                    case PortraitEmotion.Blush:
                        return Textures.Portrait.Gus.BLUSH;
                    case PortraitEmotion.Frustrated:
                    case PortraitEmotion.Sad:
                    case PortraitEmotion.Confused:
                    case PortraitEmotion.Glare:
                        return Textures.Portrait.Gus.GLARE;
                    case PortraitEmotion.StraightFace:
                    case PortraitEmotion.Glad:
                    case PortraitEmotion.Smurk:
                    default:
                        return Textures.Portrait.Gus.DEFAULT;
                }
            }
            return Textures.Portrait.Sam.DEFAULT;
        }

        protected override Texture2D GetTileset()
        {
            switch (((Portrait)this._entity).GetName())
            {
                case NPCName.Sebastian:
                    return Textures.Tileset.PortraitSebastian;
                case NPCName.Abigail:
                    return Textures.Tileset.PortraitAbigail;
                case NPCName.Gus:
                    return Textures.Tileset.PortraitGus;
                default:
                    return Textures.Tileset.PortraitSam;
            }
        }
    }
}