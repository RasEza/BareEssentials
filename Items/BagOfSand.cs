using System.Reflection;
using Terraria.GameContent.Events;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BareEssentials.Items
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
            item.scale = .8f;
            item.width = 36;
            item.height = 34;
            item.useStyle = ItemUseStyleID.SwingThrow;
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
            if (!Sandstorm.Happening)
                CallPrivateStaticSandStormMethod("StartSandstorm");
            else
                CallPrivateStaticSandStormMethod("StopSandstorm");

            CallPrivateStaticSandStormMethod("UpdateSeverity");

            if (Main.netMode != NetmodeID.SinglePlayer)
                NetMessage.SendData(MessageID.WorldData);

            return true;
        }

        private static void CallPrivateStaticSandStormMethod(string methodName)
        {
            var method = typeof(Sandstorm).GetMethod(methodName,
                BindingFlags.Static | BindingFlags.NonPublic);
            method?.Invoke(null, null);
        }
    }
}
