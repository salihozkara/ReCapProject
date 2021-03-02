using System;
using System.IO;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System.Windows;

namespace Core.Utilities.Business
{
    public class FileUpload
    {
        public static IResult Upload(IFormFile file,string path)
        {
            var type = Path.GetExtension(file.FileName);
            var result=BusinessRules.Run(
                CheckFileExists(file));
            if (result!=null)
            {
                return result;
            }
            string GuidKey = Guid.NewGuid().ToString();
            CheckDirectoryExists(path);
            CreateImageFile(path+GuidKey+type,file);
            return new SuccessResult((path + GuidKey + type).Replace("\\", "/"));
        }

        public static IResult Update(IFormFile file, string imagePath)
        {
            var type = Path.GetExtension(file.FileName);
            var result = BusinessRules.Run(
                CheckFileExists(file));
            if (result != null)
            {
                return result;
            }
            string GuidKey = Guid.NewGuid().ToString();
            DeleteOldImageFile(imagePath);
            CheckDirectoryExists(imagePath);
            CreateImageFile(imagePath + GuidKey + type, file);
            return new SuccessResult((imagePath + GuidKey + type).Replace("\\", "/"));
        }

        private static IResult CheckFileExists(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("File doesn't exists.");
        }
        private static IResult CheckFileTypeValid(string type)
        {
            if (type != ".jpeg" && type != ".png" && type != ".jpg")
            {
                return new ErrorResult("Wrong file type.");
            }
            return new SuccessResult();
        }
        private static void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
        private static void CreateImageFile(string directory, IFormFile file)
        {
            using (FileStream fs = File.Create(directory))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }

        private static void DeleteOldImageFile(string directory)
        {
            if (File.Exists(directory.Replace("/", "\\")))
            {
                File.Delete(directory.Replace("/", "\\"));
            }

        }
    }
}