using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HordePotion.Items
{
    class HordePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Horde Potion");
            Tooltip.SetDefault("Increases spawn rate by a whole lot...");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 34;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 17;
            item.useTime = 17;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Orange;
            item.value = Item.buyPrice(gold: 5);
            item.buffType = mod.BuffType("HordeBuff");
            item.buffTime = 36000;
        }
    }
}
