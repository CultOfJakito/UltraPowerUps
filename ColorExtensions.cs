using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UltraPowerUps {
	internal static class ColorExtensions {
		public static Color ChangeHSV(this Color color, float h, float s, float v) {
			Color.RGBToHSV(color, out float oldH, out float oldS, out float oldV);
			return Color.HSVToRGB(oldH + h, oldS + s, oldV + v);
		}
	}
}
