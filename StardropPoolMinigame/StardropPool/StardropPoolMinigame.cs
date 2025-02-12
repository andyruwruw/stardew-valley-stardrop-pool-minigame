using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StardewValley;
using StardewValley.Minigames;
using MinigameFramework.Scenes;
using MinigameFramework.Utilities;
using MinigameFramework.Render;
using MinigameFramework.Controls;
using StardopPoolMinigame.Render;
using StardopPoolMinigame.Scenes;
using MinigameFramework.Enums;

namespace StardopPoolMinigame
{
    class StardropPoolMinigame : IMinigame
    {
        /// <summary>
        /// The current playing scene.
        /// </summary>
        private IScene? _scene;

        /// <summary>
        /// The previous scene.
        /// </summary>
        private IScene? _exitingScene;

        /// <summary>
        /// Instantiates the minigame.
        /// </summary>
        public StardropPoolMinigame()
        {
            Textures.LoadTextures();
            GenericTextures.LoadTextures();

            InitializeScenes();
            InitializeState();

            if (_scene != null)
            {
                _scene.Start();
            }
        }

        /// <summary>
        /// Override draw function.
        /// </summary>
        /// <param name="batch">Sprite batch.</param>
        public void draw(SpriteBatch batch)
        {
            batch.Begin(
                SpriteSortMode.FrontToBack,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null,
                null
            );

            if (_scene != null)
            {
                _scene.Draw(batch);
            }

            batch.End();
        }

        /// <summary>
        /// Represents an ingame tick.
        /// </summary>
        /// <param name="time"><see cref="GameTime"/> representation of current time.</param>
        /// <returns></returns>
        public bool tick(GameTime time)
        {
            Input.SetPosition(
                Game1.getMouseX(),
                Game1.getMouseY()
            );

            CheckForNewScene();

            if (_scene != null)
            {
                _scene.Update(time);
            }
            if (_exitingScene != null)
            {
                _exitingScene.Update(time);
            }

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
        )
        {
            if (_scene != null)
            {
                _scene.HandleClick(
                    x,
                    y
                );
            }
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
            if (_scene != null)
            {
                _scene.HandleClickHeld(
                    x,
                    y
                );
            }
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
            if (_scene != null)
            {
                _scene.HandleRightClick(
                    x,
                    y
                );
            }
        }

        /// <summary>
        /// Handles a left released.
        /// </summary>
        /// <param name="x">X coordinate of the mouse click.</param>
        /// <param name="y">Y coordinate of the mouse click.</param>
        public void releaseLeftClick(
            int x,
            int y
        )
        {
            if (_scene != null)
            {
                _scene.HandleClickReleased(
                    x,
                    y
                );
            }
        }

        /// <summary>
        /// Handles a right released.
        /// </summary>
        /// <param name="x">X coordinate of the mouse click.</param>
        /// <param name="y">Y coordinate of the mouse click.</param>
        public void releaseRightClick(
            int x,
            int y
        )
        {
            if (_scene != null)
            {
                _scene.HandleRightClickReleased(
                    x,
                    y
                );
            }
        }

        /// <summary>
        /// Handles a key press.
        /// </summary>
        /// <param name="key"><see cref="Keys">Key</see> representation of the key pressed.</param>
        public void receiveKeyPress(Keys key)
        {
            Logger.Debug($"Recieved Key {key.ToString()}");

            if (key.ToString() == "Escape" || key.ToString() == "E")
            {
                Logger.Info("Force Quit");

                forceQuit();
                return;
            }

            if (_scene != null)
            {
                _scene.HandleKeyPress(key);
            }
        }

        /// <summary>
        /// Handles a key released.
        /// </summary>
        /// <param name="key"><see cref="Keys">Key</see> representation of the key pressed.</param>
        public void receiveKeyRelease(Keys key)
        {
            Logger.Debug($"Recieved Key Release {key.ToString()}");
            if (_scene != null)
            {
                _scene.HandleKeyReleased(key);
            }
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
            Game1.stopMusicTrack(StardewValley.GameData.MusicContext.MiniGame);
            Game1.player.faceDirection(0);
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
        /// Checks if a scene transition is necessary.
        /// </summary>
        protected void CheckForNewScene()
        {
            // If the current scene has a new scene, transition to it.
            if (_scene != null && _scene.HasNewScene())
            {
                _exitingScene = _scene;
                _scene = _scene.GetNewScene();

                _exitingScene.SetTransitionState(TransitionState.Exiting);
            }
            
            // If the last scene has finished transitioning out, remove it.
            if (_exitingScene != null && _exitingScene.GetTransitionState() == TransitionState.Dead)
            {
                _exitingScene = null;
            }
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
