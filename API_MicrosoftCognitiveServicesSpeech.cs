using System;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech.Speaker;

namespace OpenAIChatgpt
{
    /// <summary>
    /// Quickstart: Recognize and translate speech to text
    /// https://learn.microsoft.com/en-us/azure/cognitive-services/speech-service/get-started-speech-translation?tabs=windows%2Cterminal&pivots=programming-language-csharp
    ///
    /// https://learn.microsoft.com/zh-tw/azure/cognitive-services/speech-service/
    /// 免費 (F0)
    /// 5 audio hours free per month
    /// https://azure.microsoft.com/zh-tw/pricing/details/cognitive-services/speech-services/
    /// https://azure.microsoft.com/en-us/pricing/details/cognitive-services/speech-services/
    /// 語音服務的語言和語音支援
    /// https://learn.microsoft.com/zh-tw/azure/cognitive-services/speech-service/language-support?tabs=stt
    /// Azure-Samples  cognitive-services-speech-sdk
    /// https://github.com/Azure-Samples/cognitive-services-speech-sdk/blob/master/samples/csharp/sharedcontent/console/speech_recognition_samples.cs
    /// </summary>
    public class API_MicrosoftCognitiveServicesSpeech : IDisposable
    {
        // Creates an instance of a speech config with specified subscription key and service region.
        // Replace with your own subscription key and service region (e.g., "westus").
        SpeechConfig config { set; get; }

        /// <summary>
        /// Report ByDay Library using EPPlus
        /// </summary>
        /// <param name="InDt"></param>
        public API_MicrosoftCognitiveServicesSpeech()
        {
            // https://learn.microsoft.com/zh-tw/azure/cognitive-services/speech-service/get-started-intent-recognition?pivots=programming-language-csharp
            // config = SpeechConfig.FromSubscription("e328661b67904115ad544d26e6682d74", "japaneast");
            // config.SpeechRecognitionLanguage= "en-us";
        }

        #region IDisposable
        /// <summary>
        /// 解構子。
        /// </summary>
        ~API_MicrosoftCognitiveServicesSpeech()
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

