using Terraria.ID;
using Terraria.ModLoader;

namespace RubyMedallion
{
    public class RubyMedallion : Mod
    {
        public override void Load()
        {
            ModContent.GetInstance<BareEssentials.BareEssentials>()
                .AddToShop(NPCID.Merchant, ModContent.ItemType<Items.RubyMedallion>());
        }
    }
}