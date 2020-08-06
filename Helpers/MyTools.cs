using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FinalProject.Models;
using Microsoft.AspNetCore.Http;

namespace FinalProject.Helpers
{
    public class MyTools
    {
        public static async Task<string> ProcessUploadHinh(IFormFile hinh, string folder)
        {
            string fileName = string.Empty;
            var fName = Path.Combine(FullPathFolderName, folder, hinh.FileName);
            using (var file = new FileStream(fName, FileMode.Create))
            {
                await hinh.CopyToAsync(file);
                fileName = hinh.FileName;
            }
            return fileName;

        }
        public static string FullPathFolderName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh");
        public static string NoImage = "noimage.jpg";
        public static string CheckImageExist(string fileName, string folder)
        {
            if (File.Exists(Path.Combine(FullPathFolderName, folder, fileName)))
            {
                return $"{folder}/{fileName}";
            }

            return NoImage;
        }
        public static List<PagingModel> Pages
        {
            get
            {
                return new List<PagingModel>()
                {
                    new PagingModel{Value = 10, Text ="10"},
                    new PagingModel{Value = 20, Text ="20"},
                    new PagingModel{Value = 50, Text ="50"},

                    new PagingModel{Value = 100, Text ="100"},
                };
            }
        }
    }
}
