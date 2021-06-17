using Core.Utilities.Business;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        private static string filePath = Environment.CurrentDirectory + "\\wwwroot\\uploads\\";
        public static string Upload(IFormFile file)
        {

            string fileName = GetNewName(file);
            using (var fileStream = System.IO.File.Create(filePath + fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
                return fileName;

            }
        }

        private static string ImageFilePath()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads\\");
            return path;
        }

        public static void Delete(string fileName)
        {
            File.Delete(ImageFilePath() + fileName);
        }
   
        private static string GetNewName(IFormFile file)
        {
            string _file = Path.GetFileNameWithoutExtension(file.FileName);
            string newName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string newPath = _file.Replace(_file, newName);
            return newPath;
        }


        public static string Update(IFormFile file, string oldPath)
        {
            var result = Upload(file);
            Delete(oldPath);
            return result;
        }
    }
}

