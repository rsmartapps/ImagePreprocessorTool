using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;

namespace TemplateCreator.Features.Template;

public partial class TemplateMVVM : ObservableObject
{
    [ObservableProperty]
    private Size _rOI;

    [ObservableProperty]
    private float _threshold;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(TestTemplateCommand))]
    private BitmapSource _templateImage;

    [RelayCommand]
    private void ThumbDragDelta(DragDeltaEventArgs e)
    {
        //ROI.Width += e.HorizontalChange;
        //ThumbTop += e.VerticalChange;
    }

    [RelayCommand(CanExecute = nameof(CanTestTemplateCommand))]
    public void TestTemplate()
        => Parent.IsTestSelected = true;

    public bool CanTestTemplateCommand()
        => TemplateImage is not null;

    public MainWindowViewModel Parent { get; set; }

    public TemplateMVVM()
    {
        Threshold = .8f;
    }

    [RelayCommand]
    public void OnBehaviour()
    {

    }

    [RelayCommand]
    public void OnTrigger()
    {

    }
}
