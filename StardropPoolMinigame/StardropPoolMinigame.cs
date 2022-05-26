using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StardewValley;
using StardewValley.Minigames;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Scenes;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame
{
    /// <summary>
    /// Stardrop Pool <see cref="IMinigame"/> class.
    /// </summary>
    internal class StardropPoolMinigame : IMinigame
    {
        /// <summary>
        /// Current scene
        /// </summary>
        private IScene _currentScene;

        /// <summary>
        /// Scene undergoing entering transition
        /// </summary>
        private IScene _enteringScene;

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
            this._enteringScene = Scene.GetDefaultScene();
            this._currentScene = null;
            this._exitingScene = null;

            this._renderer = new Renderer();
        }

        public void changeScreenSize()
        {
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

        public bool forceQuit()
        {
            this.unload();
            Game1.currentMinigame = null;
            return true;
        }

        public void leftClickHeld(int x, int y)
        {
        }

        /// <summary>
        /// Unique identifier for minigame
        /// </summary>
        /// <returns></returns>
        public string minigameId()
        {
            return "StarDropPoolMinigame";
        }

        public bool overrideFreeMouseMovement()
        {
            return true;
        }

        public void receiveEventPoke(int data)
        {
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

        public void receiveKeyRelease(Keys k)
        {
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

        public void releaseLeftClick(int x, int y)
        {
        }

        public void releaseRightClick(int x, int y)
        {
        }

        public bool tick(GameTime time)
        {
            Controller.Mouse.SetPosition(Game1.getMouseX(), Game1.getMouseY());
            return false;
        }

        public void unload()
        {
            Sound.StopMusic();
            Game1.player.faceDirection(0);
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
    }
}