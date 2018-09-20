using System;
using System.IO;
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
                string baseIamge = "data:image/jpeg;base64,";
                int Lengthfile = baseIamge.Length;
                string stringfile = file.Substring(Lengthfile);
                var result = ImageSource.FromStream(
                    () => new MemoryStream(Convert.FromBase64String(stringfile)));
                image = result;
            }
            return image;
        }
    }
}
