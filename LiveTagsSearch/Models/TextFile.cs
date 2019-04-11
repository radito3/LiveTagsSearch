using System.IO;

namespace LiveTagsSearch.Models
{
    public class TextFile : AbstractRenderableFile
    {
        private readonly string _content;
        
        public override string Type => "text";
        public override string Content => _content;
        public override string IconPath => "assets/txt-file-icon.png";
        
        public TextFile(string name) : base(name)
        {
            _content = File.ReadAllText(name);
        }
    }
}
