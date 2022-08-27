using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace BossFightLives
{
    public class BflWorld : ModSystem
    {
        public static int Lives;
        public static bool IsBossActive;

        public event EventHandler<bool> BossActiveStateChanged;

        public override void PostUpdateWorld()
        {
            var anyBosses = IsAnyBossActive();
            if (anyBosses && !IsBossActive)
            {
                IsBossActive = true;
                Lives = ModContent.GetInstance<BflServerConfig>().SharedLives;
                NetMessage.SendData(MessageID.WorldData);
                BossActiveStateChanged?.Invoke(this, IsBossActive);
            }
            else if (!anyBosses && IsBossActive)
            {
                IsBossActive = false;
                NetMessage.SendData(MessageID.WorldData);
                BossActiveStateChanged?.Invoke(this, IsBossActive);
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.Write(Lives);
            writer.Write(IsBossActive);
        }

        public override void NetReceive(BinaryReader reader)
        {
            Lives = reader.ReadInt32();

            var newBossState = reader.ReadBoolean();
            if (newBossState != IsBossActive)
            {
                BossActiveStateChanged?.Invoke(this, newBossState);
            }

            IsBossActive = newBossState;
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)/* tModPorter Note: Removed. Use ModSystem.ModifyInterfaceLayers */
        {
            var mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    $"{nameof(BossFightLives)}: UI",
                    () =>
                    {
                        var lifePool = ModContent.GetInstance<BossFightLives>()?.LifePool;
                        if (lifePool?.Enabled ?? false)
                        {
                            lifePool.Draw();
                        }

                        return true;
                    },
                    InterfaceScaleType.UI));
            }
        }

        private static bool IsAnyBossActive() => Main.npc.Any(x => x != null && x.active && x.boss);
    }
}