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
        public static Point Location { get; set; }

        static CameraManager ()
	    {
            Location = Point.Zero;
            ZoomFactor = 1;
	    }

        /// <summary>
        /// Calcule la localisation d'un point du jeu sur le viewport
        /// </summary>
        /// <param name="virtualPoint"></param>
        /// <returns></returns>
        public static Point GetPointInScreen(Point virtualPoint)
        {
            return new Point((virtualPoint.X * 10) + 500, (virtualPoint.Y * 10) + 500);
        }
    }
}
