using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Scenes
{
    interface IScene
    {
        void Start();

        void Update();

        void ReceiveLeftClick(int x, int y, bool playSound = true);

        bool HasNewScene();

        IScene GetNewScene();
    }
}
