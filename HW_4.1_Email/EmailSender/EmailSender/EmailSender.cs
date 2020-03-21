using System;
using static EmailSender.Program;

namespace EmailSender
{
    class EmailSender
    {
        private EventHandler<MessageSentEventArgs> messageSent;  

        public event EventHandler<MessageSentEventArgs> MessageSent
        {
            add
            {

            }
            remove
            {

            }
        }
        public void Send (Message message, params MessageValidator[] validators)
        {
                      
        }
    }
}
