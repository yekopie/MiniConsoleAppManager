using MiniConsoleAppManager.Tools;


namespace MiniConsoleAppManager.Tools
{
    public static class Validator
    {
        public static StringValidationBuilder For(string value) => new(value);
        public static IntValidationBuilder For(int value) => new(value);
    }
}
