using System.IO;

namespace LiveTagsSearch.Util
{
    internal class FilesAction : ActionProvider<string, string[]>
    {
        protected override string[] Action(string path)
        {
            return Directory.GetFiles(path);
        }
    }
}
