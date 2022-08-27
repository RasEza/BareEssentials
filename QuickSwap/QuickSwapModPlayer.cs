using Terraria.ModLoader;

namespace QuickSwap
{
    public class QuickSwapModPlayer : ModPlayer
    {
        public int currentItem = -1;

        public override bool PreItemCheck()
        { 
            if (currentItem == Player.selectedItem) 
                return true;

            Player.itemAnimation = 0;
            Player.channel = false;
            currentItem = Player.selectedItem;
            return false;
        }
    }
}
