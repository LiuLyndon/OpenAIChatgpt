using System.Speech.Recognition;
using System.Speech.Synthesis;

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

        private void FormSpeech_Load(object sender, EventArgs e)
        {

        }

        private void BtnListen_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.TxtListen.Text))
            {
                SpeechSynthesizer ss = new SpeechSynthesizer();
                ss.Volume = 100;
                ss.Speak(this.TxtListen.Text);
            }
            else
            {
                MessageBox.Show("Please Write Someting First!");
            }
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
            Grammar word = new DictationGrammar();
            sr.LoadGrammar(word);
            try
            {
                TxtRead.Text = "Listening Now...";
                sr.SetInputToDefaultAudioDevice();
                RecognitionResult result = sr.Recognize();
                TxtRead.Clear();
                TxtRead.Text = result.Text;
            }
            catch (Exception ex)
            {
                TxtRead.Text = string.Empty;
                MessageBox.Show($"Mic Not Found:{ex}");
                throw;
            }
        }
    }
}