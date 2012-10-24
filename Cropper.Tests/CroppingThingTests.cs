using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Cropper.Tests
{
  [TestClass]
  public class CroppingThingTests
  {
    [TestMethod]
     public void Crop_NullArgument_ThrowsArgumentNullException()
    {
      var croppingThing = new CroppingThing();

      Should.Throw<ArgumentNullException>(() => croppingThing.Crop(null));
    }
  }
}