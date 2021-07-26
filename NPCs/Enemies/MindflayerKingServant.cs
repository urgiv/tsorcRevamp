using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;

namespace tsorcRevamp.NPCs.Enemies
{
	class MindflayerKingServant : ModNPC
	{
		public override void SetDefaults()
		{
			Main.npcFrameCount[npc.type] = 3;
			animationType = 29;
			npc.aiStyle = 8;
			npc.damage = 75;
			npc.defense = 15;
			npc.height = 44;
			npc.lifeMax = 400;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.lavaImmune = true;
			aiType = 32;
			npc.value = 800;
			npc.width = 28;
			npc.knockBackResist = 0.2f;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax / 2);
			npc.damage = (int)(npc.damage / 2);
		}

		#region Spawn
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (!spawnInfo.player.ZoneDungeon && !spawnInfo.player.ZoneJungle && !spawnInfo.player.ZoneMeteor && spawnInfo.player.position.Y < ((Main.rockLayer * 25.0)) && spawnInfo.player.position.Y > ((Main.worldSurface * 0.44999998807907104)))
			{
				if (spawnInfo.player.position.Y > ((Main.rockLayer * 15.0)) && spawnInfo.player.position.X < ((Main.rockLayer * 60.0)) && Main.rand.Next(2000) == 1) return 1;
				if (spawnInfo.player.position.Y > ((Main.rockLayer * 15.0)) && spawnInfo.player.position.X > ((Main.rockLayer * 145.0)) && Main.rand.Next(2000) == 1) return 1;
			}
			return 0;
		}
		#endregion

		#region Gore
		public override void NPCLoot()
		{
			Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), mod.GetGoreSlot("Gores/Piscodemon Gore 1"), 1f);
			Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), mod.GetGoreSlot("Gores/Piscodemon Gore 2"), 1f);
			Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), mod.GetGoreSlot("Gores/Piscodemon Gore 3"), 1f);
			Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), mod.GetGoreSlot("Gores/Piscodemon Gore 2"), 1f);
			Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), mod.GetGoreSlot("Gores/Piscodemon Gore 3"), 1f);

			Item.NewItem(npc.getRect(), ItemID.Heart, 1);
		}
		#endregion
	}
}