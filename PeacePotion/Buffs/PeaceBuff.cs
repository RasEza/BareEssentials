using Terraria;
using Terraria.ModLoader;

namespace PeacePotion.Buffs
{
    class PeaceBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Peace");
            // Description.SetDefault("Stops all monster spawns");
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<PeacePlayer>().Peace = true;
        }
    }
}
