using AvaloniaApplication2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AvaloniaApplication2.ViewModels
{
    public class MessageReceiver
    {
        public Thread ReceiverThread {  get; set; }
        public bool CanReceive { get; set; }
        public bool ShouldShutDownPermanently { get; set; }
        public SerialPortSevice SerialPortSevice { get; set; }
        public MessagesViewModel Messages { get; set; }

        public MessageReceiver(SerialPortSevice sevice, MessagesViewModel view)
        {
            CanReceive = true;
            ShouldShutDownPermanently = false;
            Messages = view;
            SerialPortSevice = sevice;

        }
        public void ReceiveLoop()
        {
            string message = "";
            char read;
            while (true)
            {
                if (ShouldShutDownPermanently)
                {
                    return;
                }
                if(CanReceive)
                {
                    if (SerialPortSevice.IsOpen())
                    {
                        try
                        {
                            read = SerialPortSevice.ReadChar();
                            switch (read)
                            {
                                case '\n':
                                    Messages.AddRecivedMessage(message);
                                    message = "";
                                    break;
                                case '\r':

                                    break;
                                default:
                                    message += read;
                                    break;

                            }
                        }
                        catch (Exception ex) { }
                    }
                }
                Thread.Sleep(1);
            }
        }
        public void StopThread() {
            CanReceive = false;
            ShouldShutDownPermanently = true;
            ReceiverThread = null;

        }
        public void StartThread()
        {
            ReceiverThread = new Thread(ReceiveLoop);
            ReceiverThread.Start();
            CanReceive = true;
            ShouldShutDownPermanently = false;

        }
    }
}
