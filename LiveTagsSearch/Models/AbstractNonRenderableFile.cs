namespace LiveTagsSearch.Models
{
    public class AbstractNonRenderableFile : AbstractFile
    {
        public override string Content { get; }
        public override bool Renderable { get; }
        
        public AbstractNonRenderableFile(string name) : base(name)
        {
            Content = null;
            Renderable = false;
        }
    }
}
