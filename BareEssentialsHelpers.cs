using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;

namespace BareEssentials
{
    public static class ActionHelper
    {
        public static void Repeat(int iterations, Action a)
        {
            for (var i = 0; i < iterations; i++)
            {
                a.Invoke();
            }
        }
    }

    public static class TeleportHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="targetPosition"></param>
        /// <param name="teleportStyle">0 = teleporter 1 = rod of discord 2 = teleportation potion 3 = wormhole potion 4 = portal gun portal</param>
        public static void TeleportPlayer(this Player player, Vector2 targetPosition, int teleportStyle = 0)
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
                player.Teleport(targetPosition, teleportStyle);
            else
            {
                // number:
                // 0 = normal player teleport
                // 1 = npc teleport
                // 2 = wormhole potion teleport
                NetMessage.SendData(MessageID.Teleport,
                    text: (NetworkText) null,
                    number: 0,
                    number2: player.whoAmI,
                    number3: targetPosition.X,
                    number4: targetPosition.Y,
                    number5: teleportStyle);
            }
        }
    }
}