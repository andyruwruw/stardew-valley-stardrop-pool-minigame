using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StardewValley.Minigames;
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
        private TitleScene _title;

        private GameState _gameState;

        public StardropPoolMinigame()
        {
            this._title = new TitleScene();

            this._gameState = GameState.Title;
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
            return true;
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

        }

		public void changeScreenSize()
        {

        }

		public void unload()
        {

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
			return true;
        }

        public GameState GetGameState()
        {
            return this._gameState;
        }

        private IScene GetCurrentScene()
        {
            switch (this._gameState)
            {
                case GameState.Title:
                    return this._title;
            }
            return null;
        }
	}
}
