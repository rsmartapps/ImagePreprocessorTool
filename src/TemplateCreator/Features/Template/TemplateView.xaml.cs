using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace TemplateCreator.Features.Template;

/// <summary>
/// Interaction logic for TemplateView.xaml
/// </summary>
public partial class TemplateView : UserControl
{
    public TemplateView()
    {
        InitializeComponent();

    }
}


public partial class TemplateMVVM : ObservableObject
{

    [ObservableProperty]
    private ROIArea _rOI;

    [ObservableProperty]
    private float _threshold;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(TestTemplateCommand))]
    private BitmapSource _templateImage;

    [RelayCommand(CanExecute = nameof(CanTestTemplateCommand))]
    public void TestTemplate()
        => Parent.IsTestSelected = true;

    public bool CanTestTemplateCommand()
    {
        if (TemplateImage is not null)
        {
            return true;
        }
        return false;

    }

    public MainWindowViewModel Parent { get; set; }

    public TemplateMVVM()
    {
        Threshold = .8f;
        ROI = new();
    }
}

