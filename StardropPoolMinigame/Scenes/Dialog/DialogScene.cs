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

        public override ISceneRenderer GetRenderer()
        {
            return new DialogSceneRenderer(this);
        }
    }
}
