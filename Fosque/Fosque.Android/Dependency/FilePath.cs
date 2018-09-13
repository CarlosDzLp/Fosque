﻿using System;
using System.Diagnostics;
using Fosque.Dependency;
using Fosque.Droid.Dependency;
using Xamarin.Forms;

[assembly: Dependency(typeof(FilePath))]
namespace Fosque.Droid.Dependency
{
    public class FilePath : IFilePath
    {
        public string GetPath()
        {
            try
            {
                var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                return System.IO.Path.Combine(path, "fosque.db3");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
