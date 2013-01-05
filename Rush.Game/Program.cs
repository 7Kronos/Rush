using System;

namespace Rush
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry Vector2 for the application.
        /// </summary>
        static void Main()
        {
            var factory = new MonoGame.Framework.GameFrameworkViewSource<Main>();
            Windows.ApplicationModel.Core.CoreApplication.Run(factory);
        }
    }
}
