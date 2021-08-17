using StardropPoolMinigame.Render.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Scenes
{
    interface IScene
    {
        void TransitionEnter();

        void TransitionExit();
        
        void Update();

        void ReceiveLeftClick();

        void ReceiveRightClick();

        ISceneRenderer GetRenderer();

        bool HasNewScene();

        IScene GetNewScene();
    }
}
