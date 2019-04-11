namespace LiveTagsSearch.Models
{
    public class OthFile : AbstractNonRenderableFile
    {
        public override string Type => "other";
        public override string IconPath => "assets/file-icon.png";
        
        public OthFile(string name) : base(name)
        {
        }
    }
}
