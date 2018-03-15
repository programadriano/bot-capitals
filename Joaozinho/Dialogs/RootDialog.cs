using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Speech.Synthesis;
using System.IO;
using System.Web;
using NAudio.Lame;
using NAudio.Wave;

namespace Joaozinho.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            using (SpeechSynthesizer reader = new SpeechSynthesizer())
            {
                //set some settings
                reader.Volume = 100;
                reader.Rate = 0; //medium

                //save to memory stream
                MemoryStream ms = new MemoryStream();
                reader.SetOutputToWaveStream(ms);

                PromptBuilder builder = new PromptBuilder();
                builder.AppendText("This sample asynchronously speaks a prompt to a WAVE file.");
                reader.Speak(builder);

                //now convert to mp3 using LameEncoder or shell out to audiograbber
                var path = HttpContext.Current.Server.MapPath("/audios/");
                ConvertWavStreamToMp3File(ref ms, path + Guid.NewGuid() + ".mp3");
            }

            var reply = activity.CreateReply();

            Attachment attachment = new Attachment();
            attachment.ContentType = "audio/mpeg3";
            attachment.ContentUrl = @"C:\Logs\bot.mp3";
            attachment.Name = "Testing the Bot Framework Mp3";

            reply.Attachments.Add(attachment);


            await context.PostAsync("teste");
            context.Wait(MessageReceivedAsync);
        }

        public static void ConvertWavStreamToMp3File(ref MemoryStream ms, string savetofilename)
        {
            //rewind to beginning of stream
            ms.Seek(0, SeekOrigin.Begin);

            using (var retMs = new MemoryStream())
            using (var rdr = new WaveFileReader(ms))
            using (var wtr = new LameMP3FileWriter(savetofilename, rdr.WaveFormat, LAMEPreset.VBR_90))
            {
                rdr.CopyTo(wtr);
            }
        }


    }

   
}