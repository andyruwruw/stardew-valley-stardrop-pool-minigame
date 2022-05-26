using StardropPoolMinigame.Enums;
using System.Collections.Generic;

namespace StardropPoolMinigame.Scenes.Dialog.Scripts
{
    internal class Recitation : IRecitation
    {
        private int _delay;

        private PortraitEmotion _emotion;

        private bool _hasFire;

        private bool _hasShine;

        private bool _isDarker;

        private NPCName _name;

        private IList<string> _sounds;

        private string _text;

        public Recitation(
            NPCName name,
            PortraitEmotion emotion,
            string text = "",
            IList<string> sounds = null,
            bool hasFire = false,
            bool hasShine = false,
            bool isDarker = false,
            int delay = -1)
        {
            this._name = name;
            this._emotion = emotion;
            this._text = text;
            this._sounds = sounds;
            this._hasShine = hasShine;
            this._hasFire = hasFire;
            this._isDarker = isDarker;
            this._delay = delay;
        }

        public int GetDelay()
        {
            return this._delay;
        }

        public PortraitEmotion GetEmotion()
        {
            return this._emotion;
        }

        public NPCName GetName()
        {
            return this._name;
        }

        public IList<string> GetSounds()
        {
            return this._sounds;
        }

        public string GetText()
        {
            return this._text;
        }

        public bool HasFire()
        {
            return this._hasFire;
        }

        public bool HasShine()
        {
            return this._hasShine;
        }
    }
}