using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniConsoleAppManager.Tools.Constants
{
    public static class Messages
    {
        // Genel Mesajlar
        public static string NotANumber = "Girilen değer sayısal bir ifade olmalıdır";

        public static string Required = "Bu alan boş bırakılamaz";

        public static string InvalidFormat = "Girilen değerin formatı geçersiz";

        public static string NotSupported = "Bu değer desteklenmiyor";

        public static string InvalidCharacter = "Geçersiz karakterler içeriyor";
        // String için olan mesajlar
        public static string OnlyLetters = "Sadece harflerden oluşmalı";

        public static string OnlyDigits = "Sadece rakamlardan oluşmalı";
        public static string MustContain(string text) => $"Metin '{text}' içermelidir";
        public static string CannotContain(string text) => $"Metin '{text}' içermemeli";
        public static string StartsWith(string start) => $"Metin '{start}' ile başlamalıdır";
        public static string EndsWith(string end) => $"Metin '{end}' ile bitmelidir";   
        public static string MinTextLength(int minLength) => $"Girilen metnin uzunluğu {minLength} karakterden daha az olamaz";
        public static string MaxTextLength(int maxLength) => $"Girilen metnin uzunluğu {maxLength} karakterden daha fazla olamaz";
        public static string BeetwenTextLength(int minLength, int maxLength) => $"Girilen metnin karakter uzunluğu {minLength} - {maxLength} arasında olmalı";
        // Tam sayılar için mesajlar
        public static string MinValue(int minValue) => $"Girilen tam sayı {minValue}'den küçük olamaz";
        public static string MaxValue(int maxValue) => $"Girilen tam sayı {maxValue}'den büyük olamaz";
        public static string BeetwenValue(int minValue, int maxValue) => $"Girilen tam sayı {minValue}'den küçük, {maxValue}'den büyük olamaz";

        public static string MustEqual<T>(T? value) => $"Birbirleriyle eşleşmiyor";

        public static string MustBeEven = "Girilen sayı çift olmalıdır";

        public static string MustBeOdd = "Girilen sayı tek olmalıdır";

        public static string MustBePositive = "Girilen sayı pozitif olmalıdır";

        public static string MustBeNegative = "Girilen sayı negatif olmalıdır";

        public static string CannotBeZero = "Sıfır değeri geçerli değil";


    }
}
