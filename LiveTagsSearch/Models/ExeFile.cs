namespace LiveTagsSearch.Models
{
    public class ExeFile : AbstractNonRenderableFile
    {
        public override string Type => "application";
        public override string IconPath => "assets/exe-file-icon.png";
        
        public ExeFile(string name) : base(name)
        {
        }
    }
}
