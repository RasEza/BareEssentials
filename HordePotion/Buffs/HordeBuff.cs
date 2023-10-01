using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace HordePotion.Buffs
{
    class HordeBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Horde");
            // Description.SetDefault("Increases spawn rate significantly");
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<HordePlayer>().Horde = true;
        }

        public override bool ReApply(Terraria.Player player, int time, int buffIndex)
        {
            if (player.GetModPlayer<HordePlayer>().HordeStacks < 2)
            {
                player.GetModPlayer<HordePlayer>().HordeStacks++;
                Main.NewText("Super-Charged Horde Effect!", Color.BlueViolet);
            }
            player.buffTime[buffIndex] = 36000;
            return true;
        }
    }
}