﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using GameConsole;
using HarmonyLib;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;
using Console = GameConsole.Console;
using Object = UnityEngine.Object;

namespace UltraPowerUps
{
    [BepInPlugin("rougekill_ultrapowerups", "UltraPowerUps", "1.1.0")]
    public class Plugin : BaseUnityPlugin
    {
        private static GameObject _holderObject;

        public static GameObject HolderObject {
            get {
                if(_holderObject == null) {
                    _holderObject = new GameObject("Powerup Holder");
                }
                return _holderObject;
            }
        }

        private static AssetBundle commonBundle;
        
        internal static Sprite defaultSprite;

        internal static ManualLogSource logger;

        private void Awake()
        {
            logger = Logger;
            Logger.LogInfo($"Plugin {Info.Metadata.GUID} is loaded!");
        }
        private void Start()
        {
            Harmony harmony = new Harmony("UltraPowerUps");
            harmony.PatchAll();

            PowerUpPickupBuilder.DualWieldPrefab = Addressables.LoadAssetAsync<GameObject>("Assets/Prefabs/Levels/DualWieldPowerup.prefab").WaitForCompletion();
        }
      
        
    }
}
