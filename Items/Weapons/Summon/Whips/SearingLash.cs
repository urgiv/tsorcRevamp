using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace tsorcRevamp.Items.Weapons.Summon.Whips
{
	public class SearingLash : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;  //journey mode lmao
			Tooltip.SetDefault("Enemies struck by this whip will burn horribly" +
                "\nand increase minion damage by 66% of this whips base damage in +%" +
                "\nThis stacks on top of other whip tag dmg" +
                "\nYour minions will focus struck enemies");
		}

		public override void SetDefaults()
		{

			Item.height = 84;
			Item.width = 88;

			Item.DamageType = DamageClass.SummonMeleeSpeed;
			Item.damage = 30;
			Item.knockBack = 2;
			Item.rare = ItemRarityID.Orange;

			Item.shoot = ModContent.ProjectileType<Projectiles.Summon.Whips.SearingLashProjectile>();
			Item.shootSpeed = 4;

			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 30; // for some reason a lower use speed gives it increased range....
			Item.useAnimation = 30;
			Item.noMelee = true;
			Item.noUseGraphic = true;

		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HellstoneBar, 10);
			recipe.AddIngredient(ItemID.MeteoriteBar, 10);
			recipe.AddIngredient(Mod.Find<ModItem>("DarkSoul").Type, 5500);

			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();
		}
	}
}