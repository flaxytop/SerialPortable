using AvaloniaApplication2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication2.ViewModels
{
    public class MessageSender
    {
        private SerialPortSevice serialPortSevice;

        public MessageSender(SerialPortSevice serialPortSevice)
        {
            this.serialPortSevice = serialPortSevice;
        }

        public void SendMessage(string message)
        {
            serialPortSevice.WriteLine(message);
        }
    }
}
