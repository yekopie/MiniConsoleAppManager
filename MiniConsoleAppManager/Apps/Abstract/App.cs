


namespace MiniAppManager.Apps.Abstract
{
    public abstract class App
    {
        public abstract void Init();

        public abstract void Run();

        public void Shutdown()
        {
            Console.ReadKey();
        }
    }
}
