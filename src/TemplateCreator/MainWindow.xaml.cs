namespace TemplateCreator;

using CommunityToolkit.Mvvm.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();

        CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, OnClose));
    }

    private void OnClose(object sender, ExecutedRoutedEventArgs e)
    {
        Close();
    }
}
public partial class MainWindowViewModel : ObservableObject
{
    public MainWindowViewModel()
    {
        Processes = Process.GetProcesses().OrderBy(p => p.ProcessName).ToList();
    }
    [ObservableProperty]
    private List<Process> _processes;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsProcessSelected))]
    private Process _selectedProcess;

    public bool IsProcessSelected => SelectedProcess != null;
}