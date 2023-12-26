using AVFoundation;

namespace maui_glass.Platforms.iOS;

public class CaptureQRCodeObjectsDelegate : AVCaptureMetadataOutputObjectsDelegate
{
    private readonly Action<string> OnFoundQRCode;

    public CaptureQRCodeObjectsDelegate(Action<string> onFoundQRCode)
    {
        this.OnFoundQRCode = onFoundQRCode;
    }

    public override void DidOutputMetadataObjects(AVCaptureMetadataOutput captureOutput, AVMetadataObject[] metadataObjects, AVCaptureConnection connection)
    {
        if (metadataObjects != null && metadataObjects.Length > 0)
        {
            if (metadataObjects[0] is AVMetadataMachineReadableCodeObject)
            {
                var mr = (AVMetadataMachineReadableCodeObject)metadataObjects[0];
                OnFoundQRCode(mr.StringValue);
            }
        }
    }
}