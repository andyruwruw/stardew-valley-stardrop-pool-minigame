using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StardropPoolMinigame.Render.Filters
{
    interface IFilter
    {
        string GetName();

        Vector2 ExecuteDestination(Vector2 destination);

        Rectangle ExecuteSource(Rectangle source);

        Color ExecuteColor(Color color);

        float ExecuteRotation(float rotation);

        Vector2 ExecuteOrigin(Vector2 origin);

        float ExecuteScale(float scale);

        SpriteEffects ExecuteEffects(SpriteEffects effects);

        float ExecuteLayerDepth(float layerDepth);
    }
}
