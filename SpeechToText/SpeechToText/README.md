# Speech to Text Uygulaması

Bu uygulama Azure Speech Services kullanarak konuşmayı metne dönüştüren bir Windows Forms uygulamasıdır.

## 👨‍💻 Geliştirici Bilgileri

- **İsim-Soyisim**: SELAMEDDİN TİRİT
- **Öğrenci No**: 240541035
- **Fakülte/Bölüm/Şube**: TEKNOLOJİ FAKÜLTESİ - YAZILIM MÜHENDİSLİĞİ - A

## 🚀 Özellikler

- ✅ **Türkçe dil desteği** (tr-TR)
- ✅ **Gerçek zamanlı konuşma tanıma**
- ✅ **Maksimum 5 saniye gecikme** ile metin güncelleme
- ✅ **Azure Speech Services entegrasyonu**
- ✅ **Modern Windows Forms arayüzü**
- ✅ **Mikrofon izinleri otomatik yönetimi**

## 📋 Gereksinimler

- **.NET 8.0** veya üzeri
- **Windows 10/11** işletim sistemi
- **Azure hesabı** (ücretsiz katman mevcut)
- **Mikrofon** erişimi
- **İnternet bağlantısı**

## 🔧 Kurulum

### 1. Azure Speech Services Kurulumu

#### Adım 1: Azure Portal'a Giriş
1. [Azure Portal](https://portal.azure.com)'a gidin
2. Microsoft hesabınızla giriş yapın (ücretsiz hesap oluşturabilirsiniz)

#### Adım 2: Speech Services Kaynağı Oluşturma
1. Sol menüden **"Create a resource"** (Kaynak oluştur) tıklayın
2. Arama çubuğuna **"Speech Services"** yazın ve Enter'a basın
3. **"Speech Services"** kartını seçin
4. **"Create"** (Oluştur) butonuna tıklayın

#### Adım 3: Kaynak Ayarları
**Temel Bilgiler:**
- **Subscription**: Mevcut aboneliğinizi seçin
- **Resource Group**: Yeni grup oluşturun (örn: "speech-to-text-rg")
- **Region**: Size yakın bölge seçin (örn: "West Europe", "East US")
- **Name**: Benzersiz isim verin (örn: "speech-to-text-app")
- **Pricing tier**: **"Free (F0)"** seçin (aylık 5 saat ücretsiz)

**Önemli:** Kaynak adında sadece harf, rakam ve tire (-) kullanın. Boşluk veya özel karakter kullanmayın.

#### Adım 4: Kaynak Oluşturma
1. **"Review + create"** tıklayın
2. **"Create"** tıklayın
3. Kaynak oluşturulmasını bekleyin (1-2 dakika)

#### Adım 5: Keys ve Endpoint Bilgilerini Alma
1. **"Go to resource"** tıklayın
2. Sol menüden **"Keys and Endpoint"** seçin
3. **Key 1** değerini kopyalayın
4. **Region** bilgisini not edin (örn: "westeurope", "eastus")

### 2. Uygulama Konfigürasyonu

#### Adım 1: Konfigürasyon Dosyasını Düzenleme
`appsettings.json` dosyasını açın ve aşağıdaki değerleri güncelleyin:

```json
{
  "AzureSpeech": {
    "SubscriptionKey": "BURAYA_KEY_YAZIN",
    "Region": "BURAYA_BOLGE_YAZIN",
    "Language": "tr-TR"
  }
}
```

**Örnek:**
```json
{
  "AzureSpeech": {
    "SubscriptionKey": "abc123def456ghi789jkl012mno345pqr678",
    "Region": "westeurope",
    "Language": "tr-TR"
  }
}
```

#### Adım 2: Visual Studio'da Çalıştırma
1. Visual Studio'da projeyi açın
2. **F5** tuşuna basarak uygulamayı çalıştırın
3. Konfigürasyon doğruysa "Hazır - Azure Speech Services bağlandı" mesajını göreceksiniz

## 🎯 Kullanım

### Temel Kullanım
1. **"Kayıt"** butonuna basın (yeşil buton)
2. Mikrofonunuza konuşmaya başlayın
3. Tanınan metin otomatik olarak metin alanına yazılacak
4. **"Durdur"** butonuna basarak kaydı sonlandırın (kırmızı buton)

### Arayüz Elemanları
- **Kayıt Butonu**: Konuşma kaydını başlatır
- **Durdur Butonu**: Kaydı sonlandırır
- **Metin Alanı**: Tanınan konuşma metnini gösterir
- **Durum Etiketi**: Mevcut durumu gösterir

## 💰 Fiyatlandırma

### Azure Speech Services Ücretsiz Katmanı
- **Aylık 5 saat** ücretsiz konuşma tanıma
- **Aylık 5 saat** ücretsiz metin-okuma
- Her ay otomatik yenilenir
- Kredi kartı bilgisi gerektirmez

### Ücretli Katmanlar
- **Standard (S0)**: Saatlik $1.00
- **Daha fazla bilgi**: [Azure Speech Services Fiyatlandırma](https://azure.microsoft.com/pricing/details/cognitive-services/speech-services/)

## 🔧 Sorun Giderme

### Konfigürasyon Hataları
**Problem**: "Azure Speech Services konfigürasyonu eksik" hatası
**Çözüm**: 
- `appsettings.json` dosyasında SubscriptionKey ve Region değerlerini kontrol edin
- Azure Portal'dan doğru Key ve Region bilgilerini aldığınızdan emin olun

### Mikrofon İzni Sorunları
**Problem**: Mikrofon çalışmıyor
**Çözüm**:
- Windows ayarlarından mikrofon iznini kontrol edin
- Uygulamaya mikrofon erişimi verildiğinden emin olun
- Mikrofonun başka uygulamalar tarafından kullanılmadığından emin olun

### Azure Bağlantı Sorunları
**Problem**: "Azure Speech Services bağlanamadı" hatası
**Çözüm**:
- İnternet bağlantınızı kontrol edin
- Azure Speech Services kaynağının aktif olduğunu kontrol edin
- Subscription Key'in doğru olduğunu kontrol edin
- Region bilgisinin doğru olduğunu kontrol edin

### Bölge Kısıtlamaları
**Problem**: "Resource was disallowed by Azure" hatası
**Çözüm**:
- Farklı bir bölge deneyin (örn: "East US", "West US 2")
- Azure aboneliğinizin bölge kısıtlamalarını kontrol edin

## 📚 Teknik Detaylar

- **Framework**: .NET 8.0
- **Platform**: Windows Forms
- **Speech SDK**: Microsoft.CognitiveServices.Speech v1.34.0
- **Dil**: Türkçe (tr-TR)
- **Mimari**: Azure Cloud Services

## 🤝 Katkıda Bulunma

1. Bu repository'yi fork edin
2. Feature branch oluşturun (`git checkout -b feature/AmazingFeature`)
3. Değişikliklerinizi commit edin (`git commit -m 'Add some AmazingFeature'`)
4. Branch'inizi push edin (`git push origin feature/AmazingFeature`)
5. Pull Request oluşturun

## 📄 Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için `LICENSE` dosyasına bakın.

## 📞 Destek

Sorunlarınız için:
1. README dosyasındaki sorun giderme bölümünü kontrol edin
2. GitHub Issues'da yeni bir issue oluşturun
3. Azure Speech Services dokümantasyonunu inceleyin

---

**Not**: Bu uygulama Azure Speech Services kullanır ve internet bağlantısı gerektirir. Offline çalışmaz.
