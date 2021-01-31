using Terraria.ID;
using Terraria.ModLoader;

namespace HordePotion
{
	public class HordePotion : Mod
	{
        public override void Load()
        {
            ModContent.GetInstance<BareEssentials.BareEssentials>()
                .AddToShop(NPCID.Merchant, ModContent.ItemType<Items.HordePotion>(), 3);
        }
    }
}