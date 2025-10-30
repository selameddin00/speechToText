# Speech to Text Uygulaması (Vosk, .NET 8 Konsol)

Bu uygulama, Vosk açık kaynak konuşma tanıma kütüphanesini kullanarak mikrofon girişinden Türkçe konuşmayı çevrimdışı (offline) metne dönüştürür. Uygulama bir konsol uygulamasıdır.

## 👨‍💻 Geliştirici Bilgileri

- **İsim-Soyisim**: SELAMEDDIN TIRIT
- **Öğrenci No**: 240541035
- **Fakülte/Bölüm/Şube**: TEKNOLOJI FAKULTESI - YAZILIM MUHENDISLIGI - A

## 🚀 Özellikler

- ✅ Türkçe (tr-TR) dil modeli desteği
- ✅ Gerçek zamanlı tanıma, anlık kısmi sonuçlar ve final sonuç
- ✅ Tamamen offline çalışma (internet gerekmez)
- ✅ Basit konsol arayüzü

## 📋 Gereksinimler

- .NET 8.0 SDK
- Windows 10/11
- Mikrofon erişimi

## 🔧 Kurulum

### 1) NuGet paketleri
Proje zaten aşağıdaki paketleri kullanır:

- `Vosk` (0.3.38)
- `NAudio` (2.2.1)

Paketler otomatik geri yüklenecektir.

### 2) Model indir ve konumlandır
- Vosk Türkçe küçük modeli indir: `https://alphacephei.com/vosk/models/vosk-model-small-tr-0.3.zip`
- Arşivi çıkar ve klasör adını `model` yap.
- Aşağıdaki dizine koy:
```
SpeechToText\SpeechToText\model
```
İçerikte `final.mdl`, `mfcc.conf`, `ivector` klasörü vb. dosyalar görünmelidir.

## ▶️ Calistirma

Komut satirindan:
```
cd SpeechToText\SpeechToText
dotnet run
```
Konsolda "Kayit basladi. Cikmak icin bir tusa basin..." mesajini gördükten sonra konusun. Kismen taninan metinler akarken, bir tusa bastiginizda kayit durur ve final sonuc yazdirilir.

Visual Studio ile:
1. `SpeechToText.sln` ac.
2. Baslangic projesi `SpeechToText` olsun.
3. F5 ile calistir.

## ❗ Sorun Giderme

- "Vosk Turkce model klasoru bulunamadi" hatasi alirsan:
  - `SpeechToText\SpeechToText\model` dizini mevcut mu?
  - Klasor adi tam olarak `model` mi?
  - Icerikte `final.mdl` ve `mfcc.conf` var mi?

- NuGet paketi bulunamiyor (NU1102):
  - `Vosk` sürümü `0.3.38` olmali. Paketleri geri yükle: `dotnet restore`.

## 📚 Teknik Detaylar

- Framework: .NET 8.0
- Platform: Konsol (C#)
- Ses Girisi: NAudio ile 16kHz mono
- Tanima: VoskRecognizer (Turkce model)

## 📄 Lisans

Bu proje MIT lisansi altindadir.

