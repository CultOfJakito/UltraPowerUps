using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace UltraPowerUps.Patches {
	[HarmonyPatch(typeof(DualWield), nameof(DualWield.EndPowerUp))]
	static file class SetDualWieldActiveFalsePatch {
		static void Prefix() {
			TimedPowerUp.isDualWieldActive = false;
		}
	}
}
