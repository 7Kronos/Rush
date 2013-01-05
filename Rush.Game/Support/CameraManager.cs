using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rush.Support
{
    public static class CameraManager
    {
        public static float ZoomFactor { get; set; }
        public static Vector2 Location { get; set; }

        static CameraManager ()
	    {
            Location = Vector2.Zero;
            ZoomFactor = 1;
	    }

        /// <summary>
        /// Calcule la localisation d'un Vector2 du jeu sur le viewport
        /// </summary>
        /// <param name="virtualVector2"></param>
        /// <returns></returns>
        public static Point GetPointInScreen(Vector2 virtualVector2)
        {
            return new Point((int)((virtualVector2.X * 10) + 500), (int)((virtualVector2.Y * 10) + 500));
        }
    }
}
