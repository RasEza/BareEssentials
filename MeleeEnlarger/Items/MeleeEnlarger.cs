using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MeleeEnlarger.Items
{
    public class MeleeEnlarger : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Melee Enlarger");
            // Tooltip.SetDefault("Makes your weapon BIG!");
        }

        public override void SetDefaults()
        {
            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.Green;
            Item.width = 17;
            Item.height = 23;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<EnlargerPlayer>().ScaleMultiplier = 2f;
        }
    }
}