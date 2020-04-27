using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
[assembly:CLSCompliant(true)]
namespace final
{
    public class Class1
    {
        public static Bitmap openimage()
        {
            OpenFileDialog ofile = new OpenFileDialog();
            ofile.Filter = "Image File(*.jpg,*.png)|*.jpg;*.png";
            if (DialogResult.OK == ofile.ShowDialog())
            {
                return new Bitmap(ofile.FileName);
            }
            return null;
        }
        public static Bitmap gray(Bitmap Image)
        {
            Bitmap gray_image = Image;
            Bitmap NewBitmap = new Bitmap(gray_image.Width, gray_image.Height);
            ImageAttributes ia = new ImageAttributes();
            ColorMatrix cmPicture = new ColorMatrix(new float[][]
                {
                new float[] {0.299f, 0.299f, 0.299f, 0, 0},
                new float[] {0.587f, 0.587f, 0.587f, 0, 0},
                new float[] {0.114f, 0.114f, 0.114f, 0, 0},
                new float[] {     0,      0,      0, 1, 0},
                new float[] {     0,      0,      0, 0, 0}
                });
            ia.SetColorMatrix(cmPicture);
            Graphics g = Graphics.FromImage(NewBitmap);
            g.DrawImage(gray_image, new Rectangle(0, 0, gray_image.Width, gray_image.Height), 0, 0, gray_image.Width, gray_image.Height, GraphicsUnit.Pixel, ia);
            g.Dispose();
            return NewBitmap;
        }
        public static Bitmap negative(Bitmap Image)
        {
            Bitmap neg_image = Image;
            Bitmap bmpInverted = new Bitmap(neg_image.Width, neg_image.Height);
            ImageAttributes ia = new ImageAttributes();
            ColorMatrix cmPicture = new ColorMatrix(new float[][]
                {
                new float[] {-1, 0, 0, 0, 0},
                new float[] {0, -1, 0, 0, 0},
                new float[] {0, 0, -1, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {1, 1, 1, 0, 1}
                });
            ia.SetColorMatrix(cmPicture);
            Graphics g = Graphics.FromImage(bmpInverted);
            g.DrawImage(neg_image, new Rectangle(0, 0, neg_image.Width, neg_image.Height), 0, 0, neg_image.Width, neg_image.Height, GraphicsUnit.Pixel, ia);
            g.Dispose();
            return bmpInverted;
        }
        public static Bitmap flip(Bitmap Image)
        {
            Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            return Image;
        }


        public static Bitmap AdjustBrightness(Bitmap Image, int Value)
        {
            Bitmap TempBitmap = Image;
            float FinalValue = (float)Value / 255.0f;
            Bitmap NewBitmap = new Bitmap(TempBitmap.Width, TempBitmap.Height);
            Graphics NewGraphics = Graphics.FromImage(NewBitmap);
            float[][] FloatColorMatrix ={
                     new float[] {1, 0, 0, 0, 0},
                     new float[] {0, 1, 0, 0, 0},
                     new float[] {0, 0, 1, 0, 0},
                     new float[] {0, 0, 0, 1, 0},
                     new float[] {FinalValue, FinalValue, FinalValue, 1, 1}
                 };

            ColorMatrix NewColorMatrix = new ColorMatrix(FloatColorMatrix);
            ImageAttributes Attributes = new ImageAttributes();
            Attributes.SetColorMatrix(NewColorMatrix);
            NewGraphics.DrawImage(TempBitmap, new Rectangle(0, 0, TempBitmap.Width, TempBitmap.Height), 0, 0, TempBitmap.Width, TempBitmap.Height, GraphicsUnit.Pixel, Attributes);
            Attributes.Dispose();
            NewGraphics.Dispose();
            return NewBitmap;
        }
        public static Bitmap Crop(Bitmap image)
        {
            Bitmap bmpImage = new Bitmap(image);
            Bitmap bmpCrop = bmpImage.Clone(new Rectangle(100, 100, 750, 750), bmpImage.PixelFormat);
            return bmpCrop;
        }
       
    }

}
