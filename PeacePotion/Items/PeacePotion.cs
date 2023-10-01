using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PeacePotion.Items
{
    class PeacePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Peace Potion");
            // Tooltip.SetDefault("Stops all monster spawns");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.buyPrice(gold: 5);
            Item.buffType = Mod.Find<ModBuff>("PeaceBuff").Type;
            Item.buffTime = 18000;
        }
    }
}
