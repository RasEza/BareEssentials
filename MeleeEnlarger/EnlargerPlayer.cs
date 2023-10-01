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
            if (!Player.HeldItem.IsAir)
            {
                if (Player.HeldItem.CountsAsClass(DamageClass.Melee))
                {
                    Player.HeldItem.scale = Player.HeldItem.GetGlobalItem<EnlargerGlobalItem>().ActualScale * Player.GetModPlayer<EnlargerPlayer>().ScaleMultiplier;
                }
            }
            return base.PreItemCheck();
        }
    }
}