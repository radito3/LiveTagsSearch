using System;
using System.IO;

namespace LiveTagsSearch.Models
{
    public class ImageFile : AbstractRenderableFile
    {
        public override string Content { get; protected set; }
        public override string Type => "image";
        public override string IconPath => "assets/picture-icon.png";

        public ImageFile(string name) : base(name)
        {
            Content = Convert.ToBase64String(File.ReadAllBytes(name));
        }
    }
}
