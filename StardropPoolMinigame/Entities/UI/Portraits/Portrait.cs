using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Entities
{
    internal class Portrait : Entity
    {
        private PortraitEmotion _emotion;

        private bool _isDarker;

        private bool _isHoverable;

        private bool _isOnFire;

        private bool _isShining;

        private bool _isSilhouette;

        private NPCName _name;

        private PortraitFire _portraitFire;

        private PortraitRays _portraitRays;

        public Portrait(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition,
            NPCName name,
            PortraitEmotion emotion = PortraitEmotion.Default,
            bool isHoverable = false,
            bool isSilhouette = false,
            bool isDarker = false,
            bool isOnFire = false,
            bool isShining = false
        ) : base(
            origin,
            anchor,
            layerDepth,
            enteringTransition,
            exitingTransition)
        {
            this._name = name;
            this._emotion = emotion;
            this._isHoverable = isHoverable;
            this._isSilhouette = isSilhouette;
            this._isDarker = isDarker;
            this._isOnFire = isOnFire;
            this._isShining = isShining;

            this._portraitFire = new PortraitFire(
                origin,
                anchor,
                layerDepth - 0.0001f,
                enteringTransition,
                exitingTransition);

            this._portraitRays = new PortraitRays(
                origin,
                new Vector2(anchor.X + Textures.Portrait.Sam.DEFAULT.Width / 2, anchor.Y + Textures.Portrait.Sam.DEFAULT.Height / 2),
                layerDepth - 0.0001f,
                enteringTransition,
                exitingTransition);

            this.SetDrawer(new PortraitDrawer(this));
        }

        public override void ClickCallback()
        {
            Sound.PlaySound(SoundConstants.Feedback.BOTTON_PRESS);
        }

        public PortraitEmotion GetEmotion()
        {
            return this._emotion;
        }

        public override string GetId()
        {
            return $"portrait-{this._id}";
        }

        public NPCName GetName()
        {
            return this._name;
        }

        public PortraitFire GetPortraitFire()
        {
            return this._portraitFire;
        }

        public PortraitRays GetPortraitRays()
        {
            return this._portraitRays;
        }

        public override float GetTotalHeight()
        {
            return Textures.Portrait.Sam.DEFAULT.Height;
        }

        public override float GetTotalWidth()
        {
            return Textures.Portrait.Sam.DEFAULT.Width;
        }

        public override void HoverCallback()
        {
            if (this._isHoverable)
            {
                Sound.PlaySound(SoundConstants.Feedback.BUTTON_HOVER);
            }
        }

        public bool IsDarker()
        {
            return this._isDarker;
        }

        public bool IsOnFire()
        {
            return this._isOnFire;
        }

        public bool IsShining()
        {
            return this._isShining;
        }

        public bool IsSilhouette()
        {
            return this._isSilhouette;
        }

        public void SetDarker(bool isDarker)
        {
            this._isDarker = isDarker;
        }

        public void SetEmotion(PortraitEmotion emotion)
        {
            this._emotion = emotion;
        }

        public void SetIsOnFire(bool isOnFire)
        {
            this._isOnFire = isOnFire;
        }

        public void SetIsShining(bool isShining)
        {
            this._isShining = isShining;
        }

        public void SetSilhouette(bool isSilhouette)
        {
            this._isSilhouette = isSilhouette;
        }

        public override void Update()
        {
            base.Update();
        }
    }
}