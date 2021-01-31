using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BareEssentials
{
    public class BareEssentialsGlobalNpc : GlobalNPC
    {
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            var shopInventory = GetInstance<BareEssentials>().ShopInventoryDictionary;
            if (shopInventory.TryGetValue(type, out var inventory))
            {
                foreach (var (preferredIndex, itemId) in inventory)
                {
                    shop.item[nextSlot].SetDefaults(itemId);
                    nextSlot++;
                }
            }
        }
    }
}