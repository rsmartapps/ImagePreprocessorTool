using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TemplateCreator.Features.Template.Match;

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
    private ICollection<Methods> _parametrizations;

    [ObservableProperty]
    private ROIArea _rOI;

    [ObservableProperty]
    private float _threshold;

    [ObservableProperty]
    private Visibility _isROIEnabled;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(TestTemplateCommand))]
    private BitmapSource _templateImage;

    [RelayCommand(CanExecute = nameof(CanTestTemplateCommand))]
    public void TestTemplate()
        => Parent.IsTestSelected = true;

    [RelayCommand]
    public void EnableDisableROI()
    {
        ROI.Top = 0;
        ROI.Left = 0;
        ROI.Bottom = 100;
        ROI.Right = 100;
        IsROIEnabled = IsROIEnabled == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;

    }

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
        IsROIEnabled = Visibility.Hidden;
        ROI = new();
        Parametrizations = Enum.GetValues<Methods>();
    }
}

