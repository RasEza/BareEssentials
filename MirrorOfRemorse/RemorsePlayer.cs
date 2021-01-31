using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MirrorOfRemorse
{
    public class RemorsePlayer : ModPlayer
    {
        public Vector2 RemorsePosition;

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            RemorsePosition = player.position;
        }
    }
}
