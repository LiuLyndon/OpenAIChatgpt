using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using RecognitionResult = System.Speech.Recognition.RecognitionResult;
using SpeechSynthesizer = System.Speech.Synthesis.SpeechSynthesizer;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace OpenAIChatgpt
{
    /// <summary>
    /// 
    /// https://www.zwlt.xyz/index.php/archives/87/
    /// </summary>
    public class API_MicrosoftSystemSpeech : IDisposable
    {
        private string Text { set; get; }
        private SpeechRecognitionEngine recognizer { set; get; }
        private DictationGrammar dictationGrammar { set; get; }
        public string[] GrammarText = new string[] { "你好天气真", "非涉密计算机", "很高兴见到你", "再见" };
        public string[] Choices = new string[] { "严禁处理涉密信息", "月亮" };
        Grammar G;
        bool i = true;
        /// <summary>
        /// Report ByDay Library using EPPlus
        /// </summary>
        /// <param name="InDt"></param>
        public API_MicrosoftSystemSpeech()
        {
#if fa
            try
            {
                InitializeComponent();
                foreach (string s in GrammarText)
                {
                    textBox1.Text = s + "|" + textBox1.Text;
                }
                foreach (string s in Choices)
                {
                    textBox2.Text = s + "|" + textBox2.Text;
                }
                btnStop.Enabled = false;
                btnStop.ForeColor = Color.Gray;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
#endif
        }

#region IDisposable
        /// <summary>
        /// 解構子。
        /// </summary>
        ~API_MicrosoftSystemSpeech()
        {
            Dispose(false);
        }
        /// <summary>
        /// 釋放資源
        /// </summary>
        private bool bDisposed { get; set; } = false;
        /// <summary>
        /// 釋放資源(程式設計師呼叫)。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); //要求系統不要呼叫指定物件的完成項。
        }
        /// <summary>
        /// 釋放資源(給系統呼叫的)。
        /// </summary>        
        protected virtual void Dispose(bool IsDisposing)
        {
            if (bDisposed)
            {
                return;
            }

            if (IsDisposing)
            {
                //補充：

                //這裡釋放具有實做 IDisposable 的物件(資源關閉或是 Dispose 等..)
                //ex: DataSet DS = new DataSet();
                //可在這邊 使用 DS.Dispose();
                //或是 DS = null;
                //或是釋放 自訂的物件。
                //因為我沒有這類的物件，故意留下這段 code ;若繼承這個類別，
                //可覆寫這個函式。
            }

            bDisposed = true;
        }
#endregion

#region Speak
        public void Speak(string InText)
        {
            try
            {
                if (!string.IsNullOrEmpty(InText))
                {
                    SpeechSynthesizer ss = new SpeechSynthesizer();
                    ss.Volume = 100;
                    ss.Speak(InText);
                }
                else
                {
                    MessageBox.Show("Please Write Someting First!");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
#endregion

#region Read
        public string Read(string InText)
        {
            string value = string.Empty;
            try
            {
                // Create an in-process speech recognizer for the en-US locale.  
                using (SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine()) // new System.Globalization.CultureInfo("en-US")
                {
                    // Create and load a dictation grammar.  
                    recognizer.LoadGrammar(new DictationGrammar());
                    recognizer.SetInputToDefaultAudioDevice();
                    RecognitionResult result = recognizer.Recognize();
                    value = result.Text;
                }
            }
            catch (Exception ex)
            {
                value = string.Empty;
                MessageBox.Show($"Mic Not Found:{ex}");
            }

            return value;
        }
        #endregion

#if fa
        private void btnBegin_Click(object sender, EventArgs e)
        {
            string[] a = { };
            SRecognition(a, 1);
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
            btnBegin.Enabled = false;
            btnStop.Enabled = true;
            btnBegin.ForeColor = Color.Gray;
            btnStop.ForeColor = Color.Black;
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            recognizer.RecognizeAsyncStop();
            btnBegin.Enabled = true;
            btnStop.Enabled = false;
            btnStop.ForeColor = Color.Gray;
            btnBegin.ForeColor = Color.Black;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtAll.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (true)
            {
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                if (i == false)
                {
                    MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show("确认修改?", "退出", messButton);
                    if (dr == DialogResult.OK)//如果点击“确定”按钮
                    {
                        GrammarText = textBox1.Text.Split('|');
                        Choices = textBox2.Text.Split('|');
                        GrammarText = GrammarText.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        Choices = Choices.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        i = !i;
                        textBox1.ReadOnly = true;
                        textBox2.ReadOnly = true;
                    }
                    else//如果点击“取消”按钮
                    {
                    }
                }
                i = false;
            }
        }

        public void SRecognition(string[] fg, int i) //创建关键词语列表  
        {
            CultureInfo myCIintl = new CultureInfo("zh-CN");
            foreach (RecognizerInfo config in SpeechRecognitionEngine.InstalledRecognizers())//获取所有语音引擎  
            {
                Console.WriteLine(config.Culture.EnglishName);
                if (config.Culture.Equals(myCIintl))
                {
                    recognizer = new SpeechRecognitionEngine(config);
                    break;
                }//选择识别引擎
            }
            if (recognizer != null)
            {
                InitializeSpeechRecognitionEngine(fg);//初始化语音识别引擎  
                dictationGrammar = new DictationGrammar();
            }
            else
            {
                MessageBox.Show("创建语音识别失败");
            }
        }

        void InitializeSpeechRecognitionEngine(string[] s)
        {
            // Create and load a dictation grammar.
            //recognizer.LoadGrammar(new DictationGrammar());

            // Configure input to the speech recognizer.
            recognizer.SetInputToDefaultAudioDevice();

            // Modify the initial silence time-out value.
            recognizer.InitialSilenceTimeout = TimeSpan.FromSeconds(5);

            GrammarBuilder GB = new GrammarBuilder();
            GB.Append(new Choices(GrammarText));
            GB.Append(new Choices(Choices));
            G = new Grammar(GB);
            G.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(G_SpeechRecognized);
            recognizer.LoadGrammar(G);
        }

        void G_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Text = e.Result.Text;
            Action action = () =>
            {
                txtAll.AppendText(Text + Environment.NewLine);
            };
            Invoke(action);
        }
#endif
    }
}
