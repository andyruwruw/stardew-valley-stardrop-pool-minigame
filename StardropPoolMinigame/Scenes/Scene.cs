using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Filters;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes
{
    abstract class Scene : IScene
    {
        protected IScene _newScene;

        protected TransitionState _transitionState;

        protected IList<IEntity> _entities;

        public Scene()
        {
            this._newScene = null;
            this._transitionState = TransitionState.Entering;
            this._entities = new List<IEntity>();
        }

        public virtual void Update()
        {
            this.UpdateEntities();
        }

        public virtual void ReceiveLeftClick()
        {
        }

        public virtual void ReceiveRightClick()
        {
        }

        public virtual IList<IEntity> GetEntities()
        {
            return this._entities;
        }

        public bool HasNewScene()
        {
            return this._newScene != null;
        }

        public IScene GetNewScene()
        {
            return this._newScene;
        }

        public TransitionState GetTransitionState()
        {
            return this._transitionState;
        }

        public abstract string GetKey();

        protected void UpdateEntities()
        {
            bool updateTransition = true;

            foreach (IEntity entity in this._entities)
            {
                entity.Update();

                if (this._transitionState == TransitionState.Entering
                    && (Transition)entity.GetEnteringTransition() != null
                    && !(((Transition)entity.GetEnteringTransition()).IsFinished()))
                {
                    updateTransition = false;
                }
                if (this._transitionState == TransitionState.Exiting
                    && (Transition)entity.GetExitingTransition() != null
                    && !(((Transition)entity.GetExitingTransition()).IsFinished()))
                {
                    updateTransition = false;
                }
            }

            if (this._transitionState != TransitionState.Present && updateTransition)
            {
                if (this._transitionState == TransitionState.Entering)
                {
                    this._transitionState = TransitionState.Present;
                } else if (this._transitionState == TransitionState.Exiting)
                {
                    this._transitionState = TransitionState.Dead;
                }
            }
        }
    }
}
