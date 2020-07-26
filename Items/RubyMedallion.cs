using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BareEssentials.Items
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
            item.scale = .5f;
            item.width = 32;
            item.height = 46;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.holdStyle = ItemHoldStyleID.Default;
            item.useAnimation = 40;
            item.useTime = 17;
            item.useTurn = true;
            item.UseSound = SoundID.Item8;
            item.maxStack = 1;
            item.consumable = false;
            item.rare = ItemRarityID.Orange;
            item.value = Item.buyPrice(gold: 10);
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.bloodMoon;
        }

        public override bool UseItem(Player player)
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