using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UltraPowerUps
{
    public class NoCooldowns : TimedPowerUp
    {

        private WeaponCharges wc;

        protected override void Start()
        {
            base.Start();

            this.wc = MonoSingleton<WeaponCharges>.Instance;
        }

        protected override void Update()
        {
            base.Update();

            wc.MaxCharges();
        }

        private void OnDestroy() {
            Plugin.logger.LogInfo("Powerup Ended");
        }
    }
}
