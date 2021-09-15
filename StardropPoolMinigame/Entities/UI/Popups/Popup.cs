using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Filters;
using System.Collections.Generic;

namespace StardropPoolMinigame.Entities
{
    internal abstract class Popup : Entity
    {
        private IList<IEntity> _entities;

        private string _text;

        private Text _textEntity;

        public Popup(
            IFilter enteringTransition,
            IFilter exitingTransition,
            string text
        ) : base(
            Origin.CenterCenter,
            new Vector2(RenderConstants.MinigameScreen.WIDTH / 2, RenderConstants.MinigameScreen.HEIGHT / 2),
            RenderConstants.Scenes.General.LayerDepth.POPUP,
            enteringTransition,
            exitingTransition)
        {
            this._entities = new List<IEntity>();
            this._text = text;
        }

        public static Popup GetEndOfTurnPopup(IList<GameEvent> events)
        {
            int ballsPocketed = 0;
            bool wasScratch = false;

            foreach (GameEvent gameEvent in events)
            {
                if (gameEvent == GameEvent.Victory)
                {
                    return new VictoryPopup();
                }
                if (gameEvent == GameEvent.Defeat)
                {
                    return new DefeatPopup();
                }
                if (gameEvent == GameEvent.Scratch)
                {
                    wasScratch = true;
                }
                if (gameEvent == GameEvent.ScoredPoint)
                {
                    ballsPocketed++;
                }
            }

            if (wasScratch)
            {
                return new ScratchPop();
            }

            if (ballsPocketed > 1)
            {
                return new ComboPopup();
            }
            else if (ballsPocketed == 1)
            {
                return new BallPocketedPopup();
            }

            return null;
        }

        public IList<IEntity> GetEntities()
        {
            IList<IEntity> entities = new List<IEntity>();

            foreach (IEntity entity in this._entities)
            {
                entities.Add(entity);
            }

            entities.Add(this._textEntity);

            return entities;
        }

        public override float GetTotalHeight()
        {
            return this._textEntity.GetTotalWidth();
        }

        public override float GetTotalWidth()
        {
            return this._textEntity.GetTotalWidth();
        }

        protected virtual void InitializeText()
        {
            this._textEntity = new Text(
                Origin.CenterCenter,
                new Vector2(RenderConstants.MinigameScreen.WIDTH / 2, RenderConstants.MinigameScreen.HEIGHT / 2),
                this._layerDepth,
                this._enteringTransition,
                this._exitingTransition,
                this._text,
                RenderConstants.MinigameScreen.WIDTH,
                1f,
                true,
                false);
        }
    }
}