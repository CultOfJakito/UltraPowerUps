﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace UltraPowerUps.Patches {
	[HarmonyPatch(typeof(DualWield), nameof(DualWield.Start))]
	static class SetDualWieldActiveTruePatch {
		static void Prefix() {
			TimedPowerUp.isDualWieldActive = true;
		}
	}
}
