using Terraria.ModLoader;

namespace PeacePotion
{
    public class PeacePlayer : ModPlayer
    {
        public bool Peace;

        public override void ResetEffects()
        {
            Peace = false;
        }
    }
}
