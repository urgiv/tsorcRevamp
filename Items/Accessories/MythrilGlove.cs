﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tsorcRevamp.Items.Accessories
{
    [AutoloadEquip(EquipType.HandsOn)]
    public class MythrilGlove : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Casts and sustains Wall when wearer is critically wounded" +
                               "\nWall gives +50 defense" +
                               "\nDoes not stack with Fog, Barrier or Shield spells");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 34;
            item.accessory = true;
            item.rare = ItemRarityID.Cyan;
            item.value = 500000;
        }

        public override void UpdateEquip(Player player)
        {
            if ((player.statLife <= (player.statLifeMax * 0.30f)) && !(player.HasBuff(ModContent.BuffType<Buffs.Fog>()) || player.HasBuff(ModContent.BuffType<Buffs.Barrier>()) || player.HasBuff(ModContent.BuffType<Buffs.Shield>())))
            {
                player.AddBuff(ModContent.BuffType<Buffs.Wall>(), 1, false);
            }

            Vector2 value10 = Main.OffsetsPlayerOnhand[player.bodyFrame.Y / 56] * 2f;

            if (player.direction != 1)
            {
                value10.X = (float)player.bodyFrame.Width - value10.X;
            }

            if (player.gravDir != 1f)
            {
                value10.Y = (float)player.bodyFrame.Height - value10.Y;
            }

            value10 -= new Vector2(player.bodyFrame.Width - player.width, player.bodyFrame.Height - 42) / 2f;
            Vector2 position = player.RotatedRelativePoint(player.position + value10) - player.velocity;
            if (Main.rand.Next(90) == 0)
            {
                for (int num183 = 0; num183 < 4; num183++)
                {
                    Dust dust = Main.dust[Dust.NewDust(player.Center, 0, 0, 57, player.direction * 2, 0f, 150, default(Color), .4f)]; //gold dust
                    dust.position = position;
                    dust.velocity *= 0f;
                    dust.noGravity = true;
                    dust.fadeIn = 1f;
                    dust.velocity += player.velocity;

                    if (Main.rand.Next(2) == 0)
                    {
                        dust.position += Utils.RandomVector2(Main.rand, -4f, 4f);
                        dust.scale += Main.rand.NextFloat();

                        if (Main.rand.Next(2) == 0)
                        {
                            dust.customData = player;
                        }
                    }
                }
            }
            if (Main.rand.Next(90) == 0)
            {
                for (int num183 = 0; num183 < 4; num183++)
                {
                    Dust dust = Main.dust[Dust.NewDust(player.Center, 0, 0, 180, player.direction * 2, 0f, 150, default(Color), .4f)]; //blue dust
                    dust.position = position;
                    dust.velocity *= 0f;
                    dust.noGravity = true;
                    dust.fadeIn = 1f;
                    dust.velocity += player.velocity;

                    if (Main.rand.Next(2) == 0)
                    {
                        dust.position += Utils.RandomVector2(Main.rand, -4f, 4f);
                        dust.scale += Main.rand.NextFloat();

                        if (Main.rand.Next(2) == 0)
                        {
                            dust.customData = player;
                        }
                    }
                }
            }
            if (player.statLife <= (player.statLifeMax * 0.30f))
            {
                for (int num183 = 0; num183 < 2; num183++)
                {
                    Dust dust = Main.dust[Dust.NewDust(player.Center, 0, 0, 57, player.direction * 2, 0f, 150, default(Color), 1f)]; //gold dust when barrier active
                    dust.position = position;
                    dust.velocity *= 0f;
                    dust.noGravity = true;
                    dust.fadeIn = 1f;
                    dust.velocity += player.velocity;

                    if (Main.rand.Next(2) == 0)
                    {
                        dust.position += Utils.RandomVector2(Main.rand, -4f, 4f);
                        dust.scale += Main.rand.NextFloat();

                        if (Main.rand.Next(2) == 0)
                        {
                            dust.customData = player;
                        }
                    }
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitanGlove);
            recipe.AddIngredient(ItemID.MythrilBar, 10);
            recipe.AddIngredient(mod.GetItem("GuardianSoul"));
            recipe.AddIngredient(mod.GetItem("SoulOfAttraidies"));
            recipe.AddIngredient(mod.GetItem("DarkSoul"), 50000);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
