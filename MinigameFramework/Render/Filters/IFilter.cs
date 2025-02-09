using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MinigameFramework.Render.Filters
{
    /// <summary>
    /// Applies a filter prior to drawing an entity.
    /// </summary>
    interface IFilter
    {
        /// <summary>
        /// Filters color based on filter's progress.
        /// </summary>
        /// <param name="color">Original <see cref="Color"/>.</param>
        /// <returns>Filtered <see cref="Color"/>.</returns>
        Color GetColor(Color color);

        /// <summary>
        /// Filters destination based on filter's progress.
        /// </summary>
        /// <param name="color">Original destination.</param>
        /// <returns>Filtered destination.</returns>
        Vector2 GetDestination(Vector2 destination);

        /// <summary>
        /// Filters sprite effects based on filter's progress.
        /// </summary>
        /// <param name="color">Original <see cref="SpriteEffects"/>.</param>
        /// <returns>Filtered <see cref="SpriteEffects"/>.</returns>
        SpriteEffects GetEffects(SpriteEffects effects);

        /// <summary>
        /// Filters layer depth based on filter's progress.
        /// </summary>
        /// <param name="color">Original layer depth.</param>
        /// <returns>Filtered layer depth.</returns>
        float GetLayerDepth(float layerDepth);

        /// <summary>
        /// Filters origin based on filter's progress.
        /// </summary>
        /// <param name="color">Original origin.</param>
        /// <returns>Filtered origin.</returns>
        Vector2 GetOrigin(Vector2 origin);

        /// <summary>
        /// Filters rotation based on filter's progress.
        /// </summary>
        /// <param name="color">Original rotation.</param>
        /// <returns>Filtered rotation.</returns>
        float GetRotation(float rotation);

        /// <summary>
        /// Filters scale based on filter's progress.
        /// </summary>
        /// <param name="color">Original scale.</param>
        /// <returns>Filtered scale.</returns>
        float GetScale(float scale);

        /// <summary>
        /// Filters source based on filter's progress.
        /// </summary>
        /// <param name="color">Original source.</param>
        /// <returns>Filtered source.</returns>
        Rectangle GetSource(Rectangle source);

        /// <summary>
        /// Returns the filter's name.
        /// </summary>
        string GetName();

        /// <summary>
        /// Sets the filter's key.
        /// </summary>
        void SetKey(string key);

        /// <summary>
        /// Begins the filter.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the filter.
        /// </summary>
        void Stop();
    }
}
