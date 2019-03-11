using System.Collections.Generic;

namespace AspNetSpa1.Models
{
    public interface IFile
    {
        string Name { get; }
        string Icon { get; }
        string Type { get; }
        string Content { get; }
        IEnumerable<string> Tags { get; }
        
        bool IsRenderable();
        void AddTag(string tag);
        void DeleteTag(string tag);
    }
}