using StardewModdingAPI;
using StardewValley;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Multiplayer.Messages;
using System.Collections.Generic;

namespace StardropPoolMinigame.Helpers
{
    class Multiplayer
    {
        public static IMultiplayerHelper Helper;

        public static IList<IMultiplayerPeer> PlayablePeers;

        public static IList<IMultiplayerPeer> UnplayablePeers;

        public static void SetHelper(IMultiplayerHelper helper)
        {
            Helper = helper;
        }

        public static bool CanPlayMultiplayer()
        {
            PlayablePeers = new List<IMultiplayerPeer>();
            UnplayablePeers = new List<IMultiplayerPeer>();

            if (Game1.IsMultiplayer)
            {
                foreach (IMultiplayerPeer peer in Helper.GetConnectedPlayers())
                {
                    bool added = false;

                    if (peer.HasSmapi)
                    {
                        foreach (IMultiplayerPeerMod mod in peer.Mods)
                        {
                            if (mod.Name == StringConstants.General.MINIGAME_NAME)
                            {
                                Multiplayer.PlayablePeers.Add(peer);
                                added = true;
                                break;
                            }
                        }
                    }

                    if (!added)
                    {
                        Multiplayer.UnplayablePeers.Add(peer);
                    }
                }
            }

            return Game1.IsMultiplayer && Multiplayer.PlayablePeers.Count > 0;
        }

        public static void Send(string messageType, IModMessage message)
        {
            Helper.SendMessage(
                message,
                messageType,
                modIDs: new[] { "andyruwruw.StardropPoolMinigame" });
        }

        public static long GetNewMultiplayerId()
        {
            return Helper.GetNewID();
        }
    }
}
