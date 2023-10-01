using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BareEssentials
{
    public class BareEssentialsGlobalNpc : GlobalNPC
    {
        public override void ModifyShop(NPCShop shop)
        {
            var shopInventory = GetInstance<BareEssentials>().ShopInventoryDictionary;
            
            if (shopInventory.TryGetValue(shop.NpcType, out var inv))
            {
                foreach (var (_, itemId) in inv)
                {
                    shop.Add(itemId);
                }
            }
        }
    }
}
