using Vosk;
using NAudio.Wave;

namespace SpeechToText
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vosk ile Konuşmadan Metne Uygulamasına Hoşgeldiniz!");
            // Türkçe model yolunu belirt (klasöre indirilmiş olmalı)
            string modelPath = "model";
            if (!Directory.Exists(modelPath))
            {
                Console.WriteLine("Vosk Türkçe model klasörü bulunamadı. Lütfen 'model' isimli dizini ekleyin ve dosyaları içine çıkarın.");
                return;
            }

            Vosk.Vosk.SetLogLevel(0); // Daha sessiz çıktı için
            Model model = new Model(modelPath);
            using (var recognizer = new VoskRecognizer(model, 16000.0f))
            using (var waveIn = new WaveInEvent())
            {
                waveIn.WaveFormat = new WaveFormat(16000, 1); // 16kHz mono
                waveIn.DataAvailable += (s, a) => { recognizer.AcceptWaveform(a.Buffer, a.BytesRecorded); };
                waveIn.StartRecording();
                Console.WriteLine("Kayıt başladı. Çıkmak için bir tuşa basın...");
                while (!Console.KeyAvailable)
                {
                    string result = recognizer.PartialResult();
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        Console.WriteLine(result);
                    }
                    Thread.Sleep(100);
                }
                waveIn.StopRecording();
                var finalResult = recognizer.FinalResult();
                Console.WriteLine("Sonuç: " + finalResult);
            }
        }
    }
}