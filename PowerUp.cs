using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UltraPowerUps
{
    public abstract class PowerUp : MonoBehaviour
    {
        public abstract Sprite Sprite { get; }
        public abstract string Name { get; }
        public abstract Color Color { get; }
        public abstract float Duration { get; }

        public abstract void PowerUpStart();
        public abstract void PowerUpEnd();
        public abstract void OnUpdate();

        private bool timerStarted = false;
        private PowerUpMeter meter;

        private void Start()
        {
            //Initalises the powerup meter UI
            this.meter = MonoSingleton<PowerUpMeter>.Instance;
            this.meter.latestMaxJuice = this.Duration;
            this.meter.juice = this.Duration;
            this.meter.powerUpColor = new Color(0.6f, 0.6f, 0.6f);
            
            this.timerStarted = true;

            PowerUpStart();
        }

        private void Update()
        {
            if(timerStarted && meter.juice <= 0) {
                this.EndPowerUp();
            }

            OnUpdate();
        }

        private void EndPowerUp()
        {
            Destroy(base.gameObject);
            PowerUpEnd();
        }
        
    }

}
