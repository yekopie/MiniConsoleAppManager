using MiniConsoleAppManager.Apps.Attributes;
using MiniConsoleAppManager.Core.Abstract;
using System.Reflection;

namespace MiniConsoleAppManager.Business
{
    public class AppManager
    {


        private static List<BaseApp?> appList = new();

        public AppManager()
        {
            CreateAppInstancesDynamically();
        }
        // !Çalışma zamanında işlem yapar !
        // derlenen dosyanın içerisindeki tipleri çekip, App sınıfının alt sınıfları olan sınıfları seçerek 
        // örneklerini oluşturur ve listeye atama yapar 
        public void CreateAppInstancesDynamically()
        {
            appList = Assembly.GetExecutingAssembly()
                   .GetTypes()
                   .Where(t => t.IsSubclassOf(typeof(BaseApp)))
                   .Select(t => (BaseApp?)Activator.CreateInstance(t))
                   .ToList();
        }

        public void ShowAppInfo(Type type)
        {
            Attribute[] attrs = Attribute.GetCustomAttributes(type);

            foreach (var attr in attrs)
            {
                if (attr is AppInfoAttribute info)
                {
                    Console.WriteLine($"Author Name : {info.AuthorName}");
                    Console.WriteLine($"Title : {info.GetTitle()}");
                    Console.WriteLine($"Description : {info.GetDescription()}");
                    Console.WriteLine($"Version : {info.GetVersion()}");
                }
            }

        }
        private void ShowAppList()
        {

            for (int i = 0; i < appList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {appList[i]}");
            }


        }
        public void ShowMenu()
        {
            
            while (true) // if list has any item
            {
                if (appList.Count == -1)
                {
                    Console.WriteLine("Tanımlı Uygulamanız bulunmamaktadır.");
                    break;
                }

                Console.Clear();
                DisplayAppList();

                int choice = PromptChoice();
                if (choice == 0) break;

                var selectedApp = GetSelectedApp(choice);
                if (selectedApp == null) continue;

                LaunchApp(selectedApp);
            }

            
        }

        private void DisplayAppList()
        {
            Console.WriteLine("Uygulama Listesi:\n");
            ShowAppList();
            Console.WriteLine("\nDetay görmek veya çalıştırmak istediğiniz uygulamanın numarasını girin (Çıkmak için 0):");
        }

        private int PromptChoice()
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int choice) && choice >= 0 && choice <= appList.Count)
                return choice;

            Console.WriteLine("Geçersiz seçim. Devam etmek için bir tuşa basın...");
            Console.ReadKey();
            return -1;
        }

        private BaseApp? GetSelectedApp(int choice)
        {
            if (choice > 0 && choice <= appList.Count)
                return appList.ElementAt(choice - 1);

            return null;
        }

        private void LaunchApp(BaseApp selectedApp)
        {
            Console.Clear();
            ShowAppInfo(selectedApp.GetType());

            Console.WriteLine("\n[Enter] ile çalıştır, [ESC] ile ana menüye dön.");
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                selectedApp.Run();
                Console.WriteLine("\nDevam etmek için bir tuşa basın...");
                Console.ReadKey();
            }
        }


    }
}
