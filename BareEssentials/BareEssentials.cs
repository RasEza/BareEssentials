using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;

namespace BareEssentials
{
    public class BareEssentials : Mod
    {
        public Dictionary<int, List<(int preferredIndex, int itemId)>> ShopInventoryDictionary =
            new Dictionary<int, List<(int preferredIndex, int itemId)>>();

        public void AddToShop(int npcId, int itemId, int preferredIndex = 0)
        {
            if (ShopInventoryDictionary.ContainsKey(npcId))
            {
                ShopInventoryDictionary[npcId].Add((preferredIndex, itemId));
                var sortedNpcInventory = ShopInventoryDictionary[npcId]
                    .OrderBy(x => x.preferredIndex);
                ShopInventoryDictionary[npcId] = sortedNpcInventory.ToList();
            }
            else
            {
                ShopInventoryDictionary.Add(npcId, new List<(int index, int itemId)> {(preferredIndex, itemId)});
            }
        }
    }
}