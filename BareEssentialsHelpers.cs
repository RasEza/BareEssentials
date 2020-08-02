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
            player.Teleport(targetPosition, teleportStyle);
        }
    }
}