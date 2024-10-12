using Avalonia.Media.Imaging;

using AvaloniaApplication2.Services;
using ReactiveUI;
using System.IO;
using System.IO.Ports;

namespace AvaloniaApplication2.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel() {
        
        serialPortSevice = new SerialPortSevice();
        Sender = new MessageSender(serialPortSevice);
       
        Messages = new MessagesViewModel(Sender);
        Receiver = new MessageReceiver(serialPortSevice, Messages);
        Ports = new SerialViewModel(serialPortSevice);
        serialPortSevice.writeLineConsole = Messages.WriteLine;
        serialPortSevice.StartThread = Receiver.StartThread;
        serialPortSevice.StopThread = Receiver.StopThread;
    }
    public MessagesViewModel Messages { get; set; }
    public MessageSender Sender { get; set; }
    public MessageReceiver Receiver { get; set; }
    public SerialViewModel Ports { get; set; }
    public SerialPortSevice serialPortSevice { get; set; }



    private delegate void WriteLine(string message);

    
}
