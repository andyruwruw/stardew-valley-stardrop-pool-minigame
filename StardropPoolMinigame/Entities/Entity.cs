using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Controller;
using StardropPoolMinigame.Enums;
using StardropPoolMinigame.Render.Drawers;
using StardropPoolMinigame.Render.Filters;
using Rectangle = StardropPoolMinigame.Primitives.Rectangle;

namespace StardropPoolMinigame.Entities
{
	/// <inheritdoc cref="IEntity"/>
	internal abstract class Entity : IEntity
	{
		/// <summary>
		/// <see cref="IEntity">IEntity's</see> anchor, or position.
		/// </summary>
		protected Vector2 _anchor;

		/// <summary>
		/// <see cref="IEntity">IEntity's</see> <see cref="IDrawer"/> for rendering.
		/// </summary>
		protected IDrawer _drawer;

		/// <summary>
		/// <see cref="IEntity">IEntity's</see> entering <see cref="Transition"/>.
		/// </summary>
		protected IFilter _enteringTransition;

		/// <summary>
		/// <see cref="IEntity">IEntity's</see> exiting <see cref="Transition"/>.
		/// </summary>
		protected IFilter _exitingTransition;

		/// <summary>
		/// <see cref="IEntity">IEntity's</see> perminant <see cref="IFilter">IFilters</see>.
		/// </summary>
		protected IList<IFilter> _filters;

		/// <summary>
		/// <see cref="IEntity">IEntity's</see> unique identifier.
		/// </summary>
		protected string _id;

		/// <summary>
		/// Whether the <see cref="Entity"/> is being hovered by the cursor.
		/// </summary>
		protected bool _isHovered;

		/// <summary>
		/// <see cref="IEntity">IEntity's</see> layer depth for rendering.
		/// </summary>
		protected float _layerDepth;

		/// <summary>
		/// Anchor's relation to <see cref="IEntity">IEntity's</see> position.
		/// </summary>
		protected Origin _origin;

		/// <summary>
		/// <see cref="IEntity">IEntity's</see> current <see cref="TransitionState"/>.
		/// </summary>
		protected TransitionState _transitionState;

		/// <summary>
		/// <para>Instantiates an <see cref="Entity"/>.</para>
		/// </summary>
		/// <param name="origin">Anchor's relation to <see cref="IEntity">IEntity's</see> position</param>
		/// <param name="anchor"><see cref="IEntity">IEntity's</see> anchor, or position<inheritdoc cref="_anchor"/></param>
		/// <param name="layerDepth"><see cref="IEntity">IEntity's</see> layer depth for rendering</param>
		/// <param name="enteringTransition"><see cref="IEntity">IEntity's</see> entering <see cref="Transition"/></param>
		/// <param name="exitingTransition"><see cref="IEntity">IEntity's</see> exiting <see cref="Transition"/></param>
		public Entity(
			Origin origin,
			Vector2 anchor,
			float layerDepth,
			IFilter enteringTransition,
			IFilter exitingTransition)
		{
			_anchor = anchor;
			_drawer = null;
			_enteringTransition = enteringTransition;
			_exitingTransition = exitingTransition;
			_isHovered = false;
			_id = Guid.NewGuid().ToString();
			_layerDepth = layerDepth;
			_origin = origin;

			InitializeFilters();
			InitializeTransitionState();
		}

		/// <inheritdoc cref="IEntity.ClickCallback"/>
		public virtual void ClickCallback()
		{
		}

		/// <inheritdoc cref="IEntity.GetAnchor"/>
		public virtual Vector2 GetAnchor()
		{
			return _anchor;
		}

		/// <inheritdoc cref="IEntity.GetCenter"/>
		public virtual Rectangle GetBoundary()
		{
			return new Rectangle(
				GetTopLeft(),
				GetTotalWidth(),
				GetTotalHeight());
		}

