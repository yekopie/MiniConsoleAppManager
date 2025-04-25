using MiniConsoleAppManager.Tools.Abstract;
using MiniConsoleAppManager.Tools.Constants;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniConsoleAppManager.Tools
{
    public static class InputTool
    {
        public static T ValidatedInput<T, TBuilder>(string prompt,
            Func<T, BaseValidationBuilder<TBuilder, T>> validator,
            Func<string, T> Converter)
        {

            Console.Write(prompt);
            string input = Console.ReadLine();
            try
            {
                T value = Converter(input);
                validator(value);
                return value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(Messages.NotSupported, ex.ToString());
                return default;
            }


        }
    }
}
