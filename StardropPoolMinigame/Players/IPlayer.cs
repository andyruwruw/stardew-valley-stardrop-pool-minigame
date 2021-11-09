using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Players
{
    internal interface IPlayer
    {
        BallType GetBallType();

        Cue GetCue();

        string GetMusicId();

        long GetPlayerId();

        bool IsComputer();

        bool IsMe();

        void SetBallType(BallType ballType);

		void StartTurn();
	}
}