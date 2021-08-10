using StardropPoolMinigame.Entities;
using StardropPoolMinigame.Enums;

namespace StardropPoolMinigame.Players
{
    interface IPlayer
    {
        bool IsComputer();

        bool IsMe();

        void SetBallType(BallType ballType);

        BallType GetBallType();

        string GetMusicId();

        long GetPlayerId();

        ICue GetCue();
    }
}
