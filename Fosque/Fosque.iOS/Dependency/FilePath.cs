using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using Fosque.Dependency;
using Fosque.iOS.Dependency;
using Xamarin.Forms;

[assembly:Dependency(typeof(FilePath))]
namespace Fosque.iOS.Dependency
{
    public class FilePath : IFilePath
    {
        public string GetLenguages()
        {
            try
            {
                string currentUICulture = CultureInfo.CurrentUICulture.Name.ToString();
                return currentUICulture;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public string GetPath()
        {
            try
            {
                string docFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string libFolder = System.IO.Path.Combine(docFolder, "..", "Library", "Databases");

                if (!Directory.Exists(libFolder))
                {
                    Directory.CreateDirectory(libFolder);
                }

                return Path.Combine(libFolder, "fosque.db3");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
