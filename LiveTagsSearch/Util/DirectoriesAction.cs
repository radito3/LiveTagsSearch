using System.IO;

namespace LiveTagsSearch.Util
{
    internal class DirectoriesAction : ActionProvider<string, string[]>
    {
        protected override string[] Action(string path)
        {
            return Directory.GetDirectories(path);
        }
    }    
}
