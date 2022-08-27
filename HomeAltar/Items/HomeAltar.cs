using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HomeAltar.Items
{
    public class HomeAltar : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Your very own Demon altar for your home.");
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 32;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = Item.buyPrice(gold: 1);
            Item.createTile = ModContent.TileType<Tiles.HomeAltar>();
        }
    }
}