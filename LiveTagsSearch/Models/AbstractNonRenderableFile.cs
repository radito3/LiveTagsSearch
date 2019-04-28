namespace LiveTagsSearch.Models
{
    public class AbstractNonRenderableFile : AbstractFile
    {
        public sealed override string Content { get; protected set; }
        public sealed override bool Renderable { get; }
        
        public AbstractNonRenderableFile(string name) : base(name)
        {
            Content = null;
            Renderable = false;
        }
    }
}
