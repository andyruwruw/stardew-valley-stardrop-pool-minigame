using Microsoft.Xna.Framework;
using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Entities
{
    class EntityStatic : Entity
    {
        public EntityStatic(Origin origin, Vector2 anchor, float layerDepth) : base(origin, anchor, layerDepth)
        {
        }

        public override string GetId()
        {
            return $"generic-static-entity-{this._id}";
        }
    }
}
