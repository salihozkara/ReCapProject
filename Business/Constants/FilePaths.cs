using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class FilePaths
    {
        public static string ImageDefaultPath = "\\Images\\NotImage.jpg";
        public static string ImageDirectoryPath = AppDomain.CurrentDomain.BaseDirectory + "\\Images\\";
        public static string ImageDynamicDirectoryPath = AppDomain.CurrentDomain.DynamicDirectory + "\\Images\\";
    }
}
