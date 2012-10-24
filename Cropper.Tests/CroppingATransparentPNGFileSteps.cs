using System;
using System.Drawing;
using Shouldly;
using TechTalk.SpecFlow;

namespace Cropper.Tests
{
    [Binding]
    public class CroppingATransparentPNGFileSteps
    {
        [Given(@"I have a PNG file with transparency named ""(.*)""")]
        public void GivenIHaveAPNGFileWithTransparencyNamed(string fileName)
        {
          Bitmap bitmap = new Bitmap(fileName);
          ScenarioContext.Current["image"] = bitmap;
        }
        
        [When(@"I crop the transparency")]
        public void WhenICropTheTransparency()
        {
          ScenarioContext.Current["image"] = new CroppingThing().Crop((Bitmap)ScenarioContext.Current["image"]);
        }
        
        [Then(@"the result should be like ""(.*)""")]
        public void ThenTheResultShouldBeLike(string fileName)
        {
          Bitmap expected = new Bitmap(fileName);

          Bitmap actual = (Bitmap)ScenarioContext.Current["image"];

          actual.Width.ShouldBe(expected.Width);
          actual.Height.ShouldBe(expected.Height);

          for (int i = 0; i < actual.Width; i++)
          {
            for (int j = 0; j < actual.Height; j++)
            {
              actual.GetPixel(i, j).ShouldBe(expected.GetPixel(i, j));
            }
          }
        }
    }
}
