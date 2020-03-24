using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace BareEssentials
{
    class BareEssentialsGlobalItem : GlobalItem
    {
        public override bool UseItem(Item item, Player player)
        {
            if (item.type == ItemID.MagicMirror || item.type == ItemID.IceMirror || item.type == ItemID.CellPhone || item.type == ItemID.RecallPotion)
            {
                player.GetModPlayer<BareEssentialsPlayer>().RemorsePosition = player.position;
            }
            return base.UseItem(item, player);
        }
    }
}
