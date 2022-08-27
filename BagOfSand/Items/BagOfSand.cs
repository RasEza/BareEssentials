using System.Reflection;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace BagOfSand.Items
{
    class BagOfSand : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bag of Sand");
            Tooltip.SetDefault("Starts and stops sandstorms");
        }

        public override void SetDefaults()
        {
            Item.scale = .8f;
            Item.width = 36;
            Item.height = 34;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.holdStyle = ItemHoldStyleID.None;
            Item.useAnimation = 40;
            Item.useTime = 17;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item8;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.buyPrice(gold: 10);
        }

        public override bool? UseItem(Player player)
        {
            if (!Sandstorm.Happening)
                Sandstorm.StartSandstorm();  
            else
            {
                Sandstorm.StopSandstorm();
            }

            return true;
        }
    }
}
