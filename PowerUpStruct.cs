using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UltraPowerUps
{
    public class PowerUpStruct
    {
        public struct PowerUp
        {
            public PowerUp(Type power, string identifier, Texture2D texture, Color colour)
            {
                powerUp = power;
                name = identifier;
                sprite = texture;
                color = colour;
            }
            public Type powerUp; 
            public Texture2D sprite;
            public string name;
            public Color color;
        }
    }
}
