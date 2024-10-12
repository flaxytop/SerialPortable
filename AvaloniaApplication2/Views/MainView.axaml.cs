using Avalonia.Controls;
using Avalonia.Interactivity;
using DynamicData.Kernel;
using System;
using System.Diagnostics;
using Avalonia.Threading;
using System.IO.Ports;
using System.Linq;
using System.Threading;
namespace AvaloniaApplication2.Views;
using Avalonia.Controls;
using Avalonia.Threading;
using AvaloniaApplication2.ViewModels;
using System;
using System.Threading.Tasks;
public partial class MainView : UserControl
{
    SettingsWindow _settings;
    public MainView()
    {
        _settings = new SettingsWindow();

        InitializeComponent();

    }
    public void ComboBox_SelectionChanged_Ports(object sender, SelectionChangedEventArgs e)
    {
        
    }

    private void Button_Click_Settings(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if(_settings == null)
        {

            _settings.Show();
        }
        else
        {
            _settings.Close();
        }
        
    }
}
