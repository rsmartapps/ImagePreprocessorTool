using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace TemplateCreator.Features.Template;

/// <summary>
/// Interaction logic for TemplateView.xaml
/// </summary>
public partial class TemplateView : UserControl
{
    private bool isDragging = false;
    private Point clickPosition;

    public TemplateView()
    {
        InitializeComponent();
    }

    private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
    {
        var vm = (TemplateMVVM)DataContext;
        vm.ThumbDragDeltaCommand.Execute(e);
    }
}

public class MoveThumb : Thumb
{
    public MoveThumb()
    {
        DragDelta += new DragDeltaEventHandler(this.MoveThumb_DragDelta);
    }

    private void MoveThumb_DragDelta(object sender, DragDeltaEventArgs e)
    {
        Control designerItem = this.DataContext as Control;

        if (designerItem != null)
        {
            double left = Canvas.GetLeft(designerItem);
            double top = Canvas.GetTop(designerItem);

            Canvas.SetLeft(designerItem, left + e.HorizontalChange);
            Canvas.SetTop(designerItem, top + e.VerticalChange);
        }
    }
}
