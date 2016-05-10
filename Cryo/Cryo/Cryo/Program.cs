namespace Cryo
{
#if WINDOWS || XBOX
    internal static class Program
    {
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