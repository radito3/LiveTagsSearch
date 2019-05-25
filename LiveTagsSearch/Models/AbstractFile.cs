using System.Collections.Generic;
using System.IO;

namespace LiveTagsSearch.Models
{
    public abstract class AbstractFile : IFile
    {
        public virtual string Name { get; }
        public virtual string IconPath { get; }
        public virtual string Type { get; }
        public virtual string Content { get; protected set; }
        public virtual ICollection<string> Tags { get; set; }
        public virtual bool Renderable { get; }

        //this will be written in the log file
        protected readonly string _fullPath;

        protected AbstractFile(string name)
        {
            Name = name.Substring(name.LastIndexOf('/') + 1);
            Tags = new List<string>();
            _fullPath = Path.GetFullPath(name);
        }
    }
}
