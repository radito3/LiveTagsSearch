namespace LiveTagsSearch.Models
{
    public abstract class AbstractRenderableFile : AbstractFile
    {
        public sealed override bool Renderable { get; }

        protected AbstractRenderableFile(string name) : base(name)
        {
            Renderable = true;
        }
    }
}
