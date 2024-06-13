namespace TemplateCreator;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using TemplateCreator.Features.Windows;
using Windows.Win32;

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
        Processes = Process.GetProcesses().Where(w => w.MainWindowHandle != IntPtr.Zero && PInvoke.IsWindowVisible(new(w.MainWindowHandle))).OrderBy(p => p.ProcessName).ToList();
    }

    [ObservableProperty]
    private List<Process> _processes;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(TakeScreenshotCommand))]
    private Process _selectedProcess;

    [ObservableProperty]
    private BitmapSource _originalImage;

    [RelayCommand(CanExecute = nameof(CanTakeScreenshotCommand))]
    public void TakeScreenshot()
    {

        var bmp = WindowCaptureHelper.CaptureClientWindowImage(SelectedProcess);
        bmp.Save("c:\\dev\\img.jpeg");
        OriginalImage = Imaging.CreateBitmapSourceFromHBitmap(
            bmp.GetHbitmap(),
            IntPtr.Zero,
            Int32Rect.Empty,
            BitmapSizeOptions.FromEmptyOptions());
    }

    public bool CanTakeScreenshotCommand()
        => SelectedProcess is not null;
}