		/// <inheritdoc cref="IEntity.GetCenter"/>
		public virtual Vector2 GetCenter()
		{
			if (GetOrigin() == Origin.TopLeft)
				return Vector2.Add(_anchor, new Vector2(GetTotalWidth() / 2, GetTotalHeight() / 2));

			if (GetOrigin() == Origin.TopCenter) return Vector2.Add(_anchor, new Vector2(0, GetTotalHeight() / 2));

			if (GetOrigin() == Origin.TopRight)
				return Vector2.Add(_anchor, new Vector2(GetTotalWidth() / -2, GetTotalHeight() / 2));

			if (GetOrigin() == Origin.CenterLeft) return Vector2.Add(_anchor, new Vector2(GetTotalWidth() / 2, 0));

			if (GetOrigin() == Origin.CenterCenter) return _anchor;

			if (GetOrigin() == Origin.CenterRight) return Vector2.Add(_anchor, new Vector2(GetTotalWidth() / -2, 0));

			if (GetOrigin() == Origin.BottomLeft)
				return Vector2.Add(_anchor, new Vector2(GetTotalWidth() / 2, GetTotalHeight() / -2));

			if (GetOrigin() == Origin.BottomCenter) return Vector2.Add(_anchor, new Vector2(0, GetTotalHeight() / -2));

			if (GetOrigin() == Origin.BottomRight)
				return Vector2.Add(_anchor, new Vector2(GetTotalWidth() / -2, GetTotalHeight() / -2));

			return _anchor;
		}

		/// <inheritdoc cref="IEntity.GetDrawer"/>
		public virtual IDrawer GetDrawer()
		{
			return _drawer;
		}

		/// <inheritdoc cref="IEntity.GetEnteringTransition"/>
		public virtual IFilter GetEnteringTransition()
		{
			return _enteringTransition;
		}

		/// <inheritdoc cref="IEntity.GetExitingTransition"/>
		public virtual IFilter GetExitingTransition()
		{
			return _exitingTransition;
		}

		/// <inheritdoc cref="IEntity.GetFilters"/>
		public virtual IList<IFilter> GetFilters()
		{
			IList<IFilter> filters = new List<IFilter>();

			if (GetTransitionState() == TransitionState.Exiting && _exitingTransition != null)
				filters.Add(_exitingTransition);

			if (GetTransitionState() == TransitionState.Entering && _enteringTransition != null)
				filters.Add(_enteringTransition);

			foreach (var filter in _filters) filters.Add(filter);

			return filters;
		}

		/// <inheritdoc cref="IEntity.GetId"/>
		public abstract string GetId();

		/// <inheritdoc cref="IEntity.GetLayerDepth"/>
		public virtual float GetLayerDepth()
		{
			return _layerDepth;
		}

		/// <inheritdoc cref="IEntity.GetOrigin"/>
		public virtual Origin GetOrigin()
		{
			return _origin;
		}

		/// <inheritdoc cref="IEntity.GetRawBoundary"/>
		public virtual Rectangle GetRawBoundary()
		{
			var topLeft = GetTopLeft();

			return new Rectangle(
				new Vector2(
					topLeft.X * RenderConstants.TileScale() + RenderConstants.AdjustedScreen.Margin.Width(),
					topLeft.Y * RenderConstants.TileScale() + RenderConstants.AdjustedScreen.Margin.Height()),
				GetTotalWidth() * RenderConstants.TileScale(),
				GetTotalHeight() * RenderConstants.TileScale());
		}

		/// <inheritdoc cref="IEntity.GetTopLeft"/>
		public virtual Vector2 GetTopLeft()
		{
			if (GetOrigin() == Origin.TopLeft) return _anchor;

			if (GetOrigin() == Origin.TopCenter) return new Vector2(_anchor.X - GetTotalWidth() / 2, _anchor.Y);

			if (GetOrigin() == Origin.TopRight) return new Vector2(_anchor.X - GetTotalWidth(), _anchor.Y);

			if (GetOrigin() == Origin.CenterLeft) return new Vector2(_anchor.X, _anchor.Y - GetTotalHeight() / 2);

			if (GetOrigin() == Origin.CenterCenter)
				return new Vector2(_anchor.X - GetTotalWidth() / 2, _anchor.Y - GetTotalHeight() / 2);

			if (GetOrigin() == Origin.CenterRight)
				return new Vector2(_anchor.X - GetTotalWidth(), _anchor.Y - GetTotalHeight() / 2);

			if (GetOrigin() == Origin.BottomLeft) return new Vector2(_anchor.X, _anchor.Y - GetTotalHeight());

			if (GetOrigin() == Origin.BottomCenter)
				return new Vector2(_anchor.X - GetTotalWidth() / 2, _anchor.Y - GetTotalHeight());

			if (GetOrigin() == Origin.BottomRight)
				return new Vector2(_anchor.X - GetTotalWidth(), _anchor.Y - GetTotalHeight());

			return _anchor;
		}

