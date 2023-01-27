using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UltraPowerUps
{
    public class NoCooldowns:MonoBehaviour
    {
        WeaponCharges wc;
        float durationSeconds;
        bool timerStarted = false;
        PowerUpMeter meter;

        private void Start()
        {

            this.wc = MonoSingleton<WeaponCharges>.Instance;
            this.durationSeconds = 30f;
            
            //Initalises the powerup meter UI
            this.meter = MonoSingleton<PowerUpMeter>.Instance;
            this.meter.latestMaxJuice = this.durationSeconds;
            this.meter.juice = this.durationSeconds;
            this.meter.powerUpColor = new Color(0.6f, 0.6f, 0.6f);
            
            this.timerStarted = true;

            //Activates infinite oversaws
            NailgunPatch.noCooldowns = true;
        }
        private void Update()
        {
            if(timerStarted && meter.juice <= 0) {
                this.EndPowerUp();
            }
        }
        private void EndPowerUp()
        {
            //Disables infinite oversaws
            NailgunPatch.noCooldowns = false;
            Destroy(base.gameObject);
        }
        
    }
}
