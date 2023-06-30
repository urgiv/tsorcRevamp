﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using tsorcRevamp.Utilities;

namespace tsorcRevamp.Buffs
{
    public class BuffStations : GlobalBuff
    {
        public override void Update(int type, Player player, ref int buffIndex)
        {
            if (type == BuffID.Sharpened)
            {
                player.GetArmorPenetration(DamageClass.Melee) -= 12f;
                player.GetModPlayer<tsorcRevampPlayer>().Sharpened = true;
            }

            if (type == BuffID.AmmoBox)
            {
                player.GetModPlayer<tsorcRevampPlayer>().AmmoBox = true;
            }
        }

        public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare)
        {
            if (type == BuffID.Sharpened)
            {
                tip = LangUtils.GetTextValue("Items.VanillaItems.SharpeningStation", tsorcRevampPlayer.SharpenedMeleeArmorPen);
            }

            if (type == BuffID.AmmoBox)
            {
                tip += "\n" + LangUtils.GetTextValue("Items.VanillaItems.AmmoBox");
            }
        }

    }
}