		/// <inheritdoc cref="IEntity.GetTotalWidth"/>
		public abstract float GetTotalHeight();

		/// <inheritdoc cref="IEntity.GetTotalHeight"/>
		public abstract float GetTotalWidth();

		/// <inheritdoc cref="IEntity.GetTransitionState"/>
		public virtual TransitionState GetTransitionState()
		{
			return _transitionState;
		}

		/// <inheritdoc cref="IEntity.HoverCallback"/>
		public virtual void HoverCallback()
		{
		}

		/// <inheritdoc cref="IEntity.IsHovered"/>
		public bool IsHovered()
		{
			return _isHovered;
		}

		/// <inheritdoc cref="IEntity.SetAnchor(Vector2)"/>
		public virtual void SetAnchor(Vector2 anchor)
		{
			_anchor = anchor;
		}

		/// <inheritdoc cref="IEntity.SetEnteringTransition"/>
		public void SetEnteringTransition(IFilter transition)
		{
			_enteringTransition = transition;
		}

		/// <inheritdoc cref="IEntity.SetExitingTransition"/>
		public void SetExitingTransition(IFilter transition)
		{
			_exitingTransition = transition;
		}

		/// <inheritdoc cref="IEntity.SetTransitionState(TransitionState, bool)"/>
		public virtual void SetTransitionState(TransitionState transitionState, bool start = false)
		{
			_transitionState = transitionState;

			if (_transitionState == TransitionState.Entering
				&& _enteringTransition != null
				&& start)
			{
				((Transition) _enteringTransition).ResetTransition();
				((Transition) _enteringTransition).SetKey(_id);
				((Transition) _enteringTransition).StartFilter();
			}

			if (_transitionState == TransitionState.Exiting
				&& _exitingTransition != null
				&& start)
			{
				((Transition) _exitingTransition).ResetTransition();
				((Transition) _exitingTransition).SetKey(_id);
				((Transition) _exitingTransition).StartFilter();
			}
		}

		/// <inheritdoc cref="IEntity.Update"/>
		public virtual void Update()
		{
			UpdateTransitionState();
			UpdateHover();
		}

		/// <summary>
		/// Initializes <see cref="_filters"/> as an empty list of <see cref="IFilter">IFilters</see>.
		/// </summary>
		protected virtual void InitializeFilters()
		{
			_filters = new List<IFilter>();
		}

		/// <summary>
		/// Initializes <see cref="_transitionState"/> based on presence of <see cref="_enteringTransition"/>.
		/// </summary>
		protected virtual void InitializeTransitionState()
		{
			if (_enteringTransition != null)
			{
				_transitionState = TransitionState.Entering;
				_enteringTransition.SetKey(_id);
				((Transition) _enteringTransition).StartFilter();
			}
			else
			{
				_transitionState = TransitionState.Present;
			}
		}

		/// <summary>
		/// Sets <see cref="Entity">Entity's</see> <see cref="_drawer"/> for rendering.
		/// </summary>
		/// <param name="drawer"><see cref="IDrawer"/> for <see cref="Entity"/></param>
		protected virtual void SetDrawer(IDrawer drawer)
		{
			_drawer = drawer;
		}

		/// <summary>
		/// Updates <see cref="Entity">Entity's</see> <see cref="_isHovered"/> based on <see cref="Mouse"/> position.
		/// </summary>
		protected void UpdateHover()
		{
			if (_transitionState == TransitionState.Present && GetRawBoundary().Contains(Mouse.Position))
			{
				if (!_isHovered) HoverCallback();
				_isHovered = true;
			}
			else if (_isHovered)
			{
				_isHovered = false;
			}
		}

		/// <summary>
		/// Updates <see cref="Entity">Entity's</see> <see cref="_transitionState"/> based on current <see cref="Transition"/>.
		/// </summary>
		protected void UpdateTransitionState()
		{
			if (_transitionState == TransitionState.Present || _transitionState == TransitionState.Dead) return;

			if (_transitionState == TransitionState.Entering
				&& _enteringTransition != null
				&& ((Transition) _enteringTransition).IsFinished())
				_transitionState = TransitionState.Present;
			else if (_transitionState == TransitionState.Exiting
				&& (_exitingTransition != null && ((Transition) _exitingTransition).IsFinished()
					|| _exitingTransition == null))
				_transitionState = TransitionState.Dead;
		}
	}
}