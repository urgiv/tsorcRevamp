﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tsorcRevamp.Items.Weapons.Ranged {
    class SagittariusBow : ModItem {
        bool LegacyMode = ModContent.GetInstance<tsorcRevampConfig>().LegacyMode;
        public override void SetDefaults() {
            if (LegacyMode) {
                item.autoReuse = true;
                item.damage = 500;
                item.height = 28;
                item.knockBack = 12;
                item.noMelee = true;
                item.ranged = true;
                item.rare = ItemRarityID.LightPurple;
                item.shootSpeed = 16;
                item.useAnimation = 60;
                item.useTime = 60;
                item.UseSound = SoundID.Item5;
                item.shoot = ProjectileID.WoodenArrowFriendly;
                item.useStyle = ItemUseStyleID.HoldingOut;
                item.value = 19000000;
                item.width = 14;
                item.useAmmo = AmmoID.Arrow; 
            }

            //revamp sagittarius
            else {
                item.ranged = true;
                item.shoot = ModContent.ProjectileType<Projectiles.SagittariusBowHeld>();
                item.channel = true;

                item.damage = 415;
                item.width = 14;
                item.height = 28;
                item.useTime = 60;
                item.useAnimation = 60;
                item.useStyle = ItemUseStyleID.HoldingOut;
                item.noMelee = true;
                item.noUseGraphic = true;
                item.knockBack = 5f;
                item.value = Item.sellPrice(platinum: 4);
                item.rare = ItemRarityID.LightPurple;
                item.UseSound = SoundID.Item7;

                item.shootSpeed = 20f;
            }
        }

        public override bool CanUseItem(Player player) {
            if (LegacyMode) {
                return base.CanUseItem(player);
            }
            else return player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.SagittariusBowHeld>()] <= 0;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("ArtemisBow"), 1);
            recipe.AddIngredient(mod.GetItem("CursedSoul"), 70);
            recipe.AddIngredient(mod.GetItem("BlueTitanite"), 25);
            recipe.AddIngredient(mod.GetItem("FlameOfTheAbyss"), 40);
            recipe.AddIngredient(mod.GetItem("DarkSoul"), 250000);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
