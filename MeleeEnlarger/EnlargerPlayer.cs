using Terraria.ModLoader;

namespace MeleeEnlarger
{
    public class EnlargerPlayer : ModPlayer
    {
        public float ScaleMultiplier = 1f;

        public override void ResetEffects()
        {
            ScaleMultiplier = 1f;
        }

        public override bool PreItemCheck()
        {
            if (!player.HeldItem.IsAir)
            {
                if (player.HeldItem.melee)
                {
                    player.HeldItem.scale = player.HeldItem.GetGlobalItem<EnlargerGlobalItem>().ActualScale * player.GetModPlayer<EnlargerPlayer>().ScaleMultiplier;
                }
            }
            return base.PreItemCheck();
        }
    }
}