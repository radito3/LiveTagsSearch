using System.Collections.Generic;
using System.IO;

namespace LiveTagsSearch.Models
{
    public abstract class AbstractFile : IFile
    {
        public virtual string Name { get; }
        public virtual string IconPath { get; }
        public virtual string Type { get; }
        public virtual string Content { get; }
        public virtual ICollection<string> Tags { get; }
        public virtual bool Renderable { get; }

        //this will be written in the log file
        protected readonly string _fullPath;

        protected AbstractFile(string name)
        {
            Name = name.Substring(name.LastIndexOf('/') + 1);
            Tags = new List<string>();
            _fullPath = Path.GetFullPath(name);
        }
        
        //TODO figure out how the tag system will work - with only the info in the log file or with a cached collection of files
        public void AddTag(string tag) => Tags.Add(tag);

        public void DeleteTag(string tag) => Tags.Remove(tag);
    }
}
