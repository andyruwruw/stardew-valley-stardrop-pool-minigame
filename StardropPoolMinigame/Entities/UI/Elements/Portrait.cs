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

        private bool _isSilhouette;

        private PortraitEmotion _emotion;

        private bool _isHoverable;

        public Portrait(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition,
            OpponentType name,
            bool isSilhouette,
            PortraitEmotion emotion = PortraitEmotion.Default,
            bool isHoverable = false
        ) : base(
            origin,
            anchor,
            layerDepth,
            enteringTransition,
            exitingTransition)
        {
            this._name = name;
            this._isSilhouette = isSilhouette;
            this._emotion = emotion;
            this._isHoverable = isHoverable;

            this.SetDrawer(new PortraitDrawer(this));
        }

        public override void Update()
        {
            this.UpdateHoverable();
            this.UpdateTransitionState();
        }

        public override string GetId()
        {
            return $"portrait-{this._id}";
        }

        public override void ClickCallback()
        {
            Sound.PlaySound(SoundConstants.BOTTON_PRESS);
        }

        protected override void HoveredCallback()
        {
            if (this._isHoverable)
            {
                Sound.PlaySound(SoundConstants.BUTTON_HOVER);
            }
        }

        public override float GetTotalWidth()
        {
            return Textures.PORTRAIT_SAM_DEFAULT_BOUNDS.Width;
        }

        public override float GetTotalHeight()
        {
            return Textures.PORTRAIT_SAM_DEFAULT_BOUNDS.Height;
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

        public void SetExitingTransition(IFilter transition)
        {
            this._exitingTransition = transition;
        }
    }
}
