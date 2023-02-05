using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using GameConsole;
using HarmonyLib;
using UnityEngine;
using Console = GameConsole.Console;
using Object = UnityEngine.Object;

namespace UltraPowerUps
{
    [BepInPlugin("rougekill_ultrapowerups", "UltraPowerUps", "1.1.0")]
    public class Plugin : BaseUnityPlugin
    {
        

        public static Dictionary<string, PowerUp> powerUps = new Dictionary<string, PowerUp>();

        public static GameObject powerUpTemplate;
        private static AssetBundle commonBundle;
        
        public static Sprite sprite;

        private void Awake()
        {
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            AssetBundle bundle = AssetBundle.LoadFromMemory(Resources.Resource1.ultrapowers);
            Texture2D image = (Texture2D)bundle.LoadAsset("NoCooldown.png");

            
            sprite = Sprite.Create(image, new Rect(0, 0, image.height, image.height), new Vector2(0.5f, 0.5f), 100f, 0, SpriteMeshType.Tight, Vector4.zero);
        }
        private void Start()
        {
            Harmony harmony = new Harmony("UltraPowerUps");
            harmony.PatchAll();

            Color color = new Color(0.6f, 0.6f, 0.6f);
            RegisterPowerUp(NoCooldowns);
        }
        public static void RegisterPowerUp(PowerUp powerUp)
        {
            powerUps.Add(powerUp.Name, powerUp);
        }
        public static GameObject SpawnPowerUp(PowerUp power)
        {
            GameObject powerUpGO = Instantiate(powerUpTemplate);
            Destroy(powerUpGO.GetComponent<DualWieldPickup>());

            Renderer renderer = powerUpGO.GetComponent<Renderer>();
            renderer.material.color = power.Color;

            powerUpGO.AddComponent<PowerUpPickup>();
            PowerUpPickup pickup = powerUpGO.GetComponent<PowerUpPickup>();
            pickup.powerUp = power;

            SpriteRenderer renderer2 = powerUpGO.transform.GetComponentInChildren<SpriteRenderer>();
            renderer2.sprite = power.Sprite;

            Light light = powerUpGO.transform.GetComponentInChildren<Light>();
            light.color = power.Color;

            return powerUpGO;
        }
        private void Update()
        {
            if(commonBundle == null)
            {
                IEnumerable<AssetBundle> assetBundles = AssetBundle.GetAllLoadedAssetBundles();
                foreach (AssetBundle bundle in assetBundles)
                {
                    if (bundle.name.Contains("common"))
                    {
                        commonBundle = bundle;
                        powerUpTemplate = commonBundle.LoadAsset<GameObject>("DualWieldPowerup.prefab");
                    }
                }
            }
            if (commonBundle != null)
            {
                if (Input.GetKeyDown(KeyCode.L))
                {
                    PowerUp powerUp;

                    if (powerUps.TryGetValue("NoCooldowns", out powerUp)) 
                    {
                        SpawnPowerUp(powerUp);  
                    }
                }
            }
        }
    }
}
