using OpenAI_API;

namespace OpenAIChatgpt
{
    /// <summary>
    /// C# / .NET
    /// 1. Betalgo.OpenAI.GPT3 by Betalgo
    /// 2. OpenAI-API-dotnet by OkGoDoIt (V) 使用方法簡單
    /// 3. OpenAI-DotNet by RageAgainstThePixel
    /// https://ithelp.ithome.com.tw/articles/10310360?sc=rss.qu
    /// https://michaelceber.medium.com/chat-bot-using-chat-gpt-3-5-in-c-bb9c9a21f7db
    /// https://github.com/OkGoDoIt/OpenAI-API-dotnet
    /// </summary>
    public class API_OpenAI : IDisposable
    {
        /// <summary>
        /// Return Value Delegate
        /// </summary>
        /// <param name="pValue">The p value.</param>
        public delegate void ReturnValueDelegate(string pValue);
        /// <summary>
        /// Occurs when [return value callback].
        /// </summary>
        public event ReturnValueDelegate ReturnValueCallback;
        private string apikey { get; } = "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";
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
        /// OpenAI-API-dotnet - 聊天GPT
        /// </summary>
        public async Task ChatGPT()
        {
            // OpenAIAPI api = new OpenAIAPI(new APIAuthentication("YOUR_API_KEY", "org-yourOrgHere"));

            OpenAIAPI api = new OpenAIAPI(apikey);
            ReturnValueCallback("GetCompletion: One Two Three One Two");
            var result = await api.Completions.GetCompletion("One Two Three One Two");
            ReturnValueCallback($"result: {result}");
            // Console.WriteLine(result);
            // should print something starting with "Three"

            var chat = api.Chat.CreateConversation();

            ReturnValueCallback("AppendSystemMessage");
            /// give instruction as System
            chat.AppendSystemMessage("You are a teacher who helps children understand if things are animals or not.  If the user tells you an animal, you say \"yes\".  If the user tells you something that is not an animal, you say \"no\".  You only ever respond with \"yes\" or \"no\".  You do not say anything else.");

            // give a few examples as user and assistant
            ReturnValueCallback("AppendUserInput: Is this an animal? Cat");
            chat.AppendUserInput("Is this an animal? Cat");
            ReturnValueCallback("AppendExampleChatbotOutput: Yes");
            chat.AppendExampleChatbotOutput("Yes");
            ReturnValueCallback("AppendUserInput: Is this an animal? House");
            chat.AppendUserInput("Is this an animal? House");
            ReturnValueCallback("AppendExampleChatbotOutput: No");
            chat.AppendExampleChatbotOutput("No");

            // now let's ask it a question'
            ReturnValueCallback("AppendUserInput: Is this an animal? Dog");
            chat.AppendUserInput("Is this an animal? Dog");
            // and get the response
            string response = await chat.GetResponseFromChatbotAsync();
            ReturnValueCallback($"Chat: {response}");
            Console.WriteLine(response); // "Yes"

            // and continue the conversation by asking another
            ReturnValueCallback("AppendUserInput: Is this an animal? Chair");
            chat.AppendUserInput("Is this an animal? Chair");
            // and get another response
            response = await chat.GetResponseFromChatbotAsync();
            ReturnValueCallback($"Chat: {response}");
            Console.WriteLine(response); // "No"

            // the entire chat history is available in chat.Messages
            //foreach (ChatMessage msg in chat.Messages)
            //{
            //    Console.WriteLine($"{msg.Role}: {msg.Content}");
            //}

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
