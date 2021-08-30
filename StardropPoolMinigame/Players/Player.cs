using Microsoft.Xna.Framework;
using StardewValley;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Players
{
    class Player : IPlayer
    {
        private string _name;

        private bool _isMe;

        private bool _isComputer;

        private long _playerId;

        private BallType _ballType;

        private string _music;

        private Cue _cue;

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
                null,
                null);
        }

        public bool IsComputer()
        {
            return this._isComputer;
        }

        public void SetBallType(BallType ballType)
        {
            this._ballType = ballType;
        }

        public BallType GetBallType()
        {
            return this._ballType;
        }

        public bool IsMe()
        {
            return this._isMe;
        }

        public long GetPlayerId()
        {
            return this._playerId;
        }

        public Cue GetCue()
        {
            return this._cue;
        }

        public virtual string GetMusicId()
        {
            return this._music;
        }

        public static IPlayer GetMainPlayer()
        {
            return new Player(
                Game1.player.displayName,
                true,
                false,
                Game1.player.uniqueMultiplayerID);
        }
    }
}
