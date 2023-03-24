using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAIChatgpt
{
    /// <summary>
    /// 
    /// https://developers.deepgram.com/sdks-tools/sdks/dotnet-sdk/
    /// </summary>
    public class API_Deepgram : IDisposable
    {
        /// <summary>
        /// Report ByDay Library using EPPlus
        /// </summary>
        /// <param name="InDt"></param>
        public API_Deepgram()
        {
        }

        /// <summary>
        /// 解構子。
        /// </summary>
        ~API_Deepgram()
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
    }
}
