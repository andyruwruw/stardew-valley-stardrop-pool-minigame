using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
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
            batch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp, null, null);

            switch (state)
            {
                case GameState.Prebattle:
                    this._dialogueDrawer.Draw(scene, batch);
                    break;
                case GameState.Ingame:
                    this._gameDrawer.Draw(scene, batch);
                    break;
                case GameState.Postbattle:
                    this._dialogueDrawer.Draw(scene, batch);
                    break;
                case GameState.Summary:
                    this._summaryDrawer.Draw(scene, batch);
                    break;
                default:
                    this._titleDrawer.Draw(scene, batch);
                    break;
            }

            batch.End();
        }
    }
}
