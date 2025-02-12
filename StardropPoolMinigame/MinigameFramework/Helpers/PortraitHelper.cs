using Microsoft.Xna.Framework.Graphics;
using MinigameFramework.Constants;
using MinigameFramework.Enums;

namespace MinigameFramework.Helpers
{
    /// <summary>
    /// Aid's in portrait fetching.
    /// </summary>
    static class PortraitHelper
    {
        /// <summary>
        /// Retrieves a given portrait for a character and emotion.
        /// </summary>
        /// <param name="name">NPC name.</param>
        /// <param name="emotion">Emotion Displayed.</param>
        public static int GetPortraitIndex(
            DisplayableNPC name,
            PortraitEmotion emotion = PortraitEmotion.Default
        )
        {
            if (name == DisplayableNPC.Abigail)
            {
                return GenericTextureConstants.Portrait.Abigail[emotion];
            }
            if (name == DisplayableNPC.Gus)
            {
                return GenericTextureConstants.Portrait.Gus[emotion];
            }
            if (name == DisplayableNPC.Sam)
            {
                return GenericTextureConstants.Portrait.Sam[emotion];
            }
            if (name == DisplayableNPC.Gus)
            {
                return GenericTextureConstants.Portrait.Sebastian[emotion];
            }

            return 0;
        }
    }
}
