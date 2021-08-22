using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StardewValley;
using StardewValley.Minigames;
using StardropPoolMinigame.Controller;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Scenes;

namespace StardropPoolMinigame
{
    class StardropPoolMinigame : IMinigame
    {
        /// <summary>
        /// Entering scene
        /// </summary>
        private IScene _enteringScene;

        /// <summary>
        /// Current scene
        /// </summary>
        private IScene _currentScene;

        /// <summary>
        /// Exiting scene
        /// </summary>
        private IScene _exitingScene;

        /// <summary>
        /// Renders scene entities
        /// </summary>
        private Renderer _renderer;

        public StardropPoolMinigame()
        {
            Textures.LoadTextures();

            this._enteringScene = new MenuScene();
            this._currentScene = null;
            this._exitingScene = null;

            this._renderer = new Renderer();
        }

        public string minigameId()
        {
            return "StarDropPoolMinigame";
        }

        public bool tick(GameTime time)
        {
            Cursor.SetPosition(Game1.getMouseX(), Game1.getMouseY());
            return false;
        }

		public bool doMainGameUpdates()
        {
            if (this._enteringScene != null)
            {
                this._enteringScene.Update();
            }
            if (this._currentScene != null)
            {
                this._currentScene.Update();
            }
            if (this._exitingScene != null)
            {
                this._exitingScene.Update();
            }

            return false;
        }

        public void draw(SpriteBatch batch)
        {
            this._renderer.Draw(batch, this._enteringScene, this._currentScene, this._exitingScene);
        }

        public void receiveLeftClick(int x, int y, bool playSound = true)
        {
            if (this._currentScene != null)
            {
                this._currentScene.ReceiveLeftClick();
            }
        }

		public void receiveRightClick(int x, int y, bool playSound = true)
        {
            if (this._currentScene != null)
            {
                this._currentScene.ReceiveRightClick();
            }
        }

        public void receiveKeyPress(Keys k)
        {
            switch (k)
            {
                case Keys.Escape:
                    this.forceQuit();
                    break;
            }
        }

        public void unload()
        {
            Game1.stopMusicTrack(Game1.MusicContext.MiniGame);
            Game1.player.faceDirection(0);
        }

        public bool forceQuit()
        {
            this.unload();
            Game1.currentMinigame = null;
            return true;
        }

        public void changeScreenSize()
        {
        }

        public void leftClickHeld(int x, int y)
        {
        }

        public void releaseLeftClick(int x, int y)
        {
        }

		public void releaseRightClick(int x, int y)
        {
        }

		public void receiveKeyRelease(Keys k)
        {
        }

		public void receiveEventPoke(int data)
        {
        }

        public bool overrideFreeMouseMovement()
        {
            return true;
        }
    }
}
