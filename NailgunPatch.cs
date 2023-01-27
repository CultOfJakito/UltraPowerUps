using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace UltraPowerUps
{
    [HarmonyPatch(typeof(Nailgun), "SuperSaw")]
    public static class NailgunPatch
    {
        public static bool noCooldowns = false;
        private static void Prefix(Nailgun __instance)
        {
            if (noCooldowns) {
                
                //Spawns a oversaw without using up the heat on the sawgun
                CameraController cc = MonoSingleton<CameraController>.Instance;

                GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(__instance.heatedNail, cc.transform.position + cc.transform.forward, __instance.gameObject.transform.rotation);
                gameObject.transform.forward = cc.transform.forward;
                
                Rigidbody rigidbody;
                if (gameObject.TryGetComponent<Rigidbody>(out rigidbody))
                {
                    rigidbody.velocity = gameObject.transform.forward * 200f;
                }
                
                Nail nail;
                if (gameObject.TryGetComponent<Nail>(out nail)) {

                    nail.multiHitAmount = Mathf.RoundToInt(15 * 3f);
                    nail.ForceCheckSawbladeRicochet();
                }
                return;
            }
        }
    } 
}
