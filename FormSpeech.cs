using Microsoft.CognitiveServices.Speech;
using System.Globalization;
using System.Runtime;
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
        private string TextResult { get; set; } = string.Empty;
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

            this.TxtSystem.Text = "You are a teacher who helps children understand if things are animals or not.  If the user tells you an animal, you say \"yes\".  If the user tells you something that is not an animal, you say \"no\".  You only ever respond with \"yes\" or \"no\".  You do not say anything else.";
        }

        // [C#] 使用 Delegate 於 WinForm 中傳遞與接收訊息
        // https://dotblogs.com.tw/joysdw12/2013/06/21/delegate-winfom
        /// <summary>
        /// The callback method must match the signature of the callback delegate.
        /// </summary>
        /// <param name="n"></param>
        private void ResultCallback(string Message)
        {
            this.TxtMP3.AppendText($"{Message} \r\n");
        }

        #region Listen
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
        #endregion

        #region Read
        private void BtnRead_Click(object sender, EventArgs e)
        {
#if fa
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
#endif
        }
        #endregion

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
                ResultCallback($"ReadMP3 Start");

                using (API_MicrosoftCognitiveServicesSpeech api = new API_MicrosoftCognitiveServicesSpeech())
                {
                    // reLib.bOnlyPage = ckbOnlyPage.Checked;
                    api.ReturnValueCallback += new API_MicrosoftCognitiveServicesSpeech.ReturnValueDelegate(this.ResultCallback);

                    await api.ContinuousRecognitionWithFileAsync(MP3File);

                    this.TxtAzure.Text = TextResult = api.AzureAIresult;
                }

                ResultCallback($"ReadMP3 End");

                BtnReadMP3.Enabled = false;
                BtnReadMP3.Enabled = true;
            }
            catch (Exception ex)
            {
                TxtMP3.Text = string.Empty;
                ResultCallback($"ReadMP3:{ex}");
                throw;
            }
        }

        private async void BtnOpenAI_Click(object sender, EventArgs e)
        {
            using (API_OpenAI api = new API_OpenAI())
            {
                api.ReturnValueCallback += new API_OpenAI.ReturnValueDelegate(this.ResultCallback);

                Console.WriteLine("ChatGPT");
                await api.ChatGPT();
            }
        }

        #region TryFunction
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
        #endregion

        #region SpeechSDK
        private async void BtnSpeechSDK_Click(object sender, EventArgs e)
        {
            using (API_MicrosoftCognitiveServicesSpeech api = new API_MicrosoftCognitiveServicesSpeech())
            {

                Console.WriteLine("Speaker Verification:");
                await api.SpeakerVerificationAsync();

                Console.WriteLine("\nSpeaker Identification:");
                await api.SpeakerIdentificationAsync();
                Console.WriteLine("Please press <Return> to exit.");
                Console.ReadLine();
            }
        }
        #endregion
    }
}