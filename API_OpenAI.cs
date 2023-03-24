using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;

namespace OpenAIChatgpt
{
    /// <summary>
    /// https://ithelp.ithome.com.tw/articles/10310360?sc=rss.qu
    /// https://michaelceber.medium.com/chat-bot-using-chat-gpt-3-5-in-c-bb9c9a21f7db

    public class API_OpenAI : IDisposable
    {
        /// <summary>
        /// Report ByDay Library using EPPlus
        /// </summary>
        /// <param name="InDt"></param>
        public API_OpenAI()
        {
        }

        #region IDisposable
        /// <summary>
        /// 解構子。
        /// </summary>
        ~API_OpenAI()
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

        /// <summary>
        /// 
        /// </summary>
        public void ChatGPT()
        {
#if fa
            var completionResult = await sdk.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
            {
                Messages = new List<ChatMessage>
    {
        ChatMessage.FromSystem("You are a helpful assistant."),
        ChatMessage.FromUser("Who won the world series in 2020?"),
        ChatMessage.FromAssistant("The Los Angeles Dodgers won the World Series in 2020."),
        ChatMessage.FromUser("Where was it played?")
    },
                Model = Models.ChatGpt3_5Turbo
            });
            if (completionResult.Successful)
            {
                Console.WriteLine(completionResult.Choices.First().Message.Content);
            }
            else
            {
                if (completionResult.Error == null)
                {
                    throw new Exception("Unknown Error");
                }

                Console.WriteLine($"{completionResult.Error.Code}: {completionResult.Error.Message}");
            }
#endif
        }
    }
}
