using maui_glass.Controls;
using maui_glass.Platforms.Android;
using Microsoft.Maui.Handlers;

namespace maui_glass.Handlers;

public partial class GlassControlHandler : ViewHandler<IGlassControl, GlassPlatformView>
{
    protected override GlassPlatformView CreatePlatformView()
    {
        return new GlassPlatformView(null);
    }

    protected override void ConnectHandler(GlassPlatformView platformView)
    {
        base.ConnectHandler(platformView);
    }

    protected override void DisconnectHandler(GlassPlatformView platformView)
    {
        base.DisconnectHandler(platformView);
    }
}