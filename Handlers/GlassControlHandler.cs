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

namespace maui_glass.Handlers;

public partial class GlassControlHandler
{

}