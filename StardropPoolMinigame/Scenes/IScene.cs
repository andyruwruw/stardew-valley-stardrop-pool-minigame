﻿using StardropPoolMinigame.Entities;
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
        void Update();

        void ReceiveLeftClick();

        void ReceiveRightClick();

        ISceneRenderer GetRenderer();

        IList<IEntity> GetEntities();

        bool HasNewScene();

        IScene GetNewScene();

        string GetKey();
    }
}
