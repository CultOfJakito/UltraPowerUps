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
using static UltraPowerUps.PowerUpStruct;
using Console = GameConsole.Console;

namespace UltraPowerUps
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static Dictionary<string, PowerUp> powerUps;
        public static GameObject powerUpTemplate;
        private static AssetBundle commonBundle;
        private static string path;
        
        Sprite sprite;

        private void Awake()
        {
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            path = System.Reflection.Assembly.GetAssembly(typeof(Plugin)).Location;

            string workDir = Path.GetDirectoryName(path);

            Texture2D texture = new Texture2D(200, 200);
            texture.LoadImage(File.ReadAllBytes(workDir + "\\Sprites\\NoCooldown.png"));
            sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100f, 0, SpriteMeshType.Tight, Vector4.zero);
        }
        private void Start()
        {
            Harmony harmony = new Harmony("UltraPowerUps");
            if(sprite.texture != null)
            {
                print("texture no exist");
            }
            Color color = new Color(0.6f, 0.6f, 0.6f);
            RegisterPowerUp(typeof(NoCooldowns), sprite, "NoCooldowns", color);

            
            IEnumerable<AssetBundle> assetBundles = AssetBundle.GetAllLoadedAssetBundles();
            foreach(AssetBundle bundle in assetBundles)
            {
                if (bundle.name.Contains("common"))
                {
                    commonBundle = bundle;
                }
            }
            powerUpTemplate = commonBundle.LoadAsset<GameObject>("DualWieldPowerup.prefab");
        }
        public void RegisterPowerUp(Type power, Sprite sprite, string name, Color color)
        {

            PowerUp powerUp = new PowerUp(power, name, sprite, color);
            powerUps.Add(name, powerUp);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L)){
                PowerUp powerUp;
                
                if (powerUps.TryGetValue("NoCooldowns", out powerUp)) {
                    
                    //creates the power up gameobject
                    GameObject powerUpGO = Instantiate(powerUpTemplate);
                    Destroy(powerUpGO.GetComponent<DualWieldPickup>());

                    Renderer renderer = powerUpGO.GetComponent<Renderer>();
                    renderer.material.color = powerUp.color;

                    powerUpGO.AddComponent<PowerUpPickup>();
                    PowerUpPickup pickup = powerUpGO.GetComponent<PowerUpPickup>();
                    pickup.powerUp = powerUp;

                    SpriteRenderer renderer2 = powerUpGO.transform.GetComponentInChildren<SpriteRenderer>();
                    renderer2.sprite = powerUp.sprite;
                }
            }
        }
    }
}
