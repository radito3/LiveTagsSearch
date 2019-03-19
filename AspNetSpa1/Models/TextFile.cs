namespace AspNetSpa1.Models
{
    public class TextFile : AbstractFile
    {
        public override string Name { get; }
        
        public TextFile(string name) : base(name)
        {
        }

        public override bool IsRenderable()
        {
            throw new System.NotImplementedException();
        }

        public override void AddTag(string tag)
        {
            throw new System.NotImplementedException();
        }

        public override void DeleteTag(string tag)
        {
            throw new System.NotImplementedException();
        }
    }
}