        #region Recognition With Microphone Async
        /// <summary>
        /// RecognitionWithMicrophoneAsync
        /// </summary>
        /// <returns></returns>
        public async Task RecognitionWithMicrophoneAsync()
        {
            try
            {
                // Creates a speech recognizer.
                using (SpeechRecognizer recognizer = new SpeechRecognizer(config))
                {
                    Console.WriteLine("Say something...");

                    // Starts speech recognition, and returns after a single utterance is recognized. The end of a
                    // single utterance is determined by listening for silence at the end or until a maximum of 15
                    // seconds of audio is processed.  The task returns the recognition text as result. 
                    // Note: Since RecognizeOnceAsync() returns only a single utterance, it is suitable only for single
                    // shot recognition like command or query. 
                    // For long-running multi-utterance recognition, use StartContinuousRecognitionAsync() instead.
                    var result = await recognizer.RecognizeOnceAsync();

                    // Checks result.
                    if (result.Reason == ResultReason.RecognizedSpeech)
                    {
                        Console.WriteLine($"We recognized: {result.Text}");
                    }
                    else if (result.Reason == ResultReason.NoMatch)
                    {
                        Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                    }
                    else if (result.Reason == ResultReason.Canceled)
                    {
                        var cancellation = CancellationDetails.FromResult(result);
                        Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                        if (cancellation.Reason == CancellationReason.Error)
                        {
                            Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                            Console.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                            Console.WriteLine($"CANCELED: Did you update the subscription info?");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Recognition With Language And Detailed OutputAsync
        /// <summary>
        /// Recognition With Language And Detailed OutputAsync
        /// Speech recognition in the specified spoken language and uses detailed output format.
        /// </summary>
        /// <returns></returns>
        public async Task RecognitionWithLanguageAndDetailedOutputAsync()
        {
            // Replace the language with your language in BCP-47 format, e.g., en-US.
            var language = "de-DE";

            // Ask for detailed recognition result
            config.OutputFormat = OutputFormat.Detailed;

            // If you also want word-level timing in the detailed recognition results, set the following.
            // Note that if you set the following, you can omit the previous line
            //      "config.OutputFormat = OutputFormat.Detailed",
            // since word-level timing implies detailed recognition results.
            config.RequestWordLevelTimestamps();

            // Creates a speech recognizer for the specified language, using microphone as audio input.
            // Requests detailed output format.
            using (var recognizer = new SpeechRecognizer(config, language))
            {
                // Starts recognizing.
                Console.WriteLine($"Say something in {language} ...");

                // Starts speech recognition, and returns after a single utterance is recognized. The end of a
                // single utterance is determined by listening for silence at the end or until a maximum of 15
                // seconds of audio is processed.  The task returns the recognition text as result.
                // Note: Since RecognizeOnceAsync() returns only a single utterance, it is suitable only for single
                // shot recognition like command or query.
                // For long-running multi-utterance recognition, use StartContinuousRecognitionAsync() instead.
                var result = await recognizer.RecognizeOnceAsync().ConfigureAwait(false);

                // Checks result.
                if (result.Reason == ResultReason.RecognizedSpeech)
                {
                    Console.WriteLine($"RECOGNIZED: Text = {result.Text}");
                    Console.WriteLine("  Detailed results:");

                    // The first item in detailedResults corresponds to the recognized text
                    // (NOT the item with the highest confidence number!)
                    var detailedResults = result.Best();
                    foreach (var item in detailedResults)
                    {
                        Console.WriteLine($"\tConfidence: {item.Confidence}\n\tText: {item.Text}\n\tLexicalForm: {item.LexicalForm}\n\tNormalizedForm: {item.NormalizedForm}\n\tMaskedNormalizedForm: {item.MaskedNormalizedForm}");
                        Console.WriteLine($"\tWord-level timing:");
                        Console.WriteLine($"\t\tWord | Offset | Duration");

                        // Word-level timing
                        foreach (var word in item.Words)
                        {
                            Console.WriteLine($"\t\t{word.Word} {word.Offset} {word.Duration}");
                        }
                    }
                }
                else if (result.Reason == ResultReason.NoMatch)
                {
                    Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                }
                else if (result.Reason == ResultReason.Canceled)
                {
                    var cancellation = CancellationDetails.FromResult(result);
                    Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                        Console.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                        Console.WriteLine($"CANCELED: Did you update the subscription info?");
                    }
                }
            }
        }
        #endregion

        #region Continuous Recognition With File Async
        /// <summary>
        /// Continuous Recognition With File Async
        /// Continuous speech recognition.
        /// </summary>
        /// <returns></returns>
        public async Task ContinuousRecognitionWithFileAsync(string InFilrePath)
        {
            try
            {
                
                // <recognitionContinuousWithFile>
                var stopRecognition = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);

                // Creates a speech recognizer using file as audio input.
                // Replace with your own audio file name.
                using (var audioInput = AudioConfig.FromWavFileInput(InFilrePath)) // @"whatstheweatherlike.wav"
                {
                    using (var recognizer = new SpeechRecognizer(config, audioInput))
                    {
                        Console.WriteLine("Recognizing...");
                        var result = await recognizer.RecognizeOnceAsync();
                        Console.WriteLine($"Recognition result: {result.Text}");
#if fa
                        // Subscribes to events.
                        recognizer.Recognizing += (s, e) =>
                        {
                            Console.WriteLine($"RECOGNIZING: Text={e.Result.Text}");
                        };

                        recognizer.Recognized += (s, e) =>
                        {
                            if (e.Result.Reason == ResultReason.RecognizedSpeech)
                            {
                                Console.WriteLine($"RECOGNIZED: Text={e.Result.Text}");
                            }
                            else if (e.Result.Reason == ResultReason.NoMatch)
                            {
                                Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                            }
                        };

                        recognizer.Canceled += (s, e) =>
                        {
                            Console.WriteLine($"CANCELED: Reason={e.Reason}");

                            if (e.Reason == CancellationReason.Error)
                            {
                                Console.WriteLine($"CANCELED: ErrorCode={e.ErrorCode}");
                                Console.WriteLine($"CANCELED: ErrorDetails={e.ErrorDetails}");
                                Console.WriteLine($"CANCELED: Did you update the subscription info?");
                            }

                            stopRecognition.TrySetResult(0);
                        };

                        recognizer.SessionStarted += (s, e) =>
                        {
                            Console.WriteLine("\n    Session started event.");
                        };

                        recognizer.SessionStopped += (s, e) =>
                        {
                            Console.WriteLine("\n    Session stopped event.");
                            Console.WriteLine("\nStop recognition.");
                            stopRecognition.TrySetResult(0);
                        };

                        // Starts continuous recognition. Uses StopContinuousRecognitionAsync() to stop recognition.
                        await recognizer.StartContinuousRecognitionAsync().ConfigureAwait(false);

                        // Waits for completion.
                        // Use Task.WaitAny to keep the task rooted.
                        Task.WaitAny(new[] { stopRecognition.Task });

                        // Stops recognition.
                        await recognizer.StopContinuousRecognitionAsync().ConfigureAwait(false);
#endif
                    }
                }
                // </recognitionContinuousWithFile>
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Continuous Recognition With File Async
        public async Task<List<VoiceProfile>> WavIdentificationEnroll(SpeechConfig config, 
                                                                        List<string> profileNames,
                                                                        Dictionary<string, string> fileNames,
                                                                        Dictionary<string, string> profileMapping)
        {
            try
            {
                List<VoiceProfile> voiceProfiles = new List<VoiceProfile>();
                using (var client = new VoiceProfileClient(config))
                {
                    var phraseResult = await client.GetActivationPhrasesAsync(VoiceProfileType.TextIndependentVerification, "en-us");
                    foreach (string name in profileNames)
                    {

                        // Speech Cognitive services Authentication error (401) even with correct subscription key
                        // https://learn.microsoft.com/en-us/answers/questions/285441/speech-cognitive-services-authentication-error-(40
                        using (var audioInput = AudioConfig.FromWavFileInput(fileNames[name])) // .FromDefaultMicrophoneInput()
                        {

                            // The API Key provided is not authorized. This is a gated service,
                            // make sure your Azure Subscription ID is approved VoiceProfileClient GetActivationPhrasesAsync
                            var profile = await client.CreateProfileAsync(VoiceProfileType.TextIndependentVerification, "en-us");
                            Console.WriteLine($"Creating voice profile for {name}.");
                            profileMapping.Add(profile.Id, name);

                            VoiceProfileEnrollmentResult result = null;
                            while (result is null || result.RemainingEnrollmentsSpeechLength > TimeSpan.Zero)
                            {
                                Console.WriteLine($"Speak the activation phrase, \"${phraseResult.Phrases[0]}\" to add to the profile enrollment sample for {name}.");
                                result = await client.EnrollProfileAsync(profile, audioInput);
                                Console.WriteLine($"Remaining enrollment audio time needed: {result.RemainingEnrollmentsSpeechLength}");
                                Console.WriteLine("");
                            }
                            voiceProfiles.Add(profile);
                        }
                    }
                }

                return voiceProfiles;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task SpeakerIdentification(SpeechConfig config, 
                                                    List<VoiceProfile> voiceProfiles, 
                                                    Dictionary<string, string> profileMapping)
        {
            var speakerRecognizer = new SpeakerRecognizer(config, AudioConfig.FromDefaultMicrophoneInput());
            var model = SpeakerIdentificationModel.FromProfiles(voiceProfiles);

            Console.WriteLine("Speak some text to identify who it is from your list of enrolled speakers.");
            var result = await speakerRecognizer.RecognizeOnceAsync(model);
            Console.WriteLine($"The most similar voice profile is {profileMapping[result.ProfileId]} with similarity score {result.Score}");
        }

        public async Task WavSpeakerIdentification(SpeechConfig config,
                                            string InFilePath,
                                            List<VoiceProfile> voiceProfiles,
                                            Dictionary<string, string> profileMapping)
        {

            //var speakerRecognizer = new SpeakerRecognizer(config, AudioConfig.FromDefaultMicrophoneInput());
            //var model = SpeakerIdentificationModel.FromProfiles(voiceProfiles);

            //Console.WriteLine("Speak some text to identify who it is from your list of enrolled speakers.");
            //var result = await speakerRecognizer.RecognizeOnceAsync(model);
            //Console.WriteLine($"The most similar voice profile is {profileMapping[result.ProfileId]} with similarity score {result.Score}");

            try
            {
                using (SpeakerRecognizer speakerRecognizer = new SpeakerRecognizer(config, AudioConfig.FromWavFileInput(InFilePath)))
                {
                    using (SpeakerIdentificationModel model = SpeakerIdentificationModel.FromProfiles(voiceProfiles))
                    {
                        Console.WriteLine("Speak some text to identify who it is from your list of enrolled speakers.");

                        var result = await speakerRecognizer.RecognizeOnceAsync(model);

                        Console.WriteLine($"The most similar voice profile is {profileMapping[result.ProfileId]} with similarity score {result.Score}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
