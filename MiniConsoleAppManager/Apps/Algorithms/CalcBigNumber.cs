using MiniConsoleAppManager.Apps.Attributes;
using MiniConsoleAppManager.Core.Abstract;
using MiniConsoleAppManager.Tools;
using System.Text;

namespace MiniAppManager.Apps.Algorithms
{
    [AppInfo(
        "CalcBigNumber",
        "Büyük tam sayıları string olarak toplar")]
    public class CalcBigNumber : BaseApp
    {
        private static string LargeValueSum(string firstValue, string secondValue)
        {
            int maxLength = Math.Max(firstValue.Length, secondValue.Length);
            firstValue = firstValue.PadLeft(maxLength, '0');
            secondValue = secondValue.PadLeft(maxLength, '0');

            string result = "";
            int carry = 0; // eldeki değer
            for (int i = maxLength - 1; i >= 0; i--)
            {
                int firstDigit = firstValue[i] - '0'; // ASCII'DE '0' 48'dir ve çıkartılan rakam kendisini verir
                int secondDigit = (int)char.GetNumericValue(secondValue[i]); // 2 kullanımda doğrudur
                int sum = firstDigit + secondDigit + carry;
                result = sum % 10 + result;
                carry = sum / 10;

            }

            if (carry > 0)
            {
                result = carry + result;
            }

            return result;
        }

        protected override void Initialize()
        {
            // Örnek Gösterim
            string firstValue = "9916545465512322545465512322130202305465645465203202032030655554652";
            string secondValue = "99165456529916545652991654565299165456529916545652";
            string result = LargeValueSum(firstValue, secondValue);
            Console.Write(firstValue + " + " + secondValue);
            Console.WriteLine($"Result : {result}");
        }

        protected override void ExecuteLogic()
        {
            string firstValue = InputTool.ValidatedInput<string, StringValidationBuilder>(
                    "1. sayıyı giriniz : ",
                    input => new StringValidationBuilder(input)
                                .CannotBeNullOrWhiteSpace()
                                .MaxLength(100),
                    Convert.ToString);
            string secondValue = InputTool.ValidatedInput<string, StringValidationBuilder>(
                    "2. sayıyı giriniz : ",
                    input => new StringValidationBuilder(input)
                                .CannotBeNullOrWhiteSpace()
                                .MaxLength(100),
                    Convert.ToString);

            Console.WriteLine(LargeValueSum(firstValue, secondValue));
        }
    }
}