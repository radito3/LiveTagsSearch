using System.Collections.Generic;

namespace AspNetSpa1.Models
{
    public abstract class AbstractFile : IFile
    {
        public abstract string Name { get; }
        public abstract string Icon { get; }
        public abstract string Type { get; }
        public abstract string Content { get; }
        public abstract IEnumerable<string> Tags { get; }

        public AbstractFile(string name)
        {
            //TODO make model files structure to include inheritance and polymorphism
        }
        
        public abstract bool IsRenderable();
        public abstract void AddTag(string tag);
        public abstract void DeleteTag(string tag);
    }
}