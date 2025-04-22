using MiniAppManager.Apps.Abstract;

namespace MiniAppManager.Apps.Algorithms
{
    [AppInfo("HelloWorld", "Ekrana 'Merhaba Dünya' yazar")]
    public class HelloWorld : App
    {
        public override void Init()
        {
            Console.WriteLine("Merhaba Dünya");
        }

        public override void Run()
        {
            Init();
        }
    }
}
