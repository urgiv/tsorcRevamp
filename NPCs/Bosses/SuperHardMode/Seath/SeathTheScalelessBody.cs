using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tsorcRevamp.NPCs.Bosses.SuperHardMode.Seath
{
    class SeathTheScalelessBody : ModNPC
    {
        public override void SetDefaults()
        {
            npc.netAlways = true;
            npc.npcSlots = 10;
            npc.width = 32;
            npc.height = 32;
            npc.aiStyle = 6;
            npc.knockBackResist = 0;
            npc.timeLeft = 22500;
            npc.damage = 100;
            npc.defense = 150;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath8;
            npc.lifeMax = 75000;
            music = 12;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.value = 200000;
            npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
        }


        int breathDamage = 33;
        int flameRainDamage = 27;
        int meteorDamage = 33;
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax / 2);
            npc.damage = (int)(npc.damage / 2);
            breathDamage = (int)(breathDamage / 2);
            flameRainDamage = (int)(flameRainDamage / 2);
            meteorDamage = (int)(meteorDamage / 2);
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seath the Scaleless");
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }
        public override void AI()
        {
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.behindTiles = true;
            int[] bodyTypes = new int[] { ModContent.NPCType<SeathTheScalelessBody>(), ModContent.NPCType<SeathTheScalelessBody>(), ModContent.NPCType<SeathTheScalelessLegs>(), ModContent.NPCType<SeathTheScalelessBody>(), ModContent.NPCType<SeathTheScalelessBody>(), ModContent.NPCType<SeathTheScalelessBody>(), ModContent.NPCType<SeathTheScalelessBody>(), ModContent.NPCType<SeathTheScalelessBody>(), ModContent.NPCType<SeathTheScalelessBody>(), ModContent.NPCType<SeathTheScalelessBody>(), ModContent.NPCType<SeathTheScalelessBody>(), ModContent.NPCType<SeathTheScalelessLegs>(), ModContent.NPCType<SeathTheScalelessBody>(), ModContent.NPCType<SeathTheScalelessBody2>(), ModContent.NPCType<SeathTheScalelessBody3>() };
            tsorcRevampGlobalNPC.AIWorm(npc, ModContent.NPCType<SeathTheScalelessHead>(), bodyTypes, ModContent.NPCType<SeathTheScalelessTail>(), 17, 6f, 10f, 0.17f, true, false);

            if (!Main.npc[(int)npc.ai[1]].active)
            {
                npc.life = 0;
                npc.HitEffect(0, 10.0);
                NPCLoot();
                npc.active = false;
            }
        }



        public override void NPCLoot()
        {
            //if (npc.life <= 0){
            Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
            int a = Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), mod.GetGoreSlot("Gores/Seath the Scaleless Body Gore"), 1f);
            Main.gore[a].timeLeft = 3600;
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Blood Splat"), 0.9f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Blood Splat"), 0.9f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Blood Splat"), 0.9f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Blood Splat"), 0.9f);
            //}
        }
    }
}