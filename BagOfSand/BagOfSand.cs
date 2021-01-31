using Terraria.ID;
using Terraria.ModLoader;

namespace BagOfSand
{
	public class BagOfSand : Mod
	{
        public override void Load()
        {
            ModContent.GetInstance<BareEssentials.BareEssentials>()
                .AddToShop(NPCID.Merchant, ModContent.ItemType<Items.BagOfSand>(), 7);
        }
    }
}