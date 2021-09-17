using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Scenes.Dialog.Scripts;
using StardropPoolMinigame.Utilities;

namespace StardropPoolMinigame.Scenes
{
	internal class DialogScene : Scene
	{
		/// <summary>
		/// <see cref="ISceneCreator"/> to generate next <see cref="IScene"/>.
		/// </summary>
		private readonly ISceneCreator _sceneCreator;

		/// <summary>
		/// Current dialog <see cref="Script"/>.
		/// </summary>
		private readonly IScript _script;

		/// <summary>
		/// Current line of dialog from <see cref="Script"/>.
		/// </summary>
		private IRecitation _currentRecitation;

		/// <summary>
		/// Instantiates <see cref="DialogScene"/>.
		/// </summary>
		/// <param name="sceneCreator"><see cref="ISceneCreator"/> to generate next <see cref="IScene"/></param>
		public DialogScene(ISceneCreator sceneCreator)
		{
			_sceneCreator = sceneCreator;
			_script = Script.GetScript(sceneCreator);
			_currentRecitation = _script.GetNext();

			AddDependentEntities();

			Sound.PlaySound(SoundConstants.Feedback.DialogStart);
		}

		/// <inheritdoc cref="IScene.GetKey"/>
		public override string GetKey()
		{
			return "dialog-scene";
		}

		/// <inheritdoc cref="IScene.ReceiveLeftClick"/>
		public override void ReceiveLeftClick()
		{
			Sound.PlaySound(SoundConstants.Feedback.DialogNext);

			var next = _script.GetNext();

			if (next == null)
			{
				TriggerNextScene();
			}
			else
			{
				_currentRecitation = next;

				GetPortrait().SetEmotion(_currentRecitation.GetEmotion());
				GetPortrait().SetIsOnFire(_currentRecitation.HasFire());
				GetPortrait().SetIsShining(_currentRecitation.HasShine());

				_entities.Remove(StringConstants.Entities.Dialog.Text);
				_entities.Add(
					StringConstants.Entities.Dialog.Text,
					new Text(
						Origin.TopCenter,
						new Vector2(
							RenderConstants.MinigameScreen.Width / 2,
							RenderConstants.MinigameScreen.Height / 2 + RenderConstants.Scenes.Dialog.Text.TopMargin),
						0.0040f,
						TransitionConstants.Dialog.Text.Entering(),
						TransitionConstants.Dialog.Text.Exiting(),
						_currentRecitation.GetText(),
						RenderConstants.Scenes.Dialog.Text.MaxWidth,
						0.6f,
						true));
			}
		}

		/// <inheritdoc cref="IScene.ReceiveRightClick"/>
		public override void ReceiveRightClick()
		{
			_currentRecitation = _script.GetLast();
		}

		/// <inheritdoc cref="Scene.AddDependentEntities"/>
		protected override void AddDependentEntities()
		{
			_entities.Add(
				StringConstants.Entities.Dialog.Portrait,
				new Portrait(
					Origin.BottomCenter,
					new Vector2(
						RenderConstants.MinigameScreen.Width / 2,
						RenderConstants.MinigameScreen.Height / 2),
					0.0030f,
					TransitionConstants.Dialog.Portrait.Entering(),
					null,
					_currentRecitation.GetName(),
					_currentRecitation.GetEmotion(),
					isOnFire: _currentRecitation.HasFire(),
					isShining: _currentRecitation.HasShine()));

			_entities.Add(
				StringConstants.Entities.Dialog.Text,
				new Text(
					Origin.TopCenter,
					new Vector2(
						RenderConstants.MinigameScreen.Width / 2,
						RenderConstants.MinigameScreen.Height / 2 + RenderConstants.Scenes.Dialog.Text.TopMargin),
					0.0040f,
					TransitionConstants.Dialog.Text.FirstEntering(),
					TransitionConstants.Dialog.Text.Exiting(),
					_currentRecitation.GetText(),
					RenderConstants.Scenes.Dialog.Text.MaxWidth,
					0.6f,
					true));
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
			_newScene = _sceneCreator.GetScene();
		}

		/// <summary>
		/// Retrieves Portrait <see cref="IEntity"/> of active speaker in <see cref="Script"/>.
		/// </summary>
		/// <returns>Portrait <see cref="IEntity"/> of active speaker in <see cref="Script"/></returns>
		private Portrait GetPortrait()
		{
			return (Portrait) _entities[StringConstants.Entities.Dialog.Portrait];
		}

		/// <summary>
		/// Retrieves <see cref="Text"/> of current line of dialog from <see cref="Script"/>.
		/// </summary>
		/// <returns><see cref="Text"/> of current line of dialog from <see cref="Script"/></returns>
		private Text GetText()
		{
			return (Text) _entities[StringConstants.Entities.Dialog.Text];
		}
	}
}