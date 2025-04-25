namespace MiniConsoleAppManager.Core.Abstract
{
    public abstract class BaseApp
    {
        public BaseApp Run()
        {
            Initialize(); // Alt sınıf tanımlamaları
            //while (!CheckShutdown())
            //{
                
            //}
            ExecuteLogic(); // Alt sınıf özelleştirmesi.
            return this;
        }

        protected abstract void Initialize();
        protected abstract void ExecuteLogic();

        protected virtual bool CheckShutdown()
        {
            return Console.KeyAvailable && Console.ReadKey(intercept: true).Key == ConsoleKey.Enter;
        }
    }
}
