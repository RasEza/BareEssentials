using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace BareEssentials
{
    public class BareEssentialsPlayer : ModPlayer
    {
        public Vector2 RemorsePosition;
        public bool Horde;
        public bool Peace;
        public int HordeStacks;

        public override void ResetEffects()
        {
            if (!Horde)
                HordeStacks = 1;
            Horde = false;
            Peace = false;
        }

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            RemorsePosition = player.position;
        }
    }
}
