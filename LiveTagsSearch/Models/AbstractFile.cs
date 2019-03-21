using System.Collections.Generic;
using Microsoft.AspNetCore.StaticFiles;

namespace LiveTagsSearch.Models
{
    public abstract class AbstractFile : IFile
    {
        public virtual string Name { get; }
        public virtual string Icon { get; }
        public virtual string Type { get; }
        public virtual string Content { get; }
        public virtual IEnumerable<string> Tags { get; }

        public AbstractFile(string name)
        {
            //TODO make model files structure to include inheritance and polymorphism
            //must include the 2 different file models needed for the angular app
        }
        
        public abstract bool IsRenderable();
        public abstract void AddTag(string tag);
        public abstract void DeleteTag(string tag);

        protected string _getMimeType(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();
            if(!provider.TryGetContentType(fileName, out var contentType))
                contentType = "application/octet-stream";
            return contentType;
        }
    }
}