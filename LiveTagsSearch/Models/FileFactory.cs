using System.IO;
using LiveTagsSearch.Util;

namespace LiveTagsSearch.Models
{
    public static class FileFactory
    {
        public static IFile GetFile(string name)
        {
            switch (_getMimeType(name).Split('/')[0]) 
            {
                case "text":
                    return new TextFile(name);
                case "image":
                    return new ImageFile(name);
                case "dir":
                    return new DirFile(name);
                case "application":
                    return new ExeFile(name);
                default:
                    return new OthFile(name);
            }
        }
        
        private static string _getMimeType(string fileName)
        {
            ActionProvider<string, string> fileExt = new MimeExtensionProvider();
            return File.GetAttributes(fileName).HasFlag(FileAttributes.Directory) ? "dir/" : fileExt.Action(fileName);
        }
    }
}
