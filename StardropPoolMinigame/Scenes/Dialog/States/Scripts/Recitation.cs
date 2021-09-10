using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes.Dialog.Scripts
{
    class Recitation
    {
        private PortraitEmotion _emotion;

        private string _text;

        private IList<string> _sounds;

        private bool _hasShine;

        private bool _hasFire;

        private bool _isDarker;

        private int _delay;

        public Recitation(
            PortraitEmotion emotion,
            string text = "",
            IList<string> sounds = null,
            bool hasFire = false,
            bool hasShine = false,
            bool isDarker = false,
            int delay = -1)
        {
            this._emotion = emotion;
            this._text = text;
            this._sounds = sounds;
            this._hasShine = hasShine;
            this._hasFire = hasFire;
            this._isDarker = isDarker;
            this._delay = delay;
        }

        public PortraitEmotion GetEmotion()
        {
            return this._emotion;
        }

        public string GetText()
        {
            return this._text;
        }

        public IList<string> GetSounds() {
            return this._sounds;
        }

        public bool HasShine()
        {
            return this._hasShine;
        }

        public bool HasFire()
        {
            return this._hasFire;
        }

        public int GetDelay() {
            return this._delay;
        }
    }
}
