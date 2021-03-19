using Microsoft.Xna.Framework.Graphics;
using StardropPoolMinigame.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Render
{
    class DrawProxy
    {
        private IDraw _titleDrawer;
        private IDraw _dialogueDrawer;
        private IDraw _gameDrawer;
        private IDraw _summaryDrawer;

        public DrawProxy()
        {
            IDrawFactory drawFactory = new StardewDrawFactory();
            this._titleDrawer = drawFactory.GetTitleSceneDrawer();
            this._dialogueDrawer = drawFactory.GetDialogueSceneDrawer();
            this._gameDrawer = drawFactory.GetGameSceneDrawer();
            this._summaryDrawer = drawFactory.GetSummarySceneDrawer();
        }

        public void draw(GameState state, IScene scene, SpriteBatch batch)
        {
            switch (state)
            {
                case GameState.Prebattle:
                    this._dialogueDrawer.draw(scene, batch);
                    break;
                case GameState.Ingame:
                    this._gameDrawer.draw(scene, batch);
                    break;
                case GameState.Postbattle:
                    this._dialogueDrawer.draw(scene, batch);
                    break;
                case GameState.Summary:
                    this._summaryDrawer.draw(scene, batch);
                    break;
                default:
                    this._titleDrawer.draw(scene, batch);
                    break;
            }
        }
    }
}
