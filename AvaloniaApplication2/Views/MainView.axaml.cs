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
    public MainView()
    {

        InitializeComponent();

    }
    public void ComboBox_SelectionChanged_Ports(object sender, SelectionChangedEventArgs e)
    {
        
    }

    private void Button_Click_Settings(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

        SettingsBox.IsEnabled = !SettingsBox.IsEnabled;
        SettingsBox.IsVisible = !SettingsBox.IsVisible;
        SettingsTitle.IsVisible = !SettingsTitle.IsVisible;
        SettingsTitle.IsEnabled = !SettingsTitle.IsEnabled;

        var fg = ConsoleBox.IsEnabled = !ConsoleBox.IsEnabled;
        ConsoleBox.IsVisible = !ConsoleBox.IsVisible;
        ConsoleTitle.IsEnabled = !ConsoleTitle.IsEnabled;
        ConsoleTitle.IsVisible = !ConsoleTitle.IsVisible;

        SettingsButton.Content = fg ? "Settings" : "Console";


    }

    private void TextBox_TextChanged(object? sender, Avalonia.Controls.TextChangedEventArgs e)
    {
        ConsoleBox.CaretIndex = int.MaxValue;
    }
}
