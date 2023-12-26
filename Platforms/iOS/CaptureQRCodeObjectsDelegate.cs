using System.ComponentModel;
using AVFoundation;
using maui_glass.Controls;
using SystemConfiguration;

namespace maui_glass.Platforms.iOS;

public class CaptureQRCodeObjectsDelegate : AVCaptureMetadataOutputObjectsDelegate
{
    public event EventHandler<QRCodeChangedEventArgs>? QRCodeChanged;
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
                QRCodeChanged?.Invoke(this, new QRCodeChangedEventArgs() {
                    QRCode = mr.StringValue
                });
            }
        }
    }
}

public class QRCodeChangedEventArgs
{
    public string QRCode { get; set; }
}