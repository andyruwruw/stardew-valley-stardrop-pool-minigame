using System.Collections.Generic;
using StardewModdingAPI;
using StardewValley;
using StardropPoolMinigame.Constants;
using StardropPoolMinigame.Multiplayer.Messages;

namespace StardropPoolMinigame.Multiplayer
{
	internal class MultiplayerHelper
	{
		public static IMultiplayerHelper Helper;

		public static IList<IMultiplayerPeer> PlayablePeers;

		public static IList<IMultiplayerPeer> UnplayablePeers;

		public static bool CanPlayMultiplayer()
		{
			PlayablePeers = new List<IMultiplayerPeer>();
			UnplayablePeers = new List<IMultiplayerPeer>();

			if (Game1.IsMultiplayer)
				foreach (var peer in Helper.GetConnectedPlayers())
				{
					var added = false;

					if (peer.HasSmapi)
						foreach (var mod in peer.Mods)
							if (mod.Name == StringConstants.General.MinigameName)
							{
								PlayablePeers.Add(peer);
								added = true;

								break;
							}

					if (!added) UnplayablePeers.Add(peer);
				}

			return Game1.IsMultiplayer && PlayablePeers.Count > 0;
		}

		public static long GetNewMultiplayerId()
		{
			return Helper.GetNewID();
		}

		public static void Send(string messageType, IModMessage message)
		{
			Helper.SendMessage(
				message,
				messageType,
				new[] {"andyruwruw.StardropPoolMinigame"});
		}

		public static void SetHelper(IMultiplayerHelper helper)
		{
			Helper = helper;
		}
	}
}