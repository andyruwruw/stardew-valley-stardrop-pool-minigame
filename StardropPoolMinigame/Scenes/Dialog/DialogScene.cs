using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Scenes.Dialog.Scripts;

namespace StardropPoolMinigame.Scenes
{
    class DialogScene: Scene
    {
        private IScene _nextScene;

        private ISceneCreator _sceneCreator;

        private IScript _script;

        private Recitation _currentRecitation;

        private Portrait _portrait;

        private Text _text;

        public DialogScene(IScene nextScene): base()
        {
            this._nextScene = nextScene;
            this._sceneCreator = null;
            this._script = Script.GetScript(nextScene);
            this._currentRecitation = this._script.GetNext();

            this.AddDependentEntities();

            Sound.PlaySound(SoundConstants.Feedback.DIALOG_START);
        }

        public DialogScene(ISceneCreator sceneCreator) : base()
        {
            this._nextScene = null;
            this._sceneCreator = sceneCreator;
            this._script = Script.GetScript(sceneCreator);
            this._currentRecitation = this._script.GetNext();

            this.AddDependentEntities();

            Sound.PlaySound(SoundConstants.Feedback.DIALOG_START);
        }

        public override string GetKey()
        {
            return "dialog-scene";
        }

        private void TriggerNextScene()
        {
            if (this._nextScene != null)
            {
                this._newScene = this._nextScene;
            } else
            {
                this._newScene = this._sceneCreator.GetScene();
            }
        }

        public override void ReceiveLeftClick()
        {
            Sound.PlaySound(SoundConstants.Feedback.DIALOG_NEXT);

            Recitation next = this._script.GetNext();

            if (next == null)
            {
                this.TriggerNextScene();
            } else
            {
                this._currentRecitation = next;

                this._portrait.SetEmotion(this._currentRecitation.GetEmotion());
                this._portrait.SetIsOnFire(this._currentRecitation.HasFire());
                this._portrait.SetIsShining(this._currentRecitation.HasShine());

                this._entities.Remove(this._text);
                this._text = new Text(
                    Origin.TopCenter,
                    new Vector2(
                        RenderConstants.MinigameScreen.WIDTH / 2,
                        RenderConstants.MinigameScreen.HEIGHT / 2 + RenderConstants.Scenes.Dialog.Text.TOP_MARGIN),
                    0.0040f,
                    TransitionConstants.Dialog.Text.Entering(),
                    TransitionConstants.Dialog.Text.Exiting(),
                    this._currentRecitation.GetText(),
                    RenderConstants.Scenes.Dialog.Text.MAX_WIDTH,
                    0.6f,
                    isCentered: true);
                this._entities.Add(this._text);
            }
        }

        public override void ReceiveRightClick()
        {
            this._currentRecitation = this._script.GetLast();
        }

        protected override void AddEntities()
        {
        }

        private void AddDependentEntities()
        {
            this._portrait = new Portrait(
                Origin.BottomCenter,
                new Vector2(
                    RenderConstants.MinigameScreen.WIDTH / 2,
                    RenderConstants.MinigameScreen.HEIGHT / 2),
                0.0030f,
                TransitionConstants.Dialog.Portrait.Entering(),
                null,
                this._script.GetCharacter(),
                this._currentRecitation.GetEmotion(),
                isOnFire: this._currentRecitation.HasFire(),
                isShining: this._currentRecitation.HasShine());
            this._entities.Add(this._portrait);

            this._text = new Text(
                Origin.TopCenter,
                new Vector2(
                    RenderConstants.MinigameScreen.WIDTH / 2,
                    RenderConstants.MinigameScreen.HEIGHT / 2 + RenderConstants.Scenes.Dialog.Text.TOP_MARGIN),
                0.0040f,
                TransitionConstants.Dialog.Text.FirstEntering(),
                TransitionConstants.Dialog.Text.Exiting(),
                this._currentRecitation.GetText(),
                RenderConstants.Scenes.Dialog.Text.MAX_WIDTH,
                0.6f,
                isCentered: true);
            this._entities.Add(this._text);
        }
    }
}
