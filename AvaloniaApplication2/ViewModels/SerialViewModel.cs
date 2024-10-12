using Avalonia.Controls;

using AvaloniaApplication2.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO.Ports;
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
        public int BaudRate_s { get { return _sevice.Port.BaudRate; } set { _sevice.Port.BaudRate = value; } }


        public int ReadTimeout_s { get { return _sevice.Port.ReadTimeout == -1 ? 0 : _sevice.Port.ReadTimeout; } set { _sevice.Port.ReadTimeout = value == 0 ? -1 : value; } }
        public int WriteTimeout_s { get { return _sevice.Port.WriteTimeout == -1 ? 0 : _sevice.Port.WriteTimeout; } set { _sevice.Port.WriteTimeout = value == 0 ? -1 : value; } }
        public Parity Parity_s { get { return _sevice.Port.Parity; } set { _sevice.Port.Parity = value; } }
        public int DataBits_s { get { return _sevice.Port.DataBits; } set { _sevice.Port.DataBits = value; } }
        public StopBits StopBits_s { get { return _sevice.Port.StopBits; } set { _sevice.Port.StopBits = value; } }
        public Handshake Handshake_s { get { return _sevice.Port.Handshake; } set { _sevice.Port.Handshake = value; } }
        public SerialViewModel(SerialPortSevice sevice) {

            _sevice = sevice;
           
            PortName = _sevice.PortName;
            AvailablePorts = sevice.GetAvailableSerialPorts();
            OpenCommand = ReactiveCommand.Create(sevice.Open);
            CloseCommand = ReactiveCommand.Create(sevice.Close);
            UpdateCommand = ReactiveCommand.Create(UpdatePorts);
            var b = ConfigurationManager.AppSettings;
            ReadTimeout_s = int.Parse(ConfigurationManager.AppSettings.Get("readtimeout"));
            WriteTimeout_s = int.Parse(ConfigurationManager.AppSettings.Get("writetimeout"));
            Parity_s = (Parity)int.Parse(ConfigurationManager.AppSettings.Get("parity"));
            DataBits_s = int.Parse(ConfigurationManager.AppSettings.Get("databits"));
            StopBits_s = (StopBits)int.Parse(ConfigurationManager.AppSettings.Get("stopbits"));
            Handshake_s = (Handshake)int.Parse(ConfigurationManager.AppSettings.Get("handshake"));
            
            

        }

        private void UpdatePorts()
        {
            AvailablePorts = _sevice.GetAvailableSerialPorts();
            _sevice.writeLineConsole($"{DateTime.Now} | Console: Available ports updated");
        }

    }
}
