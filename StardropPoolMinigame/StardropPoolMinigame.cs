using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StardewValley;
using StardewValley.Minigames;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Scenes;

namespace StardropPoolMinigame
{
    class StardropPoolMinigame : IMinigame
    {
        private IScene _title;
        private IScene _dialogue;
        private IScene _game;
        private IScene _summary;

        private DrawProxy _drawer;

        private GameState _gameState;

        private Vector2 _mouse;

        public StardropPoolMinigame()
        {
            Textures.LoadTextures();

            this.InitializeScenes();
            this.InitializeState();

            DrawMath.ChangeScreenSize();

            this._drawer = new DrawProxy();
            this.GetCurrentScene().Start();
        }

		public bool tick(GameTime time)
        {
            this._mouse = new Vector2(Game1.getMouseX(), Game1.getMouseY());
            return false;
        }

		public bool overrideFreeMouseMovement()
        {
            return true;
        }

		public bool doMainGameUpdates()
        {
            if (this.GetCurrentScene().HasNewScene())
            {
                IScene newScene = this.GetCurrentScene().GetNewScene();

                if (newScene is TitleScene)
                {
                    this._title = newScene;
                    this._gameState = GameState.Title;
                } else if (newScene is DialogueScene && this.GetCurrentScene() is TitleScene)
                {
                    this._dialogue = newScene;
                    this._gameState = GameState.Prebattle;
                } else if (newScene is DialogueScene && this.GetCurrentScene() is GameScene)
                {
                    this._dialogue = newScene;
                    this._gameState = GameState.Postbattle;
                } else if (newScene is GameScene)
                {
                    this._game = newScene;
                    this._gameState = GameState.Ingame;
                } else if (newScene is SummaryScene)
                {
                    this._summary = newScene;
                    this._gameState = GameState.Summary;
                }
            }
            this.GetCurrentScene().Update();
            return false;
        }

		public void receiveLeftClick(int x, int y, bool playSound = true)
        {
            this.GetCurrentScene().ReceiveLeftClick(x, y, playSound);
        }

		public void leftClickHeld(int x, int y)
        {
        }

		public void receiveRightClick(int x, int y, bool playSound = true)
        {
        }

		public void releaseLeftClick(int x, int y)
        {
        }

		public void releaseRightClick(int x, int y)
        {
        }

		public void receiveKeyPress(Keys k)
        {
            Console.Info($"Recieved Key release {k.ToString()}");
            if (k.ToString() == "Escape")
            {
                Console.Info("Force Quit");
                this.forceQuit();
            }
        }

		public void receiveKeyRelease(Keys k)
        {
        }

		public void draw(SpriteBatch b)
        {
            this._drawer.draw(this._gameState, this.GetCurrentScene(), b);
        }

		public void changeScreenSize()
        {
            DrawMath.ChangeScreenSize();
        }

		public void unload()
        {
            Game1.stopMusicTrack(Game1.MusicContext.MiniGame);
            Game1.player.faceDirection(0);
        }

		public void receiveEventPoke(int data)
        {
        }

		public string minigameId()
        {
			return "StarDropPoolMinigame";
        }

		public bool forceQuit()
        {
            this.unload();
            Game1.currentMinigame = null;
            return true;
        }

        public GameState GetGameState()
        {
            return this._gameState;
        }

        private void InitializeScenes()
        {
            this._title = new TitleScene();
        }

        private void InitializeState()
        {
            this._gameState = GameState.Title;
        }

        private IScene GetCurrentScene()
        {
            switch (this._gameState)
            {
                case GameState.Prebattle:
                    return this._dialogue;
                case GameState.Ingame:
                    return this._game;
                case GameState.Postbattle:
                    return this._dialogue;
                case GameState.Summary:
                    return this._summary;
                default:
                    return this._title;
            }
        }
    }
}
