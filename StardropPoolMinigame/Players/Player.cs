using Microsoft.Xna.Framework;
using StardewValley;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Players
{
    internal class Player : IPlayer
    {
        private BallType _ballType;

        private Cue _cue;

        private bool _isComputer;

        private bool _isMe;

        private string _music;

        private string _name;

        private long _playerId;

        public Player(
            string name,
            bool isMe,
            bool isComputer,
            long playerId,
            string music = null)
        {
            this._name = name;
            this._isMe = isMe;
            this._isComputer = isComputer;
            this._playerId = playerId;
            this._music = music == null ? SoundConstants.Theme.GAME : music;
            this._ballType = BallType.Any;
            this._cue = new Cue(
                Origin.CenterLeft,
                new Vector2(0, 0),
                0.0080f,
                null);
        }

        public static IPlayer GetMainPlayer()
        {
            return new Player(
                Game1.player.displayName,
                true,
                false,
                Game1.player.uniqueMultiplayerID);
        }

        public BallType GetBallType()
        {
            return this._ballType;
        }

        public Cue GetCue()
        {
            return this._cue;
        }

        public virtual string GetMusicId()
        {
            return this._music;
        }

        public string GetName()
        {
            return this._name;
        }

        public long GetPlayerId()
        {
            return this._playerId;
        }

        public bool IsComputer()
        {
            return this._isComputer;
        }

        public bool IsMe()
        {
            return this._isMe;
        }

        public void SetBallType(BallType ballType)
        {
            this._ballType = ballType;
        }
    }
}