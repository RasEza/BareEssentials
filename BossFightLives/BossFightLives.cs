using System.Collections.Generic;
using BossFightLives.UiConfiguration;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace BossFightLives
{
    public class BossFightLives : Mod
    {
        public LifePool LifePool;
        public ChatAnnouncements ChatAnnouncements;

        public override void Load()
        {
            if (!Main.dedServ)
            {
                LifePool = new LifePool();
                ChatAnnouncements = new ChatAnnouncements();
                ConfigureUi(ModContent.GetInstance<BflClientConfig>());
            }
        }

        public override void Unload()
        {
            if (!Main.dedServ)
            {
                LifePool?.Disable();
                LifePool = null;
                ChatAnnouncements?.Disable();
                ChatAnnouncements = null;
            }
        }

        public void ConfigureUi(BflClientConfig clientConfiguration)
        {
            if (LifePool != null)
            {
                if (clientConfiguration.EnableLifePoolUi)
                {
                    LifePool.Enable();
                    LifePool.UpdateProperties();

                    if (clientConfiguration.ConfigurationMode || BflWorld.IsBossActive)
                        LifePool.Show();
                    else if (!BflWorld.IsBossActive && !clientConfiguration.ConfigurationMode)
                        LifePool.Hide();
                }
                else
                    LifePool.Disable();
            }

            if (ChatAnnouncements != null)
            {
                if (clientConfiguration.EnableChatAnnouncements)
                    ChatAnnouncements.Enable();
                else
                    ChatAnnouncements.Disable();
            }
        }
    }
}