using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MirrorOfRemorse
{
    class RemorseGlobalItem : GlobalItem
    {
        public override bool UseItem(Item item, Player player)
        {
            if (item.type == ItemID.MagicMirror || item.type == ItemID.IceMirror || item.type == ItemID.CellPhone || item.type == ItemID.RecallPotion)
            {
                player.GetModPlayer<RemorsePlayer>().RemorsePosition = player.position;
            }
            return base.UseItem(item, player);
        }
    }
}
