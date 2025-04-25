# Mini Console App Manager

Yeni başlayan geliştiriciler için yapılmış, C# ile yazılmış sade ve genişletilebilir bir **mini uygulama yöneticisidir**.  
Amaç; farklı konsol uygulamalarını tek bir yerden çalıştırmak, test etmek ve yönetmek.

---

## 🚀 Özellikler

- 🔍 Uygulama listesinden seçim yaparak çalıştırma
- 📦 Otomatik `App` tanıma ve kayıt etme sistemi
- 🎛️ Özelleştirilebilir input sistemi
- ✅ Fluent-style validation desteği
- 📄 Geliştirici dostu konsol menüsü

---
### 🧠 Mimari Avantajlar

- Yeni uygulamalar kolayca `BaseApp` sınıfıyla eklenebilir.
- Uygulamalar otomatik olarak menüde görünür.
- Tek bir yapı üzerinden tüm uygulamaları yönetebilirsin.
- Yeni geliştirici dostutur ve genişletilebilir bir altyapı sağlar.
---

## ⚙️ Kullanım

Proje çalıştırıldığında, terminaldeki menüden kayıtlı uygulamaları görebilir ve istediğini başlatabilirsin.

---

## ➕ Yeni Uygulama Ekleme

Yeni bir mini uygulama yazmak için sadece şu adımları izle:

1. `BaseApp` abstract sınıfını implement eden bir sınıf oluştur.
2. `AppManager` seni otomatik olarak listeye ekler!

```csharp
public class HelloWorld : BaseApp
{

    protected override void ExecuteLogic()
    {
        // Uygulama içinde yapılacak ana işlemler buraya yazılır
    }

    protected override void Initialize()
    {
        // Başlangıçta çalışan işlemler - Örnek / Tanımlamlar / Bilgilendirme vs.
        Console.WriteLine("Hello world");
    }
}
