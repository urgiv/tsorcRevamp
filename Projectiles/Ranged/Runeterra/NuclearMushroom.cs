using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using tsorcRevamp.Buffs.Runeterra.Ranged;

namespace tsorcRevamp.Projectiles.Ranged.Runeterra
{
	public class NuclearMushroom: ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nuclear Mushroom");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5; // The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0; // The recording mode
		}

		public override void SetDefaults()
		{
			Projectile.width = 50;
			Projectile.height = 50;

			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 100 * 60;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 3;
            Projectile.knockBack = 10f;

		}

        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];
            Projectile.CritChance = owner.GetWeaponCrit(owner.HeldItem);
            Dust.NewDust(Projectile.TopLeft, 20, 20, DustID.GlowingMushroom, 0, 0, 250, Color.Brown, 0.25f);

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			Projectile.NewProjectile(Projectile.GetSource_None(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<NuclearMushroomExplosion>(), Projectile.damage * 10, Projectile.knockBack * 10f);
        }
    }
}