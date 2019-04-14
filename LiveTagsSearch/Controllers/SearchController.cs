using System.Collections.Generic;
using System.IO;
using System.Linq;
using LiveTagsSearch.Models;
using LiveTagsSearch.Util;
using Microsoft.AspNetCore.Mvc;

namespace LiveTagsSearch.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        
        //will be moved
        private static IDictionary<string, IList<string>> fileTagsTable = new Dictionary<string, IList<string>>();
        
        //will be deleted
        [HttpGet("File/{name}")]
        public IFile GetFile([FromRoute] string name)
        {
            //should get to whole route of the file from the http parameters
            return FileFactory.GetFile(name);
        }

        //may modify
        [HttpGet("[action]")]
        public IEnumerable<IFile> Files([FromQuery] string route, [FromQuery] string searchType, [FromQuery] string value)
        {
            if (string.IsNullOrEmpty(searchType))
                return AllFiles(route);

            return AllFiles(route)
                .Where(f => searchType.Equals("Name") ? f.Name.Contains(value) : f.Tags.Contains(value)); 
        }

        [HttpGet("[action]")]
        public bool HasRoot([FromQuery] string route)
        {
            return new DirectoryInfo(route).Parent != null;
        }

        [HttpGet("[action]")]
        public IEnumerable<string> FolderName([FromQuery] string route)
        {
            return new [] { new DirectoryInfo(route).Name };
        }

        [HttpGet("[action]")]
        public IEnumerable<string> Subfolders([FromQuery] string route)
        {
            return new DirectoryInfo(route).GetDirectories().Select(dir => dir.Name);
        }

        [NonAction]
        private static IEnumerable<IFile> AllFiles(string route)
        {
            return ActionProvider<string, string>.GetFilesDirectories(route).Select(FileFactory.GetFile);
        }
    }
}