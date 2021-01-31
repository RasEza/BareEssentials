using Terraria;
using Terraria.ModLoader;

namespace PeacePotion
{
    public class PeaceGlobalNpc : GlobalNPC
    {
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (player.GetModPlayer<PeacePlayer>().Peace)
            {
                spawnRate = (int)(spawnRate * 50.0);
                maxSpawns *= (int)(1.0 / 100);
            }
        }
    }
}