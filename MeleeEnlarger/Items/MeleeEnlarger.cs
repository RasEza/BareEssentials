using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MeleeEnlarger.Items
{
    public class MeleeEnlarger : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Melee Enlarger");
            Tooltip.SetDefault("Makes your weapon BIG!");
        }

        public override void SetDefaults()
        {
            item.value = Item.buyPrice(gold: 5);
            item.rare = ItemRarityID.Green;
            item.width = 17;
            item.height = 23;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<EnlargerPlayer>().ScaleMultiplier = 2f;
        }
    }
}