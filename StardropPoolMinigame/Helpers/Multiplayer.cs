using StardewModdingAPI;
using StardewValley;
using StardropPoolMinigame.Messages;
using System.Collections.Generic;

namespace StardropPoolMinigame.Helpers
{
    class Multiplayer
    {
        public static IModHelper Helper;

        public static IList<IMultiplayerPeer> PlayablePeers;

        public static IList<IMultiplayerPeer> UnplayablePeers;

        public static void SetHelper(IModHelper helper)
        {
            Helper = helper;
        }

        public static bool CanPlayMultiplayer()
        {
            PlayablePeers = new List<IMultiplayerPeer>();
            UnplayablePeers = new List<IMultiplayerPeer>();

            if (Game1.IsMultiplayer)
            {
                foreach (IMultiplayerPeer peer in Helper.Multiplayer.GetConnectedPlayers())
                {
                    bool added = false;

                    if (peer.HasSmapi)
                    {
                        foreach (IMultiplayerPeerMod mod in peer.Mods)
                        {
                            if (mod.Name == "StardewPoolMinigame")
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
            Helper.Multiplayer.SendMessage(
                message,
                messageType,
                modIDs: new[] { "andyruwruw.StardropPoolMinigame" });
        }

        public static long GetNewMultiplayerId()
        {
            return Helper.Multiplayer.GetNewID();
        }
    }
}
