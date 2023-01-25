using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using static UltraPowerUps.PowerUpStruct;

namespace UltraPowerUps
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static Dictionary<string, PowerUp> powerUps;
        public static GameObject powerUpTemplate;

        private void Awake()
        {
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
        private void Start()
        {
            Harmony harmony = new Harmony("UltraPowerUps");
            harmony.PatchAll();
            RegisterPowerUp(typeof(NoCooldowns), , "NoCooldown", new Color(0.6f, 0.6f, 0.6f));


        }
        public void RegisterPowerUp(Type power, Texture2D sprite, string name, Color color)
        {
            PowerUp powerUp = new PowerUp(power, name, sprite, color);
            powerUps.Add(name, powerUp);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L)){

            }
        }
    }
}
