using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace TemplateCreator.Features.Template;

/// <summary>
/// Interaction logic for ROIControl.xaml
/// </summary>
[ObservableObject]
public partial class ROIControl : UserControl
{
    public static readonly DependencyProperty LeftProperty =
        DependencyProperty.Register(nameof(Left), typeof(double), typeof(ROIControl), new PropertyMetadata(0.0));

    public static readonly DependencyProperty TopProperty =
        DependencyProperty.Register(nameof(Top), typeof(double), typeof(ROIControl), new PropertyMetadata(0.0));

    public static readonly DependencyProperty RightProperty =
        DependencyProperty.Register(nameof(Right), typeof(double), typeof(ROIControl), new PropertyMetadata(100.0));

    public static readonly DependencyProperty BottomProperty =
        DependencyProperty.Register(nameof(Bottom), typeof(double), typeof(ROIControl), new PropertyMetadata(100.0));

    public static readonly DependencyProperty ActualImageWidthProperty =
        DependencyProperty.Register(nameof(ActualImageWidth), typeof(double), typeof(ROIControl), new PropertyMetadata(0.0));

    public static readonly DependencyProperty ActualImageHeightProperty =
        DependencyProperty.Register(nameof(ActualImageHeight), typeof(double), typeof(ROIControl), new PropertyMetadata(0.0));

    public static readonly DependencyProperty ROIWidthProperty =
        DependencyProperty.Register(nameof(ROIWidth), typeof(double), typeof(ROIControl), new PropertyMetadata(0.0));

    public static readonly DependencyProperty ROIHeightProperty =
        DependencyProperty.Register(nameof(ROIHeight), typeof(double), typeof(ROIControl), new PropertyMetadata(0.0));


    [ObservableProperty]
    private double _rightDrag;
    [ObservableProperty]
    private double _bottomDrag;

    public double Left
    {
        get => (double)GetValue(LeftProperty);
        set => SetValue(LeftProperty, value);
    }

    public double Top
    {
        get => (double)GetValue(TopProperty);
        set => SetValue(TopProperty, value);
    }

    public double Right
    {
        get => (double)GetValue(RightProperty);
        set
        {
            SetValue(RightProperty, value);
            RightDrag = Right - 10;
            ROIWidth = ROIWidth;
        }
    }

    public double Bottom
    {
        get => (double)GetValue(BottomProperty);
        set
        {
            SetValue(BottomProperty, value);
            BottomDrag = Bottom - 10;
            ROIHeight = ROIHeight;
        }
    }

    public double ActualImageWidth
    {
        get => (double)GetValue(ActualImageWidthProperty);
        set => SetValue(ActualImageWidthProperty, value);
    }

    public double ActualImageHeight
    {
        get => (double)GetValue(ActualImageHeightProperty);
        set => SetValue(ActualImageHeightProperty, value);
    }

    public double ROIWidth
    {
        get => Right - Left;
        set => SetValue(ROIWidthProperty, value);
    }
    public double ROIHeight
    {
        get => Bottom - Top;
        set => SetValue(ROIHeightProperty, value);
    }

    public ROIControl()
    {
        InitializeComponent();
    }

    private void DragTopLeft(object sender, DragDeltaEventArgs e)
    {
        if (
            Left + e.HorizontalChange >= 0
            && Right + e.HorizontalChange <= ActualImageWidth
        )
        {
            Left += e.HorizontalChange;
            Right += e.HorizontalChange;
        }

        if (Top + e.VerticalChange >= 0
            && Bottom + e.VerticalChange <= ActualImageHeight
        )
        {
            Top += e.VerticalChange;
            Bottom += e.VerticalChange;
        }
    }

    private void DragBottomRight(object sender, DragDeltaEventArgs e)
    {
        if (Right + e.HorizontalChange <= ActualImageWidth)
        {
            Right += e.HorizontalChange;
        }
        if (Bottom + e.VerticalChange <= ActualImageHeight)
        {
            Bottom += e.VerticalChange;
        }
    }
}

public sealed class ROIArea
{
    public double Top { get; set; }
    public double Bottom { get; set; } = 50;
    public double Left { get; set; }
    public double Right { get; set; } = 50;

    public double Width => Right - Left;
    public double Height => Bottom - Top;
}
