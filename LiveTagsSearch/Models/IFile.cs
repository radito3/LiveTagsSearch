using System.Collections.Generic;

namespace LiveTagsSearch.Models
{
    public interface IFile
    {
        string Name { get; }
        string IconPath { get; }
        string Type { get; }
        string Content { get; }
        ICollection<string> Tags { get; set; }
        bool Renderable { get; }
    }
}
