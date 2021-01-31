using Terraria.ModLoader;

namespace HordePotion
{
    public class HordePlayer : ModPlayer
    {
        public bool Horde;
        public int HordeStacks;

        public override void ResetEffects()
        {
            if (!Horde)
                HordeStacks = 1;
            Horde = false;
        }
    }
}
