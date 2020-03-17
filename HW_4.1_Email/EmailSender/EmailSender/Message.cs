using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender
{
    class Message
    {
        public Message(string subject, string content, string receiver, string sender)
        {
            Subject = subject;
            Content = content;
            Receiver = receiver;
            Sender = sender;
        }

        public string Subject { get; }
        public string Content { get; }
        public string Receiver { get; }
        public string Sender { get; }

    }
}
