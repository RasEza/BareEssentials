using Terraria;
using Terraria.ModLoader;

namespace MeleeEnlarger
{
    public class EnlargerGlobalItem : GlobalItem
    {
        public float ActualScale = 1f;
        public override bool InstancePerEntity => true;
        protected override bool CloneNewInstances => true;

        public override void SetDefaults(Item item)
        {
            ActualScale = item.scale;
        }

        public override void PostReforge(Item item)
        {
            ActualScale = item.scale;
        }
    }
}