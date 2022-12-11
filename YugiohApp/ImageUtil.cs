using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Login
{
    public class ImageUtil
    {
        public static Image ResizeImage(Image imgToResize, int newWidth, int newHeight)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)newWidth / (float)sourceWidth);
            nPercentH = ((float)newHeight / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }

        public static void saveJpeg(string path, Image img, long quality)
        {
            // Encoder parameter for image quality
            EncoderParameter qualityParam =
               new EncoderParameter(Encoder.Quality, (long)quality);

            // Jpeg image codec
            ImageCodecInfo jpegCodec = getEncoderInfo("image/jpeg");

            if (jpegCodec == null)
                return;

            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            img.Save(path, jpegCodec, encoderParams);
        }


        public static void savePNG(string path, Image img, long quality)
        {
            // Encoder parameter for image quality
            EncoderParameter qualityParam =
               new EncoderParameter(Encoder.Quality, (long)quality);

            // Jpeg image codec
            ImageCodecInfo pngCodec = getEncoderInfo("image/png");

            if (pngCodec == null)
                return;

            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            img.Save(path, pngCodec, encoderParams);
        }

        public static void saveGIF(string path, Image img, long quality)
        {
            // Encoder parameter for image quality
            EncoderParameter qualityParam =
               new EncoderParameter(Encoder.Quality, (long)quality);

            // Jpeg image codec
            ImageCodecInfo gifCodec = getEncoderInfo("image/gif");

            if (gifCodec == null)
                return;

            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            img.Save(path, gifCodec, encoderParams);
        }

        private static ImageCodecInfo getEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }
    }
}