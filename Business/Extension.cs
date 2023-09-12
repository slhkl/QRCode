using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace Business
{
    public static class Extension
    {
        public static string ConvertToQRImage(this string value)
        {
            return Convert.ToBase64String(value.ConvertToQR());
        }

        public static byte[] ConvertToQR(this string value)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            Bitmap qrDrawer = qrCode.GetGraphic(60);

            using MemoryStream ms = new MemoryStream();
            qrDrawer.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }
    }
}