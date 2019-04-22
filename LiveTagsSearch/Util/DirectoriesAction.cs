using System.IO;

namespace LiveTagsSearch.Util
{
    internal class DirectoriesAction : ActionProvider<string, string[]>
    {
        public override string[] Action(string path)
        {
            return Directory.GetDirectories(path);
        }
    }    
}
