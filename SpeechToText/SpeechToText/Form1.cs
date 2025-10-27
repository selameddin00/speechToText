using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.Extensions.Configuration;

namespace SpeechToText
{
    public partial class Form1 : Form
    {
        private SpeechRecognizer? speechRecognizer;
        private bool isRecording = false;
        private IConfiguration? configuration;
        
        // Azure Speech Services konfigürasyonu
        private string? speechKey;
        private string? speechRegion;
        private string speechLanguage = "tr-TR"; // Türkçe dil desteği

        public Form1()
        {
            InitializeComponent();
            LoadConfiguration();
            InitializeSpeechRecognizer();
        }

        private void LoadConfiguration()
        {
            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                configuration = builder.Build();
                
                speechKey = configuration["AzureSpeech:SubscriptionKey"];
                speechRegion = configuration["AzureSpeech:Region"];
                speechLanguage = configuration["AzureSpeech:Language"] ?? "tr-TR";
                
                if (string.IsNullOrEmpty(speechKey) || string.IsNullOrEmpty(speechRegion))
                {
                    MessageBox.Show("Azure Speech Services konfigürasyonu eksik!\n\n" +
                        "appsettings.json dosyasında SubscriptionKey ve Region değerlerini güncelleyin.\n\n" +
                        "Detaylı kurulum talimatları için README.md dosyasını okuyun.", 
                        "Konfigürasyon Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Konfigürasyon yükleme hatası: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeSpeechRecognizer()
        {
            try
            {
                if (string.IsNullOrEmpty(speechKey) || string.IsNullOrEmpty(speechRegion))
                {
                    lblDurum.Text = "Hata - Azure Speech Services konfigürasyonu eksik";
                    return;
                }

                var config = SpeechConfig.FromSubscription(speechKey, speechRegion);
                config.SpeechRecognitionLanguage = speechLanguage;
                
                // Mikrofon girişi için audio config
                var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
                
                speechRecognizer = new SpeechRecognizer(config, audioConfig);
                
                // Konuşma tanıma olayları
                speechRecognizer.Recognizing += OnRecognizing;
                speechRecognizer.Recognized += OnRecognized;
                speechRecognizer.Canceled += OnCanceled;
                speechRecognizer.SessionStarted += OnSessionStarted;
                speechRecognizer.SessionStopped += OnSessionStopped;
                
                lblDurum.Text = "Hazır - Azure Speech Services bağlandı";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Azure Speech Services bağlantı hatası: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblDurum.Text = "Hata - Azure Speech Services bağlanamadı";
            }
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            if (!isRecording && speechRecognizer != null)
            {
                try
                {
                    // Kayıt başlat
                    speechRecognizer.StartContinuousRecognitionAsync();
                    isRecording = true;
                    
                    btnKayit.Enabled = false;
                    btnDurdur.Enabled = true;
                    lblDurum.Text = "Kayıt yapılıyor...";
                    txtMetin.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Kayıt başlatma hatası: {ex.Message}", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDurdur_Click(object sender, EventArgs e)
        {
            if (isRecording && speechRecognizer != null)
            {
                try
                {
                    // Kayıt durdur
                    speechRecognizer.StopContinuousRecognitionAsync();
                    isRecording = false;
                    
                    btnKayit.Enabled = true;
                    btnDurdur.Enabled = false;
                    lblDurum.Text = "Kayıt durduruldu";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Kayıt durdurma hatası: {ex.Message}", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Konuşma tanıma olayları
        private void OnRecognizing(object? sender, SpeechRecognitionEventArgs e)
        {
            // Gerçek zamanlı tanıma - henüz kesin değil
            if (!string.IsNullOrEmpty(e.Result.Text))
            {
                this.Invoke(new Action(() =>
                {
                    lblDurum.Text = $"Tanınıyor: {e.Result.Text}";
                }));
            }
        }

        private void OnRecognized(object? sender, SpeechRecognitionEventArgs e)
        {
            // Kesin tanıma sonucu
            if (e.Result.Reason == ResultReason.RecognizedSpeech && !string.IsNullOrEmpty(e.Result.Text))
            {
                this.Invoke(new Action(() =>
                {
                    txtMetin.AppendText(e.Result.Text + " ");
                    lblDurum.Text = "Kayıt yapılıyor...";
                }));
            }
        }

        private void OnCanceled(object? sender, SpeechRecognitionCanceledEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                lblDurum.Text = $"Kayıt iptal edildi: {e.Reason}";
                if (e.Reason == CancellationReason.Error)
                {
                    lblDurum.Text += $" - Hata: {e.ErrorDetails}";
                }
            }));
        }

        private void OnSessionStarted(object? sender, SessionEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                lblDurum.Text = "Kayıt oturumu başladı";
            }));
        }

        private void OnSessionStopped(object? sender, SessionEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                lblDurum.Text = "Kayıt oturumu sonlandı";
            }));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Uygulama kapanırken kaynakları temizle
            if (speechRecognizer != null)
            {
                if (isRecording)
                {
                    speechRecognizer.StopContinuousRecognitionAsync();
                }
                speechRecognizer.Dispose();
            }
            base.OnFormClosing(e);
        }
    }
}
