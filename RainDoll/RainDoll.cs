using Terraria.ID;
using Terraria.ModLoader;

namespace RainDoll
{
	public class RainDoll : Mod
	{
        public override void Load()
        {
            ModContent.GetInstance<BareEssentials.BareEssentials>()
                .AddToShop(NPCID.Merchant, ModContent.ItemType<Items.RainDoll>(), 4);
        }
    }
}