using Terraria.ID;
using Terraria.ModLoader;

namespace MirrorOfRemorse
{
	public class MirrorOfRemorse : Mod
	{
        public override void Load()
        {
            ModContent.GetInstance<BareEssentials.BareEssentials>()
                .AddToShop(NPCID.Merchant, ModContent.ItemType<Items.MirrorOfRemorse>(), 1);
        }
    }
}