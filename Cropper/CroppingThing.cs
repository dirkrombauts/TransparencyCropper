using System;
using System.Drawing;
using System.Linq;

namespace Cropper
{
  public class CroppingThing
  {
    public Bitmap Crop(Bitmap bitmap)
    {
      if (bitmap == null)
      {
        throw new ArgumentNullException("bitmap");
      }

      Bitmap oneEdgeCropped = RemoveTransparency(bitmap);
      oneEdgeCropped.RotateFlip(RotateFlipType.Rotate90FlipNone);

      Bitmap secondEdgeCropped = RemoveTransparency(oneEdgeCropped);
      secondEdgeCropped.RotateFlip(RotateFlipType.Rotate90FlipNone);

      Bitmap thirdEdgeCropped = RemoveTransparency(secondEdgeCropped);
      thirdEdgeCropped.RotateFlip(RotateFlipType.Rotate90FlipNone);

      Bitmap fourthEdgeCropped = RemoveTransparency(thirdEdgeCropped);
      fourthEdgeCropped.RotateFlip(RotateFlipType.Rotate90FlipNone);

      return fourthEdgeCropped;
    }

    private static Bitmap CropBottomTransparency(Bitmap bitmap, int newHeight)
    {
      var result = new Bitmap(bitmap.Width, newHeight);

      for (int x = 0; x < result.Width; x++)
      {
        for (int y = 0; y < result.Height; y++)
        {
          result.SetPixel(x, y, bitmap.GetPixel(x, y));
        }
      }

      return result;
    }

    private static int DetermineNewHeight(Bitmap bitmap)
    {
      int result = bitmap.Height;

      for (; result >= 0; result--)
      {
        bool nonTransparentPixelsPresent = Enumerable.Range(0, bitmap.Width).Reverse().Select(x => bitmap.GetPixel(x, result - 1).A).Any(a => a != 0);

        if (nonTransparentPixelsPresent)
        {
          break;
        }
      }

      return result;
    }

    private static Bitmap RemoveTransparency(Bitmap bitmap)
    {
      int newHeight = DetermineNewHeight(bitmap);

      if (newHeight == bitmap.Height)
      {
        return bitmap;
      }

      var result = CropBottomTransparency(bitmap, newHeight);

      return result;
    }
  }
}