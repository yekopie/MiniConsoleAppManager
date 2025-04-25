using MiniConsoleAppManager.Apps.Attributes;
using MiniConsoleAppManager.Core.Abstract;

namespace MiniAppManager.Apps.Algorithms
{
    [AppInfo("HelloWorld", "Ekrana 'Merhaba Dünya' yazar")]
    public class HelloWorld : BaseApp
    {

        protected override void ExecuteLogic()
        {
            
        }

        protected override void Initialize()
        {
            Console.WriteLine("Hello world");
        }
    }
}
