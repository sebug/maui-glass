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

    private IGlassControl _control;

    public GlassPlatformView(IGlassControl glassControl)
    {
        _control = glassControl;
        _captureSession = new AVCaptureSession();

        var captureDevice = AVCaptureDevice.GetDefaultDevice(
            AVCaptureDeviceType.BuiltInWideAngleCamera,
            AVMediaTypes.Video,
            position: AVCaptureDevicePosition.Back
        );

        NSError error;
        var videoInput = new AVCaptureDeviceInput(captureDevice, out error);

        _captureSession.AddInput(videoInput);

        var captureMetadataOutput = new AVCaptureMetadataOutput();
        _captureSession.AddOutput(captureMetadataOutput);
        captureMetadataOutput.MetadataObjectTypes = AVMetadataObjectType.QRCode;
        var capturedQRCodesDelegate = new CaptureQRCodeObjectsDelegate(qrCode =>
        {
            this._control.StatusText = qrCode;
        });

        captureMetadataOutput.SetDelegate(capturedQRCodesDelegate, DispatchQueue.MainQueue);


        _videoPreviewLayer = new AVCaptureVideoPreviewLayer(_captureSession);
        _videoPreviewLayer.VideoGravity = AVLayerVideoGravity.ResizeAspectFill;
        
        var scale = UIScreen.MainScreen.Scale;
        var width = UIScreen.MainScreen.Bounds.Width * 2;
        var height = UIScreen.MainScreen.Bounds.Height * 2;
        _frameView = new UIView()
        {
            Frame = new CGRect(0f, 0f, width, height)
        };
        _videoPreviewLayer.Bounds = _frameView.Bounds;

        _frameView.Layer.AddSublayer(_videoPreviewLayer);

        this.Add(_frameView);

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