using MiniAppManager.Apps.Abstract;
using System.Reflection;

namespace MiniAppManager
{
    public class AppManager
    {


        private static List<App> appList;

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
                   .Where(t => t.IsSubclassOf(typeof(App)))
                   .Select(t => (App)Activator.CreateInstance(t))
                   .ToList();
        }

        public void ShowAppInfo(System.Type type)
        {
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(type);

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
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Uygulama Listesi:\n");

                ShowAppList();

                Console.WriteLine("\nDetay görmek veya çalıştırmak istediğiniz uygulamanın numarasını girin (Çıkmak için 0):");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice != 0 && choice <= appList.Count)
                {
                    var selectedApp = appList.ElementAt(choice - 1);
                    Console.WriteLine("Çalıştırmak için Enter'a basın, ana menüye dönmek için ESC.");
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        ShowAppInfo(selectedApp.GetType());
                        selectedApp.Run();
                        Console.ReadKey();
                    }
                }
                else if (choice == 0)
                {
                    break;
                }
            }
        }


    }
}
