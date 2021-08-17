using StardropPoolMinigame.Render.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Scenes
{
    class DialogScene: Scene
    {
        public DialogScene(): base()
        {
            this.SetRenderer(new DialogSceneRenderer());
        }

        public override void Update()
        {

        }

        public override void ReceiveLeftClick()
        {

        }

        public override void ReceiveRightClick()
        {

        }
    }
}
