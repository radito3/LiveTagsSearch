using System.IO;

namespace LiveTagsSearch.Models
{
    public class TextFile : AbstractRenderableFile
    {
        public override string Type => "text";
        public override string Content { get; protected set; }
        public override string IconPath => "assets/txt-file-icon.png";
        
        public TextFile(string name) : base(name)
        {
            Content = File.ReadAllText(name);
        }
    }
}
