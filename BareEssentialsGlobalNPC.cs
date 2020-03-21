using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BareEssentials
{
    public class BareEssentialsGlobalNPC : GlobalNPC
    {
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.Merchant)
            {
                shop.item[nextSlot].SetDefaults(ItemType<Items.CelestialStick>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemType<Items.MirrorOfRemorse>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemType<Items.PeacePotion>());
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemType<Items.HordePotion>());
                nextSlot++;
            }
        }

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (player.GetModPlayer<BareEssentialsPlayer>().Horde)
            {
                if (player.GetModPlayer<BareEssentialsPlayer>().HordeStacks < 2)
                {
                    spawnRate = (int)(spawnRate * 0.1);
                }
                else
                {
                    spawnRate = (int)(spawnRate * 0.01);
                }
                maxSpawns *= 5;
            }

            if (player.GetModPlayer<BareEssentialsPlayer>().Peace)
            {
                spawnRate = (int)(spawnRate * 50.0);
                maxSpawns *= (int)(1.0 / 100);
            }
        }
    }
}