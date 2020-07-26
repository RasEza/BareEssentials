using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BareEssentials.Items
{
    public class HomeAltar : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Your very own Demon altar for your home.");
        }

        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 32;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.value = Item.buyPrice(gold: 1);
            item.createTile = ModContent.TileType<Tiles.HomeAltar>();
        }
    }
}