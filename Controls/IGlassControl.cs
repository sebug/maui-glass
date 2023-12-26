namespace maui_glass.Controls;

public interface IGlassControl : IView
{
    string StatusText { get; set; }

    void StartVideo();
}