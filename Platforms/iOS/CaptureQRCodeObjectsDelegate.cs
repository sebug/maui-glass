using AVFoundation;

namespace maui_glass.Platforms.iOS;

public class CaptureQRCodeObjectsDelegate : AVCaptureMetadataOutputObjectsDelegate
{
    public CaptureQRCodeObjectsDelegate()
    {
    }

    public override void DidOutputMetadataObjects(AVCaptureMetadataOutput captureOutput, AVMetadataObject[] metadataObjects, AVCaptureConnection connection)
    {
        if (metadataObjects != null && metadataObjects.Length > 0)
        {
            if (metadataObjects[0] is AVMetadataMachineReadableCodeObject)
            {
                var mr = (AVMetadataMachineReadableCodeObject)metadataObjects[0];
            }
        }
    }
}