﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tsorcRevamp.Items.BossItems {
    class DarkMirror : ModItem {

        public override void SetStaticDefaults() {
            Tooltip.SetDefault("You look into the mirror and see your reflection looking back at you... \n" +
                "As you continue to gaze into the mirror, the background behind \n" +
                "your reflection becomes murky, as if peering into a dark abyss... \n" +
                "Use the mirror at night to continue looking into the eyes of your reflection...  \n" +
                "Or throw it away and rid yourself of this dark relic...");
        }

        public override void SetDefaults() {
            item.rare = ItemRarityID.LightRed;
            item.width = 38;
            item.height = 34;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useAnimation = 5;
            item.useTime = 5;
            item.maxStack = 1;
            item.consumable = false;
        }


        public override bool UseItem(Player player) {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.SuperHardMode.DarkCloud>());
            Main.NewText("Your shadow self has manifested from your darkest fears...");
            return true;
        }
        public override bool CanUseItem(Player player) {
            bool canUse = true;
            if ((Main.dayTime) || (NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.SuperHardMode.DarkCloud>()))) {
                
                canUse = false;
            }
            return canUse;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicMirror, 1);
            recipe.AddIngredient(mod.GetItem("WhiteTitanite"), 10);
            recipe.AddIngredient(mod.GetItem("FlameOfTheAbyss"), 15);
            recipe.AddIngredient(mod.GetItem("SoulOfAttraidies"), 1);
            recipe.AddIngredient(mod.GetItem("DarkSoul"), 1000);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
