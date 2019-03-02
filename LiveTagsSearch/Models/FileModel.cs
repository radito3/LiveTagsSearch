using System.Collections.Generic;
using System.IO;
using System.Web;

namespace LiveTagsSearch.Models
{
    public class FileModel
    {
        public string Name { get; }
        public string IconPath { get; }
        public FileStream Content { get; }
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
            if (System.IO.File.GetAttributes(name).HasFlag(FileAttributes.Directory))
                fileIcons.TryGetValue("dir", out iconPathTemp);
            else
            {
                Content = System.IO.File.OpenRead(name);
                iconPathTemp = EvaluateIcon(MimeMapping.GetMimeMapping(name));
            }
            IconPath = iconPathTemp;
            Tags = new List<string>();
        }

        private string EvaluateIcon(string val)
        {
            string result;
            if (fileIcons.TryGetValue(val, out result)) 
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
            var type = MimeMapping.GetMimeMapping(Name);
            return type.StartsWith("text") || type.StartsWith("image");
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() +
                   IconPath.GetHashCode() +
                   Content?.GetHashCode() ?? 0;
        }
    }
}