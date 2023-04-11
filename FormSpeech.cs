using Microsoft.CognitiveServices.Speech;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using static Google.Cloud.Speech.V1.LanguageCodes;
using RecognitionResult = System.Speech.Recognition.RecognitionResult;
using SpeechSynthesizer = System.Speech.Synthesis.SpeechSynthesizer;

namespace OpenAIChatgpt
{
    /// <summary>
    /// https://www.youtube.com/watch?v=UOwqdKMQ1sI
    /// </summary>
    public partial class FormSpeech : Form
    {
        public FormSpeech()
        {
            InitializeComponent();
        }

        private string MP3File = string.Empty;

        private void FormSpeech_Load(object sender, EventArgs e)
        {
            this.BtnOpenMP3.Enabled = true;
            this.LblMP3File.Text = string.Empty;

            this.BtnReadMP3.Enabled = false;
        }

        private async void BtnListen_Click(object sender, EventArgs e)
        {
            //using (API_MicrosoftCognitiveServicesSpeech api = new API_MicrosoftCognitiveServicesSpeech())
            //{
            //    await api.RecognizeSpeechAsync();
            //    Console.WriteLine("Please press <Return> to continue.");
            //    Console.ReadLine();
            //}

            //using (API_MicrosoftSystemSpeech apiMSS = new API_MicrosoftSystemSpeech())
            //{
            //    apiMSS.Speak(this.TxtListen.Text);
            //}
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            TxtRead.Text = "Listening Now...";

            try
            {
                // Create an in-process speech recognizer for the en-US locale.  
                using (SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine()) // new System.Globalization.CultureInfo("en-US")
                {
                    TxtRead.Text = "Listening Now...";

                    // Create and load a dictation grammar.  
                    recognizer.LoadGrammar(new DictationGrammar());
                    recognizer.SetInputToDefaultAudioDevice();
                    RecognitionResult result = recognizer.Recognize();
                    TxtRead.Clear();
                    TxtRead.Text = result.Text;
                }
            }
            catch (Exception ex)
            {
                TxtRead.Text = string.Empty;
                MessageBox.Show($"Mic Not Found:{ex}");
                throw;
            }
        }

        private void BtnOpenMP3_Click(object sender, EventArgs e)
        {
            BtnReadMP3.Enabled = false;
            MP3File = string.Empty;

            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Video (.wav)|*.wav|Video (.wmv)|*.wmv|Music (.mp3)|*.mp3|ALL Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.ShowDialog(); //Open File dialog box
                MP3File = openFileDialog1.FileName; //userFile = file user chose
                LblMP3File.Text = MP3File;
                // axWindowsMediaPlayer1.URL = userFile; //WMP plays file user chose
                BtnReadMP3.Enabled = true;
            }
            catch (Exception ex)
            {
                TxtMP3.Text = string.Empty;
                MessageBox.Show($"MP3 File Not Found:{ex}");
                throw;
            }
        }

        private async void BtnReadMP3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LblMP3File.Text))
            {
                BtnOpenMP3.Enabled = false;
                return;
            }

            try
            {
                Console.WriteLine($"ContinuousRecognitionWithFileAsync");

                using (API_MicrosoftCognitiveServicesSpeech api = new API_MicrosoftCognitiveServicesSpeech())
                {
                    await api.ContinuousRecognitionWithFileAsync(MP3File);
                    Console.WriteLine("Please press <Return> to continue.");
                    Console.ReadLine();
                }
#if fa
                // Create an in-process speech recognizer for the en-US locale.  
                using (SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine()) // new System.Globalization.CultureInfo("en-US")
                {
                    // Create and load a dictation grammar.  
                    recognizer.LoadGrammar(new DictationGrammar());

                    // Add a handler for the speech recognized event.  
                    //recognizer.SpeechRecognized +=new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

                    // Configure input to the speech recognizer.  
                    //recognizer.SetInputToDefaultAudioDevice();

                    // Start asynchronous, continuous speech recognition.  
                    //recognizer.RecognizeAsync(RecognizeMode.Multiple);

                    recognizer.SetInputToWaveFile(LblMP3File.Text);
                    recognizer.BabbleTimeout = new TimeSpan(Int32.MaxValue);
                    recognizer.InitialSilenceTimeout = new TimeSpan(Int32.MaxValue);
                    recognizer.EndSilenceTimeout = new TimeSpan(100000000);
                    recognizer.EndSilenceTimeoutAmbiguous = new TimeSpan(100000000);

                    // Keep the console window open.  
                    StringBuilder sb = new StringBuilder();
                    while (true)
                    {
                        try
                        {
                            var recText = recognizer.Recognize();
                            if (recText == null)
                            {
                                break;
                            }

                            sb.Append(recText.Text);
                        }
                        catch (Exception ex)
                        {
                            //handle exception      
                            //...

                            break;
                        }
                    }
                    TxtMP3.Text = recognizer.ToString();

                }
#endif
                BtnReadMP3.Enabled = false;
                BtnReadMP3.Enabled = true;
            }
            catch (Exception ex)
            {
                TxtMP3.Text = string.Empty;
                MessageBox.Show($"Mic Not Found:{ex}");
                throw;
            }
        }

        private async void BtnTryFunction_Click(object sender, EventArgs e)
        {
            // replace with your own subscription key 
            string subscriptionKey = "44b7e293382a4f78994aa1fff5be091f";
            // replace with your own subscription region 
            string region = "eastus";
            var config = SpeechConfig.FromSubscription(subscriptionKey, region);

            // persist profileMapping if you want to store a record of who the profile is
            var profileMapping = new Dictionary<string, string>();


            // mmmEnglish, Lucy
            string userName1 = "mmmEnglish";
            string userName2 = "Lucy";

            string fileName = @"C:\Users\lyndon_liu\Downloads\Australian_vs_British_SLANG__English_Vocabulary_and_phrases_with_Lucy.wav";

            var profileNames = new List<string>() 
            { 
                userName1,
                userName2
            };

            var fileNames = new Dictionary<string, string>()
            {
                { userName1, @"C:\Users\lyndon_liu\Downloads\mmmEnglish_Make_An_Appointment_Practise_Speaking_on_the_Phone.wav" },
                { userName2, @"C:\Users\lyndon_liu\Downloads\Lucy_20_Common_English_Speaking_Mistakes_-_Do_YOU_make_these__Free_PDF__Quiz.wav" },
            };

            using (API_MicrosoftCognitiveServicesSpeech api = new API_MicrosoftCognitiveServicesSpeech())
            {
                var enrolledProfiles = await api.WavIdentificationEnroll(config, profileNames, fileNames, profileMapping);

                await api.WavSpeakerIdentification(config, fileName, enrolledProfiles, profileMapping);

                foreach (var profile in enrolledProfiles)
                {
                    profile.Dispose();
                }
                Console.ReadLine();
            }
        }
    }
}