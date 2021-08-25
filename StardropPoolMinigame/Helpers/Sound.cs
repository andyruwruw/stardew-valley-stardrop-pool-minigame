using StardewValley;

namespace StardropPoolMinigame.Helpers
{
    class Sound
    {
        public static void PlaySound(string id)
        {
            Game1.playSound(id);
        }

        public static void PlayMusic(string id)
        {
            Game1.changeMusicTrack(id, false, Game1.MusicContext.MiniGame);
        }

        public static void StopMusic()
        {
            Game1.stopMusicTrack(Game1.MusicContext.MiniGame);
        }
    }
}
