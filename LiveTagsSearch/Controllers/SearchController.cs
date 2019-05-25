using System.Collections.Generic;
using System.IO;
using System.Linq;
using LiveTagsSearch.Models;
using LiveTagsSearch.Util;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace LiveTagsSearch.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        
        [HttpGet("[action]")]
        public IEnumerable<IFile> Files([FromQuery] string route, [FromQuery] string searchType, [FromQuery] string value)
        {
            if (string.IsNullOrEmpty(searchType))
                return AllFiles(route);

            return searchType.Equals("Name") ? 
                AllFiles(route).Where(f => f.Name.Contains(value)) 
                : AllFiles(route).Where(f => f.Tags.Any(tag => tag.Contains(value)));
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

        [HttpPost("[action]")]
        public void EditTags([FromBody] object body)
        {
            JObject.FromObject(body).TryGetValue("tags", out var tags);
            JObject.FromObject(body).TryGetValue("name", out var name);
            var fileTags = tags?.Values<string>().ToArray();
            var fileName = name?.Value<string>();
            var fullPath = Path.GetFullPath(fileName);
            
            FileEditor.WriteToFile(fullPath, fileTags);
        }

        [NonAction]
        private static IEnumerable<IFile> AllFiles(string route)
        {
            return ActionProvider<string, string>.GetFilesDirectories(route)
                .Select(FileFactory.GetFile)
                .MapWithTags();
        }
    }
}