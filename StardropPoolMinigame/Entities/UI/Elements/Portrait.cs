using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    class Portrait : EntityHoverable
    {
        private OpponentType _name;

        private PortraitEmotion _emotion;

        private bool _isSilhouette;

        private bool _isDarker;

        private bool _isHoverable;

        private bool _isOnFire;

        private PortraitFire _portraitFire;

        private bool _isShining;

        private PortraitRays _portraitRays;

        public Portrait(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition,
            OpponentType name,
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

        public override string GetId()
        {
            return $"portrait-{this._id}";
        }

        public override void Update()
        {
            base.Update();


        }

        public override void ClickCallback()
        {
            Sound.PlaySound(SoundConstants.Feedback.BOTTON_PRESS);
        }

        protected override void HoveredCallback()
        {
            if (this._isHoverable)
            {
                Sound.PlaySound(SoundConstants.Feedback.BUTTON_HOVER);
            }
        }

        public override float GetTotalWidth()
        {
            return Textures.Portrait.Sam.DEFAULT.Width;
        }

        public override float GetTotalHeight()
        {
            return Textures.Portrait.Sam.DEFAULT.Height;
        }

        public OpponentType GetName()
        {
            return this._name;
        }

        public void SetEmotion(PortraitEmotion emotion)
        {
            this._emotion = emotion;
        }

        public PortraitEmotion GetEmotion()
        {
            return this._emotion;
        }

        public bool IsSilhouette()
        {
            return this._isSilhouette;
        }

        public void SetSilhouette(bool isSilhouette)
        {
            this._isSilhouette = isSilhouette;
        }

        public bool IsDarker()
        {
            return this._isDarker;
        }

        public void SetDarker(bool isDarker)
        {
            this._isDarker = isDarker;
        }

        public bool IsOnFire()
        {
            return this._isOnFire;
        }

        public void SetIsOnFire(bool isOnFire)
        {
            this._isOnFire = isOnFire;
        }

        public bool IsShining()
        {
            return this._isShining;
        }

        public void SetIsShining(bool isShining)
        {
            this._isShining = isShining;
        }

        public PortraitFire GetPortraitFire()
        {
            return this._portraitFire;
        }

        public PortraitRays GetPortraitRays()
        {
            return this._portraitRays;
        }
    }
}
