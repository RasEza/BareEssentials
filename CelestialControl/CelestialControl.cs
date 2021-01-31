using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialControl
{
	public class CelestialControl : Mod
	{
        public override void Load()
        {
            ModContent.GetInstance<BareEssentials.BareEssentials>()
                .AddToShop(NPCID.Merchant, ModContent.ItemType<Items.CelestialStick>(), 0);
        }
    }
}