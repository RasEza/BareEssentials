using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BareEssentials.Items
{
    class CelestialStick : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celestial Stick");
            Tooltip.SetDefault("Swinging this stick changes night to day, or day to night");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.width = 49;
            item.height = 49;
            item.useStyle = 1;
            item.useAnimation = 17;
            item.useTime = 17;
            item.useTurn = true;
            item.UseSound = SoundID.Item8;
            item.maxStack = 1;
            item.consumable = false;
            item.rare = 3;
            item.value = Item.buyPrice(gold: 30);
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CelestialShell);
            recipe.AddIngredient(ItemID.Wood);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool UseItem(Player player)
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
                Main.moonPhase = Main.moonPhase + 1;
                if (Main.moonPhase >= 8)
                    Main.moonPhase = 0;
            }
            if (Main.netMode == 2)
                NetMessage.SendData(MessageID.WorldData);
            return true;
        }
    }
}