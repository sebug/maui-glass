#if IOS || MACCATALYST
using PlatformView = maui_glass.Platforms.iOS.GlassPlatformView;
#elif ANDROID
using PlatformView = maui_glass.Platforms.Android.GlassPlatformView;
#elif WINDOWS
using PlatformView = maui_glass.Platforms.iOS.GlassPlatformView;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID)
using PlatformView = System.Object;
#endif
using maui_glass.Controls;
using Microsoft.Maui.Handlers;

namespace maui_glass.Handlers;

public partial class GlassControlHandler
{
    public static IPropertyMapper<IGlassControl, GlassControlHandler> PropertyMapper =
        new PropertyMapper<IGlassControl, GlassControlHandler>(ViewHandler.ViewMapper)
        {
            [nameof(IGlassControl.StatusText)] = MapStatusText
        };

    public static CommandMapper<IGlassControl, GlassControlHandler> CommandMapper =
        new(ViewCommandMapper)
        {
            [nameof(IGlassControl.StartVideo)] = MapStartVideo
        };

    public GlassControlHandler(): base(PropertyMapper, CommandMapper)
    {

    }

    public static void MapStatusText(GlassControlHandler handler, IGlassControl control)
    {
        handler?.PlatformView.UpdateStatusText();
    }

    private static void MapStartVideo(GlassControlHandler handler, IGlassControl control, object? arg3)
    {
        handler?.PlatformView.StartVideo();
    }
}