using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Render.Drawers;

namespace StardropPoolMinigame.Entities
{
    class Portrait : EntityStatic
    {
        private OpponentType _name;

        private bool _isSilhouette;

        private PortraitEmotion _emotion;

        public Portrait(Origin origin, Vector2 anchor, float layerDepth, OpponentType name, bool isSilhouette, PortraitEmotion emotion = PortraitEmotion.Default) : base(origin, anchor, layerDepth)
        {
            this._name = name;
            this._isSilhouette = isSilhouette;
            this._emotion = emotion;
        }

        public override void Update()
        {
        }

        public Microsoft.Xna.Framework.Rectangle GetSource()
        {
            return Textures.BACKGROUND_BAR_SHELVES_BOUNDS;
        }

        public override IDrawer GetDrawer()
        {
            return new PortraitDrawer(this);
        }

        public override string GetId()
        {
            return $"portrait-{this._id}";
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
