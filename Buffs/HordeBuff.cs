using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace BareEssentials.Buffs
{
    class HordeBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Horde");
            Description.SetDefault("Increases spawn rate significantly");
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<BareEssentialsPlayer>().Horde = true;
        }

        public override bool ReApply(Player player, int time, int buffIndex)
        {
            if (player.GetModPlayer<BareEssentialsPlayer>().HordeStacks < 2)
            {
                player.GetModPlayer<BareEssentialsPlayer>().HordeStacks++;
                Main.NewText("Super-Charged Horde Effect!", Color.BlueViolet);
            }
            player.buffTime[buffIndex] = 36000;
            return true;
        }
    }
}