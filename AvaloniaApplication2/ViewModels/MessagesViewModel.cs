using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication2.ViewModels
{
    public class MessagesViewModel : ViewModelBase
    {

        private int messageCount;
        private string messagesText;
        private string to_be_sent_message;

        private MessageSender Sender { get; set; }


        
        public int MessageCount
        {
            get { return messageCount; }
            set { this.RaiseAndSetIfChanged(ref messageCount, value); }
        }
        public string MessagesText
        {
            get { return messagesText; }
            set { this.RaiseAndSetIfChanged(ref messagesText, value); }
        }
        public string ToBeSentMessage
        {
            get => to_be_sent_message;
            set {this.RaiseAndSetIfChanged(ref  to_be_sent_message, value); }
        }
        public MessagesViewModel(MessageSender sender)
        {
            MessageCount = 0;
            MessagesText = string.Empty;
            ToBeSentMessage = string.Empty;
            Sender = sender;
            ClearMessageCommand = ReactiveCommand.Create(ClearMessages);
            SendMessageCommand = ReactiveCommand.Create(SendMessage);

        }


        public ReactiveCommand<Unit, Unit> ClearMessageCommand { get; }
        public ReactiveCommand<Unit, Unit> SendMessageCommand { get; }   


        void SendMessage()
        {
            if(!string.IsNullOrEmpty(ToBeSentMessage))
            {
                
                AddSentMessage(ToBeSentMessage);
                Sender.SendMessage(ToBeSentMessage);
                ToBeSentMessage = string.Empty;
            }
        }
        void ClearMessages()
        {
            messagesText = string.Empty;
            messageCount = 0;
        }

        public void WriteLine(string message)
        {
            MessagesText += message + '\n';
        }

        void AddMessage(string message)
        {
            WriteLine(message);
            MessageCount += 1;
        }
        public void AddSentMessage(string message)
        {
            AddMessage($"{DateTime.Now} | TX$ {message}");
        }
        public void AddRecivedMessage(string message)
        {
            AddMessage($"{DateTime.Now} | RX$ {message}");
        }
    }
}
