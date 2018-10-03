using System;
using System.IO;
using System.Text.RegularExpressions;
using Xamarin.Forms;
namespace Fosque.Helpers
{
    public class ImageConvert
    {
        public static ImageSource ConvertToBase(string file)
        {
            ImageSource image = null;
            if (!string.IsNullOrEmpty(file))
            {
                string[] lines = Regex.Split(file, "base64,");
                var result = ImageSource.FromStream(
                    () => new MemoryStream(Convert.FromBase64String(lines[1])));
                image = result;
            }
            return image;
        }
    }
}
