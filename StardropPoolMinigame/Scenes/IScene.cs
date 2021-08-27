using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes
{
    interface IScene
    {
        void Update();

        void ReceiveLeftClick();

        void ReceiveRightClick();

        IList<IEntity> GetEntities();

        bool HasNewScene();

        IScene GetNewScene();

        TransitionState GetTransitionState();

        void SetTransitionState(TransitionState transitionState);

        string GetKey();
    }
}
