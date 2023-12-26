namespace maui_glass.Controls;

public class GlassControl : View, IGlassControl
{
    public static readonly BindableProperty StatusTextProperty =
        BindableProperty.Create(nameof(StatusText), typeof(string),
        typeof(GlassControl), "No Status Set");

    public string StatusText
    {
        get => (string)GetValue(StatusTextProperty);
        set => SetValue(StatusTextProperty, value);
    }
}