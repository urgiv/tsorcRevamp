using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tsorcRevamp.NPCs.Bosses.SuperHardMode.HellkiteDragon
{
    class HellkiteDragonTail : ModNPC
    {
        public override void SetDefaults()
        {
            npc.netAlways = true;
            npc.npcSlots = 2;
            npc.width = 32;
            npc.height = 32;
            npc.aiStyle = 6;
            npc.knockBackResist = 0;
            npc.timeLeft = 1750;
            npc.damage = 100;
            npc.defense = 40;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath8;
            npc.lifeMax = 20000;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.value = 100000;
            npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
        }

        int fireDamage = 50;
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax / 2);
            npc.damage = (int)(npc.damage / 2);
            fireDamage = (int)(fireDamage / 2);
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellkite Dragon");
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
            int[] bodyTypes = new int[] { ModContent.NPCType<HellkiteDragonBody>(), ModContent.NPCType<HellkiteDragonLegs>(), ModContent.NPCType<HellkiteDragonBody>(), ModContent.NPCType<HellkiteDragonBody>(), ModContent.NPCType<HellkiteDragonBody>(), ModContent.NPCType<HellkiteDragonBody>(), ModContent.NPCType<HellkiteDragonLegs>(), ModContent.NPCType<HellkiteDragonBody>(), ModContent.NPCType<HellkiteDragonBody2>(), ModContent.NPCType<HellkiteDragonBody3>() };
            tsorcRevampGlobalNPC.AIWorm(npc, ModContent.NPCType<HellkiteDragonHead>(), bodyTypes, ModContent.NPCType<HellkiteDragonTail>(), 12, 6f, 9f, 0.25f, true, false);

            if (!Main.npc[(int)npc.ai[1]].active)
            {
                npc.life = 0;
                npc.HitEffect(0, 10.0);
                npc.NPCLoot();
                npc.active = false;
            }
        }

        public override void NPCLoot()
        {

            npc.netUpdate = true;
            Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
            if (npc.life <= 0)
            {
                Gore.NewGore(vector8, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), mod.GetGoreSlot("Gores/Hellkite Dragon Body Gore 2"), 1f);
            }
        }
    }
}