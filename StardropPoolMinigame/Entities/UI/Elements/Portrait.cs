using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;

namespace StardropPoolMinigame.Entities
{
    class Portrait : EntityStatic
    {
        private OpponentType _name;

        private bool _isSilhouette;

        private PortraitEmotion _emotion;

        public Portrait(
            Origin origin,
            Vector2 anchor,
            float layerDepth,
            IFilter enteringTransition,
            IFilter exitingTransition,
            OpponentType name,
            bool isSilhouette,
            PortraitEmotion emotion = PortraitEmotion.Default
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

            this.SetDrawer(new PortraitDrawer(this));
        }

        public override void Update()
        {
            this.UpdateTransitionState();
        }

        public override IDrawer GetDrawer()
        {
            return this._drawer;
        }

        public override string GetId()
        {
            return $"portrait-{this._id}";
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
    }
}
