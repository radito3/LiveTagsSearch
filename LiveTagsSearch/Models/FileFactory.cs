using System.IO;

namespace LiveTagsSearch.Models
{
    public static class FileFactory
    {
        public static IFile GetFile(string name)
        {
            switch (_getMimeType(name).Split('/')[0]) 
            {
                    case "text":
                        //this must include json, xml, java, txt, ...
                        return new TextFile(name);
                    case "image":
                        //png, jpeg, ...
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
            //the default asp net core file extension type provider is shit
            //TODO make my own
//            var provider = new FileExtensionContentTypeProvider();
//            if(!provider.TryGetContentType(fileName, out var contentType))
//                contentType = "application/octet-stream";
            
            //temporary
            return File.GetAttributes(fileName).HasFlag(FileAttributes.Directory) ? "dir/" : 
                fileName.EndsWith("txt") || fileName.EndsWith("json") || fileName.EndsWith("cs") ? "text/" : 
                fileName.EndsWith("png") ? "image/" : "oth/";
        }
    }
}
