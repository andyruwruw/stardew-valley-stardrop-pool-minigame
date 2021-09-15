using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StardropPoolMinigame.Render.Filters
{
    internal interface IFilter
    {
        Color ExecuteColor(Color color);

        Vector2 ExecuteDestination(Vector2 destination);

        SpriteEffects ExecuteEffects(SpriteEffects effects);

        float ExecuteLayerDepth(float layerDepth);

        Vector2 ExecuteOrigin(Vector2 origin);

        float ExecuteRotation(float rotation);

        float ExecuteScale(float scale);

        Rectangle ExecuteSource(Rectangle source);

        string GetName();

        void SetKey(string key);

        void StartFilter();
    }
}