using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arc.BuilderFrontend.Services
{
    public class ChatBoxService
    {
        public class ChatMessage
        {
            public string Text { get; set; } = string.Empty;
            public bool IsUser { get; set; }
        }

        public class ChatService
        {
            public List<ChatMessage> Messages { get; private set; } = new();
            public string Prompt { get; set; } = string.Empty;
            public bool IsTyping { get; private set; } = false;

            public async Task SendMessage()
            {
                if (string.IsNullOrWhiteSpace(Prompt)) return;

                var userPrompt = Prompt;
                Messages.Add(new ChatMessage { Text = userPrompt, IsUser = true });
                Prompt = string.Empty;

                IsTyping = true;
                await Task.Delay(1000); // simülasyon

                Messages.Add(new ChatMessage { Text = $"AI: \"{userPrompt}\" sorusuna örnek yanıt.", IsUser = false });
                IsTyping = false;
            }
        }
    }
}
