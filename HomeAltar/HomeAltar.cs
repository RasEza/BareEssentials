using Terraria.ID;
using Terraria.ModLoader;

namespace HomeAltar
{
	public class HomeAltar : Mod
	{
        public override void Load()
        {
            ModContent.GetInstance<BareEssentials.BareEssentials>()
                .AddToShop(NPCID.Merchant, ModContent.ItemType<Items.HomeAltar>(), 5);
        }
    }
}