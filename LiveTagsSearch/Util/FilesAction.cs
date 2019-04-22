using System.IO;

namespace LiveTagsSearch.Util
{
    internal class FilesAction : ActionProvider<string, string[]>
    {
        public override string[] Action(string path)
        {
            return Directory.GetFiles(path);
        }
    }
}
