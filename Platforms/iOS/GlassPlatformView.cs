using AVFoundation;
using CoreFoundation;
using CoreGraphics;
using Foundation;
using maui_glass.Controls;
using ObjCRuntime;
using UIKit;

namespace maui_glass.Platforms.iOS;

public class GlassPlatformView : UIView
{
    private AVCaptureSession _captureSession;
    private AVCaptureVideoPreviewLayer _videoPreviewLayer;
    private UIView? _frameView;

    public GlassPlatformView(IGlassControl glassControl)
    {
        _captureSession = new AVCaptureSession();

        var captureDevice = AVCaptureDevice.GetDefaultDevice(
            AVCaptureDeviceType.BuiltInWideAngleCamera,
            AVMediaTypes.Video,
            position: AVCaptureDevicePosition.Back
        );

        NSError error;
        var videoInput = new AVCaptureDeviceInput(captureDevice, out error);

        _captureSession.AddInput(videoInput);
        _videoPreviewLayer = new AVCaptureVideoPreviewLayer(_captureSession);
        _videoPreviewLayer.VideoGravity = AVLayerVideoGravity.ResizeAspectFill;
        _videoPreviewLayer.Frame = this.Layer.Bounds;
        this.Layer.AddSublayer(_videoPreviewLayer);

        DispatchQueue.GetGlobalQueue(service: DispatchQualityOfService.Background).DispatchAsync(() => {
            _captureSession.StartRunning();
        });
    }

    public void UpdateStatusText()
    {

    }

    public void StartVideo()
    {

    }
}