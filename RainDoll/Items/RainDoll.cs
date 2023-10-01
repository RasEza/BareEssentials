using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RainDoll.Items
{
    public class RainDoll : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Rain Doll");
            // Tooltip.SetDefault("Starts and stops rain on command");
        }

        public override void SetDefaults()
        {
            Item.scale = 1.5f;
            Item.width = 17;
            Item.height = 23;
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

        public override bool? UseItem(Player player)
        {
            if (Main.raining)
            {
                Main.StopRain();
            }
            else
            {
                Main.StartRain();
            }

            NetMessage.SendData(MessageID.WorldData);

            return true;
        }
    }
}