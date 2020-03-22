using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Reflection;

namespace BareEssentials.Items
{
    public class RainDoll : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rain Doll");
            Tooltip.SetDefault("Starts and stops rain on command");
        }

        public override void SetDefaults()
        {
            item.scale = 1.5f;
            item.width = 17;
            item.height = 23;
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

        public override bool UseItem(Player player)
        {
            var methodName = Main.raining ? "StopRain" : "StartRain";

            var method = typeof(Main).GetMethod(methodName,
                BindingFlags.Static | BindingFlags.NonPublic);
            method?.Invoke(null, null);

            NetMessage.SendData(MessageID.WorldData);
            return true;
        }
    }
}