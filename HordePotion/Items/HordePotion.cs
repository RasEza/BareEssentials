using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HordePotion.Items
{
    class HordePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Horde Potion");
            // Tooltip.SetDefault("Increases spawn rate by a whole lot...");
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 34;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.buyPrice(gold: 5);
            Item.buffType = Mod.Find<ModBuff>("HordeBuff").Type;
            Item.buffTime = 36000;
        }
    }
}
