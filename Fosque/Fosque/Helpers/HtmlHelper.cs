using System;
namespace Fosque.Helpers
{
    public class HtmlHelper
    {
        public static string getHtml(string image,int ancho,int alto)
        {
            var anchoformal = ancho;
            var division = alto / 3;
            var altoformal = division + division - 30;
            string html = "";
            return  html = "<!DOCTYPE html><html><head><meta name='viewport' content='width=device-width, initial-scale=1'><style> .imgcontainer {text-align:center;}</style></head><body><div class='imgcontainer'><img src = " + image + " alt='ejercicios' height="+altoformal+"/></div></body></html>";

        }


    }
}
