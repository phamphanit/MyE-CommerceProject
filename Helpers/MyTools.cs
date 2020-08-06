using System;
using System.IO;

namespace FinalProject.MyTools
{
    public class MyTools
    {
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
