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
        public static int screenWidth = 800;
        public static int screenHeight = 544;

        private float _zoomWidth = 800;
        private float _zoomHeight = 544;

        private Vector2 _upperLeft;

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

            batch.Draw(Game1.staminaRect, new Rectangle((int)this._upperLeft.X, (int)this._upperLeft.Y, DrawProxy.screenWidth, DrawProxy.screenHeight), Game1.staminaRect.Bounds, Color.Red, 0f, Vector2.Zero, SpriteEffects.None, 0.0001f);

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

            batch.End();
        }

        public void changeScreenSize()
        {
            float pixelZoomAdjustement = 1f / Game1.options.zoomLevel;

            this._zoomWidth = DrawProxy.screenWidth * pixelZoomAdjustement;
            this._zoomHeight = DrawProxy.screenHeight * pixelZoomAdjustement;

            int viewportWidth = Game1.game1.localMultiplayerWindow.Width;
            int viewportHeight = Game1.game1.localMultiplayerWindow.Height;

            this._upperLeft = new Vector2((float)(viewportWidth - this._zoomWidth) / 2, (viewportHeight - this._zoomHeight) / 2);
        }
    }
}
