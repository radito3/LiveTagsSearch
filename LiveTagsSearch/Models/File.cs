using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;

namespace LiveTagsSearch.Models
{
    public class File
    {
        public string Name { get; }
        public Icon Icon { get; }
        public FileStream Content { get; }
        public List<Tag> Tags { get; }

        public class Tag
        {
            public string Name { get; }
        }

        private static Dictionary<string, Icon> fileIcons = new Dictionary<string, Icon>
        {
            {"text/plain", new Icon("./Content/txt-file-icon.png")},
            {"image", new Icon("./Content/picture-icon.png")},
            {"application/octet-stream", new Icon("./Content/exe-file-icon.png")},
            {"other", new Icon("./Content/file-icon.png")}
        };

        public File(string name)
        {
            Name = name;
            Content = System.IO.File.OpenRead(name);
            string mimeType = MimeMapping.GetMimeMapping(name);
            Icon = evaluateIcon(mimeType);
            Tags = new List<Tag>();
        }

        private Icon evaluateIcon(string val)
        {
            Icon result;
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

        public void AddTag(Tag tag)
        {
            Tags.Add(tag);
        }

        public void DeleteTag(Tag tag)
        {
            Tags.Remove(tag);
        }
    }
}