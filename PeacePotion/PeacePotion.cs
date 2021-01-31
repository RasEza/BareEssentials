using Terraria.ID;
using Terraria.ModLoader;

namespace PeacePotion
{
	public class PeacePotion : Mod
	{
        public override void Load()
        {
            ModContent.GetInstance<BareEssentials.BareEssentials>()
                .AddToShop(NPCID.Merchant, ModContent.ItemType<Items.PeacePotion>(), 2);
        }
    }
}