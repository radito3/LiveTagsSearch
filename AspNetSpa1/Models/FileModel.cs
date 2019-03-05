using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.StaticFiles;

namespace AspNetSpa1.Models
{
    public class FileModel
    {
        public string Name { get; }
        public string IconPath { get; }
        public bool Renderable { get; }
//        public FileStream Content { get; }
        public List<string> Tags { get; }

        public static Dictionary<string, string> fileIcons = new Dictionary<string, string>
        {
            {"text/plain", "Content/txt-file-icon.png"},
            {"image", "Content/picture-icon.png"},
            {"application/octet-stream", "Content/exe-file-icon.png"},
            {"other", "Content/file-icon.png"},
            {"dir", "Content/directory-icon.png"}
        };

        public FileModel(string name)
        {
            Name = name.Substring(name.LastIndexOf('/') + 1);
            string iconPathTemp;
            if (File.GetAttributes(name).HasFlag(FileAttributes.Directory))
                fileIcons.TryGetValue("dir", out iconPathTemp);
            else
//            {
//                Content = File.OpenRead(name);
                iconPathTemp = EvaluateIcon(_getMimeType(name));
//            }
            IconPath = iconPathTemp;
            Tags = new List<string>();
            Renderable = IsRenderable();
        }

        private string EvaluateIcon(string val)
        {
            if (fileIcons.TryGetValue(val, out var result)) 
                return result;
            
            if (val.StartsWith("image"))
                fileIcons.TryGetValue("image", out result);
            else
                fileIcons.TryGetValue("other", out result);
            
            return result;
        }

        public void AddTag(string tag) => Tags.Add(tag);

        public void DeleteTag(string tag) => Tags.Remove(tag);

        public bool IsRenderable()
        {
            var type = _getMimeType(Name);
            return type.StartsWith("text") || type.StartsWith("image");
        }

        private static string _getMimeType(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();
            if(!provider.TryGetContentType(fileName, out var contentType))
                contentType = "application/octet-stream";
            return contentType;
        }
        
        public override int GetHashCode()
        {
            return Name.GetHashCode() +
                   IconPath.GetHashCode();/* +
                   Content?.GetHashCode() ?? 0;*/
        }
    }
}