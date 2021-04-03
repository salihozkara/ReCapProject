using System;
using System.IO;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System.Windows;

namespace Core.Utilities.Business
{
    public static class FileHelper
    {
        private static string fullPath = Path.Combine(Environment.CurrentDirectory, "wwwroot");
        public static IResult Upload(IFormFile file,string path)
        {
            var result = BusinessRules.Run(
                CheckFileExists(file));
            if (result!=null)
            {
                return result;
            }

            string fileName = Guid.NewGuid().ToString("D") + Path.GetExtension(file.FileName).ToLower();
            var filePath = Path.Combine(fullPath, path, fileName);
            CheckDirectoryExists(Path.Combine(fullPath,path));
            CreateFile(filePath,file);
            return new SuccessResult(Path.Combine(path, fileName).Replace("\\", "/"));
        }
        
        private static IResult CheckFileExists(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("File doesn't exists.");
        }
        private static void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
        private static void CreateFile(string directory, IFormFile file)
        {
            using (FileStream fs = File.Create(directory))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }

        public static void Delete(string directory)
        {
            if (File.Exists(directory.Replace("/", "\\")))
            {
                File.Delete(directory.Replace("/", "\\"));
            }

        }
    }
}