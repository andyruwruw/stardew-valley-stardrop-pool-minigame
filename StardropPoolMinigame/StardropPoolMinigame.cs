using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StardewValley;
using StardewValley.Minigames;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Controller;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Scenes;

namespace StardropPoolMinigame
{
    class StardropPoolMinigame : IMinigame
    {
        /// <summary>
        /// Current scene
        /// </summary>
        private IScene _scene;

        /// <summary>
        /// Handles drawing of each scene
        /// </summary>
        private IRenderer _renderer;

        public StardropPoolMinigame()
        {
            Textures.LoadTextures();
            this._scene = new MenuScene();
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
            this._scene.Update();

            return false;
        }

        public void changeScreenSize()
        {
        }

        public void draw(SpriteBatch batch)
        {
            this._renderer.Draw(batch, this._scene);
        }

        public void receiveLeftClick(int x, int y, bool playSound = true)
        {
            this._scene.ReceiveLeftClick();
        }

		public void receiveRightClick(int x, int y, bool playSound = true)
        {
            this._scene.ReceiveRightClick();
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
