using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UltraPowerUps
{
    public class NoCooldowns : PowerUp
    {
        public override string Name => "NoCooldowns";
        public override Color Color => new Color(0.6f, 0.6f, 0.6f);
        public override float Duration => 30f;
        public override Sprite Sprite => Plugin.sprite;

        private WeaponCharges wc;

        public override void PowerUpStart()
        {
            this.wc = MonoSingleton<WeaponCharges>.Instance;
        }

        public override void OnUpdate()
        {
            wc.rev1charge = 400f;
        }

        public override void PowerUpEnd()
        {
            GameConsole.Console.print("power up ended");
        }
    }
}
