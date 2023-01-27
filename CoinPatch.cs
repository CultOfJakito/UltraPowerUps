using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameConsole;
using HarmonyLib;
using UnityEngine;
using Console = GameConsole.Console;

namespace UltraPowerUps
{
    [HarmonyPatch(typeof(Revolver), "ThrowCoin")]
    public static class CoinPatch
    {
        public static bool noCooldowns = false;
        public static void Postfix(Revolver __instance)
        {
            if (noCooldowns){
                WeaponCharges wc = MonoSingleton<WeaponCharges>.Instance;
                wc.rev1charge = 400f;
            }
        }
    } 
}
