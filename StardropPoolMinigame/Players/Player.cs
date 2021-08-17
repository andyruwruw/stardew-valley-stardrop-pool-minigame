﻿using StardewValley;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using System;

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

        private Entities.ICue _cue;

        public Player(string name, bool isMe, bool isComputer, long playerId, string music = null)
        {
            this._name = name;
            this._isMe = isMe;
            this._isComputer = isComputer;
            this._playerId = playerId;
            this._music = music == null ? SoundConstants.GAME_THEME : music;
            this._ballType = BallType.Any;
            this._cue = new Cue();
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

        public virtual string GetMusicId()
        {
            return this._music;
        }

        public bool IsMe()
        {
            return this._isMe;
        }

        public long GetPlayerId()
        {
            return this._playerId;
        }

        public Entities.ICue GetCue()
        {
            return this._cue;
        }
    }
}