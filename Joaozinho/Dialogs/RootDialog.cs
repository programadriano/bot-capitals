using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Speech.Synthesis;
using System.IO;
using System.Web;
using NAudio.Lame;
using NAudio.Wave;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Joaozinho.Models;

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

            var capital = Estado.VerificarCapital(activity.Text);

            if (!String.IsNullOrEmpty(capital))
            {
                var reply = activity.CreateReply();

                Attachment attachment = new Attachment();
                attachment.ContentType = "audio/mpeg3";
                attachment.ContentUrl = @"http://localhost:3979/audios/" + RemoveSpecialChars(capital) + ".mp3";
                attachment.Name = "A capital de " + activity.Text + " é ";
                reply.Attachments.Add(attachment);
                await context.PostAsync(reply);

            }
            else
            {
                await context.PostAsync("Nenhuma capital encontrada para: " + activity.Text);
            }


            context.Wait(MessageReceivedAsync);


        }

        public static string RemoveSpecialChars(string input)
        {
            return Regex.Replace(input, @"[^0-9a-zA-Z\._]", string.Empty);
        }

    }


}