using AvaloniaApplication2.ViewModels;
using Microsoft.VisualBasic;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication2.Services
{
    public class SerialPortSevice
    {
        public SerialPort Port;
        public string PortName { get => Port.PortName; set { if (value == null && !Port.IsOpen) { Port.PortName = "COM1"; } else { if (Port.IsOpen) { writeLineConsole($"{DateTime.Now} | Console: {PortName} is closed"); Port.Close(); } else { Port.PortName = value; } }; } }
        public int BufferSize { get => Port.WriteBufferSize; set { Port.WriteBufferSize = value; } }
        
        public WriteLineConsole writeLineConsole { get; set; }

        public delegate void WriteLineConsole(string message);

        public startThread StartThread { get; set; }

        public delegate void startThread();
        public stopThread StopThread { get; set; }

        public delegate void stopThread();


        // Settings


        // ******************************************


        public SerialPortSevice(string name, int buffer) {
            Port = new SerialPort(name, buffer);      

        }
        public SerialPortSevice() { 
            Port = new SerialPort();   
           
        }

        public void Open()
        {
            if(!Port.IsOpen) { 
                Port.Open();

                writeLineConsole($"{DateTime.Now} | Console: {PortName} is opened");
                StartThread();
            }
            else
            {
                writeLineConsole($"{DateTime.Now} | Console: {PortName} is already opened");
                
            }
            
        }
        public void Close()
        {
            if (Port.IsOpen)
            {
                Port.Close();
                StopThread();
                
                Port.Parity = Parity.None;

                writeLineConsole($"{DateTime.Now} | Console: {PortName} is closed");
            }
            else
            {
                writeLineConsole($"{DateTime.Now} | Console: {PortName} is not open");
            }
        }

        public bool IsOpen()
        {
            return Port.IsOpen;
        }

        public string ReadLine()
        {
            return Port.ReadLine();
        }
        public char ReadChar()
        {
            return (char)Port.ReadChar();

        }
        public void WriteLine(string text)
        {
            if (Port.IsOpen)
            {
              
                Port.WriteLine(text);
            }
            else
            {
                writeLineConsole($"{DateTime.Now} | Console: error - port is not open");
            }
        }
        public string[] GetAvailableSerialPorts()
        {
            return SerialPort.GetPortNames();
        }

    }
}
