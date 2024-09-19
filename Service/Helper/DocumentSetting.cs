﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helper
{
    public class DocumentSetting
    {
        public static string UploadFile(IFormFile file,string folderName)
        {
            //var folderPath = "D:\\visual Studio 2022\\MVC\\Company.Web\\wwwroot\\Files\\Images\\";

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName);
            var fileName = $"{Guid.NewGuid()}{}-{file.FileName}";
            var filePath = Path.Combine(folderPath, fileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);
            return fileName;

        }
    }
}
