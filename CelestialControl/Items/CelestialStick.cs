using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialControl.Items
{
    class CelestialStick : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Celestial Stick");
            // Tooltip.SetDefault("Swinging this stick changes night to day, or day to night");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 49;
            Item.height = 49;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item8;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.buyPrice(gold: 30);
        }

        public override void AddRecipes()
        {
            var recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CelestialShell);
            recipe.AddIngredient(ItemID.Wood);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }

        public override bool? UseItem(Player player)
        {
            if (!Main.dayTime)
            {
                Main.time = 0;
                Main.dayTime = true;
            }
            else
            {
                Main.time = 0;
                Main.dayTime = false;
                Main.moonPhase += 1;
                if (Main.moonPhase >= 8)
                    Main.moonPhase = 0;
            }

            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.WorldData);
            return true;
        }
    }
}