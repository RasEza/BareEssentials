using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RubyMedallion.Items
{
    class RubyMedallion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ruby Medallion");
            Tooltip.SetDefault("Used to start the blood moon.");
        }

        public override void SetDefaults()
        {
            Item.scale = .5f;
            Item.width = 32;
            Item.height = 46;
            Item.useStyle = ItemUseStyleID.HoldUp;
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

        public override bool CanUseItem(Player player)
        {
            return !Main.bloodMoon;
        }

        public override bool? UseItem(Player player)
        {
            Main.bloodMoon = true;

            if (Main.netMode != NetmodeID.SinglePlayer)
            {
                NetMessage.SendData(MessageID.WorldData);
            }

            return true;
        }
    }
}