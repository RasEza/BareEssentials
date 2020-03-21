using Terraria;
using Terraria.ModLoader;

namespace BareEssentials.Buffs
{
    class PeaceBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Peace");
            Description.SetDefault("Stops all monster spawns");
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<BareEssentialsPlayer>().Peace = true;
        }
    }
}
