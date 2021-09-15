using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Scenes.Dialog.Scripts;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Scenes
{
    internal class DialogScene : Scene
    {
        /// <summary>
        /// Current line of dialog from <see cref="Script"/>.
        /// </summary>
        private IRecitation _currentRecitation;

        /// <summary>
        /// Portrait <see cref="IEntity"/> of active speaker in <see cref="Script"/>.
        /// </summary>
        private Portrait _portrait;

        /// <summary>
        /// <see cref="ISceneCreator"/> to generate next <see cref="IScene"/>.
        /// </summary>
        private ISceneCreator _sceneCreator;

        /// <summary>
        /// Current dialog <see cref="Script"/>.
        /// </summary>
        private IScript _script;

        /// <summary>
        /// Text <see cref="IEntity"/> of current line of dialog from <see cref="Script"/>.
        /// </summary>
        private Text _text;

        /// <summary>
        /// Instantiates <see cref="DialogScene"/>.
        /// </summary>
        /// <param name="sceneCreator"><see cref="ISceneCreator"/> to generate next <see cref="IScene"/></param>
        public DialogScene(ISceneCreator sceneCreator) : base()
        {
            this._sceneCreator = sceneCreator;
            this._script = Script.GetScript(sceneCreator);
            this._currentRecitation = this._script.GetNext();

            this.AddDependentEntities();

            Sound.PlaySound(SoundConstants.Feedback.DIALOG_START);
        }

        /// <inheritdoc cref="IScene.GetKey"/>
        public override string GetKey()
        {
            return "dialog-scene";
        }

        /// <inheritdoc cref="IScene.ReceiveLeftClick"/>
        public override void ReceiveLeftClick()
        {
            Sound.PlaySound(SoundConstants.Feedback.DIALOG_NEXT);

            IRecitation next = this._script.GetNext();

            if (next == null)
            {
                this.TriggerNextScene();
            }
            else
            {
                this._currentRecitation = next;

                this._portrait.SetEmotion(this._currentRecitation.GetEmotion());
                this._portrait.SetIsOnFire(this._currentRecitation.HasFire());
                this._portrait.SetIsShining(this._currentRecitation.HasShine());

                this._entities.Remove(StringConstants.Entities.Dialog.TEXT);
                this._entities.Add(
                    StringConstants.Entities.Dialog.TEXT,
                    new Text(
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
                        isCentered: true));
            }
        }

        /// <inheritdoc cref="IScene.ReceiveRightClick"/>
        public override void ReceiveRightClick()
        {
            this._currentRecitation = this._script.GetLast();
        }

        /// <inheritdoc cref="Scene.AddDependentEntities"/>
        protected override void AddDependentEntities()
        {
            this._entities.Add(
                StringConstants.Entities.Dialog.PORTRAIT,
                new Portrait(
                    Origin.BottomCenter,
                    new Vector2(
                        RenderConstants.MinigameScreen.WIDTH / 2,
                        RenderConstants.MinigameScreen.HEIGHT / 2),
                    0.0030f,
                    TransitionConstants.Dialog.Portrait.Entering(),
                    null,
                    this._currentRecitation.GetName(),
                    this._currentRecitation.GetEmotion(),
                    isOnFire: this._currentRecitation.HasFire(),
                    isShining: this._currentRecitation.HasShine()));

            this._entities.Add(
                StringConstants.Entities.Dialog.TEXT,
                new Text(
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
                    isCentered: true));
        }

        /// <inheritdoc cref="Scene.AddEntities"/>
        protected override void AddEntities()
        {
        }

        /// <summary>
        /// Generates next <see cref="IScene"/> to replace <see cref="DialogScene"/>
        /// </summary>
        private void TriggerNextScene()
        {
            this._newScene = this._sceneCreator.GetScene();
        }
    }
}