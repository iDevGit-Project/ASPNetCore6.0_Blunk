﻿using Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utilities
{
    public static class UploadImage
    {
       
        public static string SaveImage(IFormFile file, string CategoryName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory() + @"\wwwroot" + @$"\{CategoryName}\");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            IFormFile Image = file;

            string SaveName = Guid.NewGuid().ToString() + Image.FileName;
            var SavedUrl = $"/{CategoryName}/{SaveName}";

            var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", CategoryName)).Root + $@"\{SaveName}";

            using (FileStream fs = File.Create(filepath))
            {
                Image.CopyTo(fs);
                fs.Flush();
            }

            return SavedUrl;
        }

        //public static string SaveVideo(string file, string CategoryName)
        //{
        //    var path = Path.Combine(Directory.GetCurrentDirectory() + @"\wwwroot" + @$"\{CategoryName}\");
        //    if (!Directory.Exists(path))
        //        Directory.CreateDirectory(path);

        //    byte[] bytes = Convert.FromBase64String(file);
        //    MemoryStream ms = new MemoryStream(bytes);
        //    string name = "image";
        //    IFormFile Image = new FormFile(ms, 0, bytes.Length, name, name + ".mp4");

        //    string SaveName = Guid.NewGuid().ToString() + Image.FileName;
        //    var SavedUrl = $"{CategoryName}/{SaveName}";

        //    var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", CategoryName)).Root + $@"\{SaveName}";

        //    using (FileStream fs = File.Create(filepath))
        //    {
        //        Image.CopyTo(fs);
        //        fs.Flush();
        //    }

        //    return SavedUrl;
        //}

        //public static string UpdateImage(string file, string OldUrl, string CategoryName)
        //{
        //    if (File.Exists(Directory.GetCurrentDirectory() + OldUrl))
        //    {
        //        File.Delete(Directory.GetCurrentDirectory() + OldUrl);
        //    }

        //    var path = Path.Combine(Directory.GetCurrentDirectory() + @"\wwwroot" + @$"\{CategoryName}\");
        //    if (!Directory.Exists(path))
        //        Directory.CreateDirectory(path);

        //    byte[] bytes = Convert.FromBase64String(file);
        //    MemoryStream ms = new MemoryStream(bytes);
        //    string name = "image";
        //    IFormFile Image = new FormFile(ms, 0, bytes.Length, name, name + ".png");

        //    string SaveName = Guid.NewGuid().ToString() + Image.FileName;
        //    var SavedUrl = $"{CategoryName}/{SaveName}";

        //    var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", CategoryName)).Root + $@"\{SaveName}";

        //    using (FileStream fs = File.Create(filepath))
        //    {
        //        Image.CopyTo(fs);
        //        fs.Flush();
        //    }

        //    return SavedUrl;
        //}
        //public static string UpdateVideo(string file, string OldUrl, string CategoryName)
        //{
        //    if (File.Exists(Directory.GetCurrentDirectory() + OldUrl))
        //    {
        //        File.Delete(Directory.GetCurrentDirectory() + OldUrl);
        //    }

        //    var path = Path.Combine(Directory.GetCurrentDirectory() + @"\wwwroot" + @$"\{CategoryName}\");
        //    if (!Directory.Exists(path))
        //        Directory.CreateDirectory(path);

        //    byte[] bytes = Convert.FromBase64String(file);
        //    MemoryStream ms = new MemoryStream(bytes);
        //    string name = "image";
        //    IFormFile Image = new FormFile(ms, 0, bytes.Length, name, name + ".mp4");

        //    string SaveName = Guid.NewGuid().ToString() + Image.FileName;
        //    var SavedUrl = $"{CategoryName}/{SaveName}";

        //    var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", CategoryName)).Root + $@"\{SaveName}";

        //    using (FileStream fs = File.Create(filepath))
        //    {
        //        Image.CopyTo(fs);
        //        fs.Flush();
        //    }

        //    return SavedUrl;
        //}


        //public static string SaveVoice(string file, string CategoryName)
        //{
        //    var path = Path.Combine(Directory.GetCurrentDirectory() + @"\wwwroot" + @$"\{CategoryName}\");
        //    if (!Directory.Exists(path))
        //        Directory.CreateDirectory(path);

        //    byte[] bytes = Convert.FromBase64String(file);
        //    MemoryStream ms = new MemoryStream(bytes);
        //    string name = "image";
        //    IFormFile Image = new FormFile(ms, 0, bytes.Length, name, name + ".mp3");

        //    string SaveName = Guid.NewGuid().ToString() + Image.FileName;
        //    var SavedUrl = $"{CategoryName}/{SaveName}";

        //    var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", CategoryName)).Root + $@"\{SaveName}";

        //    using (FileStream fs = File.Create(filepath))
        //    {
        //        Image.CopyTo(fs);
        //        fs.Flush();
        //    }

        //    return SavedUrl;
        //}

        
    }
}
