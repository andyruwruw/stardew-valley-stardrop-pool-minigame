using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Render.Scenes;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes
{
    class Scene: IScene
    {
        protected IScene _newScene;

        protected IList<IEntity> _entities;

        public Scene()
        {
            this._newScene = null;
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

        public virtual ISceneRenderer GetRenderer()
        {
            return null;
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

        public virtual string GetKey()
        {
            return "unnamed-scene";
        }

        protected void UpdateEntities()
        {
            foreach (IEntity entity in this._entities)
            {
                entity.Update();
            }
        }
    }
}
