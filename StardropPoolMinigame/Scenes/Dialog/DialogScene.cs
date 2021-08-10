using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Scenes
{
    class DialogScene: IScene
    {
        public void Update()
        {

        }

        public void ReceiveLeftClick()
        {

        }

        public void ReceiveRightClick()
        {

        }

        public bool HasNewScene()
        {
            return true;
        }

        public IScene GetNewScene()
        {
            return new DialogScene();
        }
    }
}
