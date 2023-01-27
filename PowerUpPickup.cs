﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UltraPowerUps.PowerUpStruct;

namespace UltraPowerUps
{
    public class PowerUpPickup:MonoBehaviour
    {
        public PowerUp powerUp;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                this.PickedUp();
            }
        }

        private void PickedUp()
        {
            MonoSingleton<CameraController>.Instance.CameraShake(0.35f);

            if (MonoSingleton<PlayerTracker>.Instance.playerType == PlayerType.Platformer)
            {
                MonoSingleton<PlatformerMovement>.Instance.AddExtraHit(3);
                return;
            }

            GameObject gameObject = new GameObject();
            Type power = this.powerUp.powerUp;
            gameObject.AddComponent(power);
        }
    }
}