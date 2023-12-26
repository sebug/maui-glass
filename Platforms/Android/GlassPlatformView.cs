using Android.Content;
using Android.Runtime;
using Android.Util;
using View = Android.Views.View;

namespace maui_glass.Platforms.Android;

public class GlassPlatformView : View
{
    public GlassPlatformView(Context? context) : base(context)
    {
    }

    public GlassPlatformView(Context? context, IAttributeSet? attrs) : base(context, attrs)
    {
    }

    public GlassPlatformView(Context? context, IAttributeSet? attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
    {
    }

    public GlassPlatformView(Context? context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
    {
    }

    protected GlassPlatformView(nint javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
    {
    }

    public void UpdateStatusText()
    {

    }

    public void StartVideo()
    {
        
    }
}