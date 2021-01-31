using Terraria.ModLoader;

namespace QuickSwap
{
    public class QuickSwapModPlayer : ModPlayer
    {
        public int currentItem = -1;

        public override bool PreItemCheck()
        { 
            if (currentItem == player.selectedItem) 
                return true;

            player.itemAnimation = 0;
            player.channel = false;
            currentItem = player.selectedItem;
            return false;
        }
    }
}
