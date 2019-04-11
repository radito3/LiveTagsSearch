namespace LiveTagsSearch.Models
{
    public abstract class AbstractRenderableFile : AbstractFile
    {
        public override bool Renderable { get; }

        protected AbstractRenderableFile(string name) : base(name)
        {
            Renderable = true;
        }
    }
}
