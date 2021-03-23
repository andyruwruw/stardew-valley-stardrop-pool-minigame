using StardewModdingAPI;
using StardewValley;
using StardropPoolMinigame.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame
{
    public class Multiplayer
    {
        public static IModHelper helper;

        public static IList<IMultiplayerPeer> PlayablePeers;

        public static IList<IMultiplayerPeer> UnplayablePeers;

        public static void SetHelper(IModHelper helper)
        {
            Multiplayer.helper = helper;
        }

        public static bool CanPlayMultiplayer()
        {
            Multiplayer.PlayablePeers = new List<IMultiplayerPeer>();
            Multiplayer.UnplayablePeers = new List<IMultiplayerPeer>();

            if (Game1.IsMultiplayer)
            {
                foreach(IMultiplayerPeer peer in Multiplayer.helper.Multiplayer.GetConnectedPlayers())
                {
                    bool added = false;

                    if (peer.HasSmapi)
                    {
                        foreach(IMultiplayerPeerMod mod in peer.Mods)
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

        public static void Send(IModMessage message)
        {
            Multiplayer.helper.Multiplayer.SendMessage(message, message.GetMessageType(), modIDs: new[] { "andyruwruw.StardropPoolMinigame" });
        }
    }
}
