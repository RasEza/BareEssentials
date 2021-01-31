using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PeacePotion.Items
{
    class PeacePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Peace Potion");
            Tooltip.SetDefault("Stops all monster spawns");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 17;
            item.useTime = 17;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Orange;
            item.value = Item.buyPrice(gold: 5);
            item.buffType = mod.BuffType("PeaceBuff");
            item.buffTime = 18000;
        }
    }
}
