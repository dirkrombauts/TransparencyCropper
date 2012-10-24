using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cropper
{
  class Program
  {
    static void Main(string[] args)
    {
      if (args.Length != 2)
      {
        Console.Out.WriteLine("Usage: Cropper <source directory> <target directory>");
        return;
      }

      var sourceDirectory = new System.IO.DirectoryInfo(args[0]);

      if (!sourceDirectory.Exists)
      {
        Console.Out.WriteLine("Source directory must exist");
        return;
      }

      var targetDirectory = new System.IO.DirectoryInfo(args[1]);

      if (!targetDirectory.Exists)
      {
        Console.Out.WriteLine("Target directory must exist");
        return;
      }

      var croppingThing = new CroppingThing();
      foreach (var fileInfo in sourceDirectory.EnumerateFiles("*.png", SearchOption.TopDirectoryOnly))
      {
        var bitmap = croppingThing.Crop(new Bitmap(fileInfo.FullName));

        bitmap.Save(Path.Combine(targetDirectory.FullName, fileInfo.Name), ImageFormat.Png);
      }
    }
  }
}
