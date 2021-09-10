using StardewValley;

namespace StardropPoolMinigame.Helpers
{
    /// <summary>
    /// Facade for playing sound effects and music.
    /// </summary>
    class Sound
    {
        /// <summary>
        /// Plays a sound based on ID.
        /// </summary>
        /// <param name="id">Sound ID</param>
        public static void PlaySound(string id)
        {
            Game1.playSound(id);
        }

        /// <summary>
        /// <para>Plays music track based on ID.</para>
        /// <para>Utilizes the <see cref="Game1.MusicContext.MiniGame"/> music context.</para>
        /// </summary>
        /// <param name="id">Music ID</param>
        public static void PlayMusic(string id)
        {
            Game1.changeMusicTrack(id, false, Game1.MusicContext.MiniGame);
        }

        /// <summary>
        /// <para>Stops currently playing track.</para>
        /// <para>Only effects the <see cref="Game1.MusicContext.MiniGame"/> music context.</para>
        /// </summary>
        public static void StopMusic()
        {
            Game1.stopMusicTrack(Game1.MusicContext.MiniGame);
        }
    }
}
