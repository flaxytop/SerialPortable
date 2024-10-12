using Avalonia.Controls;
using AvaloniaApplication2.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication2.ViewModels
{
    public class SerialViewModel : ViewModelBase
    {
        public string _portName;
        public string[] _availablePorts;
        private SerialPortSevice _sevice;
        public string PortName { get { return _portName; } set { this.RaiseAndSetIfChanged(ref _portName, value); _sevice.PortName = value;  } }
        public string[] AvailablePorts { get { return _availablePorts; } set { this.RaiseAndSetIfChanged(ref _availablePorts, value); } }

        public ReactiveCommand<Unit, Unit> OpenCommand { get; }
        public ReactiveCommand<Unit, Unit> CloseCommand { get; }
        public ReactiveCommand<Unit, Unit> UpdateCommand { get; }
        public SerialViewModel(SerialPortSevice sevice) {

            _sevice = sevice;
            PortName = _sevice.PortName;
            AvailablePorts = sevice.GetAvailableSerialPorts();
            OpenCommand = ReactiveCommand.Create(sevice.Open);
            CloseCommand = ReactiveCommand.Create(sevice.Close);
            UpdateCommand = ReactiveCommand.Create(UpdatePorts);

        }

        private void UpdatePorts()
        {
            AvailablePorts = _sevice.GetAvailableSerialPorts();
            _sevice.writeLineConsole($"{DateTime.Now} | Console: Available ports updated");
        }
    }
}
