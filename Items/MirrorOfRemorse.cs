using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static BareEssentials.ActionHelper;

namespace BareEssentials.Items
{
    class MirrorOfRemorse : ModItem
    {
        public override void SetStaticDefaults() => 
            Tooltip.SetDefault("Oops, let's try that again");

        public override void SetDefaults()
        {
            item.useTurn = true;
            item.width = 20;
            item.height = 20;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useTime = 90;
            item.UseSound = SoundID.Item6;
            item.useAnimation = 90;
            item.rare = 4;
            item.value = Item.buyPrice(gold: 20);
        }

        public override bool CanUseItem(Player player) =>
            !player.GetModPlayer<BareEssentialsPlayer>().RemorsePosition.Equals(Vector2.Zero);

        public override void UseStyle(Player player)
        {
            const int dustType = 27;
            var totalUseTime = PlayerHooks.TotalUseTime(item.useTime, player, item);

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

                var modPlayer = player.GetModPlayer<BareEssentialsPlayer>();
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