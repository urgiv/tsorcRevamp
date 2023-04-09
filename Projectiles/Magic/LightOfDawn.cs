﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Graphics;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using tsorcRevamp.Projectiles.VFX;

namespace tsorcRevamp.Projectiles.Magic
{
    class LightOfDawn : DynamicTrail
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Light of Dawn");
        }
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.scale = 1.1f;
            Projectile.timeLeft = 600;
            Projectile.hostile = true;
            Projectile.tileCollide = false;
            Projectile.friendly = false;


            trailWidth = 35;
            trailPointLimit = 900;
            trailCollision = true;
            NPCSource = false;
            collisionFrequency = 5;
            trailYOffset = 50;
            trailMaxLength = 700;
            customEffect = ModContent.Request<Effect>("tsorcRevamp/Effects/HomingStarShader", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;
        }

        bool playedSound = false;
        float homingAcceleration = 0;

        float transitionTimer;
        bool forcePink = false;
        bool forceBlue = false;
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();
            if (!playedSound)
            {
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item43 with { Volume = 0.5f }, Projectile.Center);
                playedSound = true;
            }

            base.AI();

            //Stop homing after a few seconds
            if (hasHitNPC)
            {
                int? target = UsefulFunctions.GetClosestEnemyNPC(Projectile.Center);
                if (target.HasValue && Main.npc[target.Value].Distance(Projectile.Center) < 300)
                {
                    //Perform homing
                    UsefulFunctions.SmoothHoming(Projectile, Main.npc[target.Value].Center, homingAcceleration, 20, Main.npc[target.Value].velocity, false);
                }
            }
        }

        bool hasHitNPC = false;
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            hasHitNPC = true;
            base.OnHitNPC(target, damage, knockback, crit);
        }

        public override float CollisionWidthFunction(float progress)
        {
            if (progress >= 0.85)
            {
                float scale = (1f - progress) / 0.15f;
                return (float)Math.Pow(scale, 0.1) * (float)trailWidth * 0.5f;
            }
            else
            {
                return (float)Math.Pow(progress, 0.6f) * trailWidth * 0.5f;
            }
        }

        public override void SetEffectParameters(Effect effect)
        {
            float trueFadeOut = fadeOut;
            trueFadeOut += trueFadeOut * ((float)Main.timeForVisualEffects / 120f);

            Color shaderColor = Color.Lerp(new Color(0.1f, 0.5f, 1f), new Color(1f, 0.3f, 0.85f), (float)Main.timeForVisualEffects / 120f);
            float intensity = 0.07f + 0.03f * ((float)Main.timeForVisualEffects / 120f);
            Color rgbColor = UsefulFunctions.ShiftColor(shaderColor, (float)Main.timeForVisualEffects, intensity);

            collisionEndPadding = (int)trailCurrentLength / 30;
            visualizeTrail = false;

            //Shifts its color slightly over time

            effect.Parameters["noiseTexture"].SetValue(tsorcRevamp.tNoiseTexture1);
            effect.Parameters["fadeOut"].SetValue(trueFadeOut);
            effect.Parameters["time"].SetValue((float)Main.timeForVisualEffects / 100f);
            effect.Parameters["shaderColor"].SetValue(rgbColor.ToVector4());
            effect.Parameters["WorldViewProjection"].SetValue(GetWorldViewProjectionMatrix());
        }
    }
}
