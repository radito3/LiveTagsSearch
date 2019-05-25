namespace LiveTagsSearch.Models
{
    public class DirFile : AbstractNonRenderableFile
    {
        public override string Type => "dir";
        public override string IconPath => "assets/directory-icon.png";
        
        public DirFile(string name) : base(name)
        {
            Tags.Add("dir");
        }
    }
}
