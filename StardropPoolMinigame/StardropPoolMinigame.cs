using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StardewValley;
using StardewValley.Minigames;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Players;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Scenes;

namespace StardropPoolMinigame
{
    class StardropPoolMinigame : IMinigame
    {
        /// <summary>
        /// Scene undergoing entering transition
        /// </summary>
        private IScene _enteringScene;

        /// <summary>
        /// Current scene
        /// </summary>
        private IScene _currentScene;

        /// <summary>
        /// Scene undergoing exiting transition
        /// </summary>
        private IScene _exitingScene;

        /// <summary>
        /// Renders scene entities
        /// </summary>
        private Renderer _renderer;

        public StardropPoolMinigame()
        {
            if (DevConstants.AUTO_START_AI_GAME)
            {
                this._enteringScene = new GameScene(Player.GetMainPlayer(), new Sam());
            } else
            {
                this._enteringScene = new MenuScene();
            }
            
            this._currentScene = null;
            this._exitingScene = null;

            this._renderer = new Renderer();
        }

        /// <summary>
        /// Unique identifier for minigame
        /// </summary>
        /// <returns></returns>
        public string minigameId()
        {
            return "StarDropPoolMinigame";
        }

        public bool tick(GameTime time)
        {
            Controller.Mouse.SetPosition(Game1.getMouseX(), Game1.getMouseY());
            return false;
        }

		public bool doMainGameUpdates()
        {
            this.CheckForNewScenes();
            this.ShuffleScenes();
            this.UpdateScenes();
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
            Sound.StopMusic();
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

        private void CheckForNewScenes()
        {
            if (this._currentScene != null && this._currentScene.HasNewScene())
            {
                this._enteringScene = this._currentScene.GetNewScene();
                this._exitingScene = this._currentScene;
                this._currentScene = null;
                this._exitingScene.SetTransitionState(TransitionState.Exiting);

                Logger.Trace($"Transitioning to New Scene: {this._exitingScene.GetType()} => {this._enteringScene.GetType()}");
            }
        }

        private void UpdateScenes()
        {
            if (this._exitingScene != null)
            {
                this._exitingScene.Update();
            }
            if (this._currentScene != null)
            {
                this._currentScene.Update();
            }
            if (this._enteringScene != null)
            {
                this._enteringScene.Update();
            }
        }

        private void ShuffleScenes()
        {
            if (this._exitingScene != null && this._exitingScene.GetTransitionState() == TransitionState.Dead)
            {
                this._exitingScene = null;
            }
            if (this._enteringScene != null && this._enteringScene.GetTransitionState() == TransitionState.Present)
            {
                this._currentScene = this._enteringScene;
                this._enteringScene = null;
            }
        }
    }
}
