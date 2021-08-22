using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StardropPoolMinigame.Render.Drawers
{
    interface IDrawer
    {
        void Draw(SpriteBatch batch);

        Texture2D GetTileSheet();

        Rectangle GetDestination();

        Rectangle GetSource();

        Color GetColor();

        float GetRotation();

        Vector2 GetOrigin();

        Vector2 GetScale();

        SpriteEffects GetEffects();

        float GetLayerDepth();
    }
}
