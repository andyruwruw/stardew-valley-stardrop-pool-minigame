using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StardewValley;
using StardewValley.Minigames;
using MinigameFramework.Scenes;
using MinigameFramework.Utilities;
using StardopPoolMinigame.
    Render;
using StardopPoolMinigame.
    Scenes;

namespace StardopPoolMinigame
{
    class StardropPoolMinigame : IMinigame
    {
        /// <summary>
        /// The current playing scene.
        /// </summary>
        private Scene _scene;

        /// <summary>
        /// Instantiates the minigame.
        /// </summary>
        public StardropPoolMinigame()
        {
            Textures.LoadTextures();

            InitializeScenes();
            InitializeState();

            _scene.Start();
        }

        /// <summary>
        /// Represents an ingame tick.
        /// </summary>
        /// <param name="time"><see cref="GameTime"/> representation of current time.</param>
        /// <returns></returns>
        public bool tick(GameTime time)
        {
            if (_scene.HasNewScene())
            {
                IScene newScene = _scene.GetNewScene();
            }
            _scene.Update(time);

            return false;
        }

        /// <summary>
        /// Whether to override free mouse movement.
        /// </summary>
        /// <returns></returns>
        public bool overrideFreeMouseMovement()
        {
            return true;
        }

        /// <summary>
        /// Called upon main game updates.
        /// </summary>
        public bool doMainGameUpdates()
        {
            return false;
        }

        /// <summary>
        /// Handles a left click.
        /// </summary>
        /// <param name="x">X coordinate of the mouse click.</param>
        /// <param name="y">Y coordinate of the mouse click.</param>
        /// <param name="playSound">Whether to play the click sound.</param>
        public void receiveLeftClick(
            int x,
            int y,
            bool playSound = true
        ) {
            _scene.HandleLeftClick(
                x,
                y
            );
        }

        /// <summary>
        /// Handles a left held.
        /// </summary>
        /// <param name="x">X coordinate of the mouse click.</param>
        /// <param name="y">Y coordinate of the mouse click.</param>
        public void leftClickHeld(
            int x,
            int y
        ) {
            _scene.HandleLeftClickHeld(
                x,
                y
            );
        }

        /// <summary>
        /// Handles a right click.
        /// </summary>
        /// <param name="x">X coordinate of the mouse click.</param>
        /// <param name="y">Y coordinate of the mouse click.</param>
        /// <param name="playSound">Whether to play the click sound.</param>
        public void receiveRightClick(
            int x,
            int y,
            bool playSound = true
        ) {
            _scene.HandleRightClick(
                x,
                y
            );
        }

        /// <summary>
        /// Handles a left released.
        /// </summary>
        /// <param name="x">X coordinate of the mouse click.</param>
        /// <param name="y">Y coordinate of the mouse click.</param>
        public void releaseLeftClick(
            int x,
            int y
        ) {
            _scene.HandleLeftClickReleased(
                x,
                y
            );
        }

        /// <summary>
        /// Handles a right released.
        /// </summary>
        /// <param name="x">X coordinate of the mouse click.</param>
        /// <param name="y">Y coordinate of the mouse click.</param>
        public void releaseRightClick(
            int x,
            int y
        ) {
            _scene.HandleRightClickReleased(
                x,
                y
            );
        }

        /// <summary>
        /// Handles a key press.
        /// </summary>
        /// <param name="key"><see cref="Keys">Key</see> representation of the key pressed.</param>
        public void receiveKeyPress(Keys key)
        {
            // Console.Info($"Recieved Key release {k.ToString()}");

            if (key.ToString() == "Escape")
            {
                Logger.Info("Force Quit");

                forceQuit();
                return;
            }

            _scene.HandleKeyPress(key);
        }

        /// <summary>
        /// Handles a key released.
        /// </summary>
        /// <param name="key"><see cref="Keys">Key</see> representation of the key pressed.</param>
        public void receiveKeyRelease(Keys key)
        {
            _scene.HandleKeyRelease(key);
        }

        /// <summary>
        /// Main handler for draw event.
        /// </summary>
        public void draw(SpriteBatch batch)
        {
            _scene.Draw(batch);
        }

        /// <summary>
        /// Handles a screen size change.
        /// </summary>
        public void changeScreenSize()
        {
        }

        /// <summary>
        /// Handles unloading the game.
        /// </summary>
        public void unload()
        {
            // Game1.stopMusicTrack(Game1.MusicContext.MiniGame);
            // Game1.player.faceDirection(0);
        }

        /// <summary>
        /// Handles an event poke.
        /// </summary>
        /// <param name="data">Data of poke.</param>
        public void receiveEventPoke(int data)
        {
        }

        /// <summary>
        /// Returns the minigame ID.
        /// </summary>
        public string minigameId()
        {
            return "StarDropPoolMinigame";
        }

        /// <summary>
        /// Force quits the minigame.
        /// </summary>
        public bool forceQuit()
        {
            unload();
            Game1.currentMinigame = null;

            return true;
        }

        /// <summary>
        /// Initializes the scenes.
        /// </summary>
        protected void InitializeScenes()
        {
            _scene = new MainMenuScene();
        }

        /// <summary>
        /// Initializes the game state.
        /// </summary>
        protected void InitializeState()
        {
        }
    }
}
