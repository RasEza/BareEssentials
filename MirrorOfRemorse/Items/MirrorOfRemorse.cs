using BareEssentials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static BareEssentials.ActionHelper;

namespace MirrorOfRemorse.Items
{
    class MirrorOfRemorse : ModItem
    {
        /* public override void SetStaticDefaults() => 
            Tooltip.SetDefault("Oops, let's try that again"); */

        public override void SetDefaults()
        {
            Item.useTurn = true;
            Item.width = 20;
            Item.height = 20;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 90;
            Item.UseSound = SoundID.Item6;
            Item.useAnimation = 90;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.buyPrice(gold: 20);
        }

        public override bool CanUseItem(Player player) =>
            !player.GetModPlayer<RemorsePlayer>().RemorsePosition.Equals(Vector2.Zero);

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            const int dustType = 27;
            var totalUseTime = CombinedHooks.TotalUseTime(Item.useTime, player, Item);

            if (Main.rand.NextBool())
            {
                Dust.NewDust(player.position, player.width, player.height, dustType, Alpha: 150, newColor: Color.Black,
                    Scale: 1.7f);
            }

            if (player.itemTime == 0)
            {
                player.itemTime = totalUseTime;
            }
            else if (player.itemTime == totalUseTime / 2)
            {
                Repeat(70,
                    () => Dust.NewDust(player.position, player.width, player.height, dustType, player.velocity.X * 0.5f,
                        player.velocity.Y * 0.5f, 150, Color.Purple, 1.5f));

                player.grappling[0] = -1;
                player.grapCount = 0;
                foreach (var projectile in Main.projectile)
                {
                    if (projectile.active && projectile.owner == player.whoAmI && projectile.aiStyle == 7)
                        projectile.Kill();
                }

                var modPlayer = player.GetModPlayer<RemorsePlayer>();
                if (!modPlayer.RemorsePosition.Equals(Vector2.Zero))
                {
                    player.TeleportPlayer(modPlayer.RemorsePosition, teleportStyle: -1 /* ensures we don't use a predefined style */);
                }
            }
            else if (player.itemTime == totalUseTime / 2 - 1)
            {
                Repeat(70,
                    () => Dust.NewDust(player.position, player.width, player.height, dustType, Alpha: 150,
                        newColor: Color.Black, Scale: 1.5f));
            }
        }
    }
}