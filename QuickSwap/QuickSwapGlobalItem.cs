using Terraria;
using Terraria.ModLoader;

namespace QuickSwap
{
    class QuickSwapGlobalItem : GlobalItem
    {
        public override bool CanUseItem(Item item, Player player)
        {
            if (item.damage <= 0)
                return true;

            if (player.itemAnimation == 0 && player.itemTime == 0 && player.reuseDelay == 0)
                return true;

            return false;
        }
    }
}
