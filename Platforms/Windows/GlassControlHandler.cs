using maui_glass.Controls;
using maui_glass.Platforms.Windows;
using Microsoft.Maui.Handlers;

namespace maui_glass.Handlers;

public partial class GlassControlHandler : ViewHandler<IGlassControl, GLassControlPlatformView>
{
    protected override GlassPlatformView CreatePlatformView()
    {
        return new GlassPlatformView();
    }

    override GlassPlatformView CreatePlatformView()
    {
        return new GlassPlatformView();
    }
}