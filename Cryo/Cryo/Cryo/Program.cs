namespace Cryo
{
#if WINDOWS || XBOX
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        public static void Main()
        {
            using (var game = new CryoGame())
            {
                game.Run();
            }
        }
    }
#endif
}