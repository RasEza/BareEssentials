using Terraria.ID;
using Terraria.ModLoader;

namespace MeleeEnlarger
{
	public class MeleeEnlarger : Mod
	{
        public override void Load()
        {
            ModContent.GetInstance<BareEssentials.BareEssentials>()
                .AddToShop(NPCID.Merchant, ModContent.ItemType<Items.MeleeEnlarger>(), 8);
        }
    }
}