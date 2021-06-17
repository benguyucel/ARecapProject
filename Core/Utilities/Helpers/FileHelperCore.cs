using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public  static class  FileHelperBase 
    {
        public static IFormFile file { get; set; }
        public static IFormFile GetFile()
        {
            return file;
        }

    }
}
