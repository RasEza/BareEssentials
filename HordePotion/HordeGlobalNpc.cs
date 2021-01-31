using Terraria.ModLoader;

namespace HordePotion
{
    public class HordeGlobalNpc : GlobalNPC
    {
        public override void EditSpawnRate(Terraria.Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (player.GetModPlayer<HordePlayer>().Horde)
            {
                if (player.GetModPlayer<HordePlayer>().HordeStacks < 2)
                {
                    spawnRate = (int)(spawnRate * 0.1);
                }
                else
                {
                    spawnRate = (int)(spawnRate * 0.01);
                }
                maxSpawns *= 5;
            }
        }
    }
}