using System.Collections.Generic;
using System.IO;
using System.Web;

namespace LiveTagsSearch.Models
{
    public class File
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
            {"other", "Content/file-icon.png"}
        };

        public File(string name)
        {
            Name = name;
            Content = System.IO.File.OpenRead(name);
            IconPath = EvaluateIcon(MimeMapping.GetMimeMapping(name));
            Tags = new List<string>();
        }

        private string EvaluateIcon(string val)
        {
            string result;
            if (fileIcons.TryGetValue(val, out result)) return result;
            
            if (val.StartsWith("image"))
            {
                fileIcons.TryGetValue("image", out result);
            }
            else
            {
                fileIcons.TryGetValue("other", out result);
            }
            return result;
        }

        public void AddTag(string tag)
        {
            Tags.Add(tag);
        }

        public void DeleteTag(string tag)
        {
            Tags.Remove(tag);
        }

        public bool IsRenderable()
        {
            var type = MimeMapping.GetMimeMapping(Name);
            return type.StartsWith("text") || type.StartsWith("image");
        }
    }
}