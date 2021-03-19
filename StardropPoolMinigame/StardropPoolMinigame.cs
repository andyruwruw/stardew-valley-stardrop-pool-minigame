using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StardewValley;
using StardewValley.Minigames;
using StardropPoolMinigame.Render;
using StardropPoolMinigame.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame
{
    class StardropPoolMinigame : IMinigame
    {
        private IScene _title;
        private IScene _dialogue;
        private IScene _game;
        private IScene _summary;

        private IDraw _titleDrawer;
        private IDraw _dialogueDrawer;
        private IDraw _gameDrawer;
        private IDraw _summaryDrawer;

        private GameState _gameState;

        public StardropPoolMinigame()
        {
            this.InitializeScenes();
            this.InitializeRenderers();
            this.InitializeState();

            this.GetCurrentScene().Start();
        }

		public bool tick(GameTime time)
        {
            return true;
        }

		public bool overrideFreeMouseMovement()
        {
            return true;
        }

		public bool doMainGameUpdates()
        {
            return false;
        }

		public void receiveLeftClick(int x, int y, bool playSound = true)
        {

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

        }

		public void receiveKeyRelease(Keys k)
        {

        }

		public void draw(SpriteBatch b)
        {
            Console.Info("Trying to draw");
            this.GetCurrentDrawer().draw(this.GetCurrentScene(), b);
        }

		public void changeScreenSize()
        {
            this.screenWidth = 400;
            this.screenHeight = 220;
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
            return true;
        }

        public GameState GetGameState()
        {
            return this._gameState;
        }

        private void InitializeScenes()
        {
            this._title = new TitleScene();
            this._dialogue = new DialogueScene();
            this._game = new GameScene();
            this._summary = new SummaryScene();
        }

        private void InitializeRenderers()
        {
            IDrawFactory drawFactory = new StardewDrawFactory();
            this._titleDrawer = drawFactory.GetTitleSceneDrawer();
            this._dialogueDrawer = drawFactory.GetDialogueSceneDrawer();
            this._gameDrawer = drawFactory.GetGameSceneDrawer();
            this._summaryDrawer = drawFactory.GetSummarySceneDrawer();
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

        private IDraw GetCurrentDrawer()
        {
            switch (this._gameState)
            {
                case GameState.Prebattle:
                    return this._dialogueDrawer;
                case GameState.Ingame:
                    return this._gameDrawer;
                case GameState.Postbattle:
                    return this._dialogueDrawer;
                case GameState.Summary:
                    return this._summaryDrawer;
                default:
                    return this._titleDrawer;
            }
        }
    }
}
