using System.Collections.Generic;
using System.IO;
using System.Linq;
using LiveTagsSearch.Models;
using Microsoft.AspNetCore.Mvc;

namespace LiveTagsSearch.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
//        private string CurrentDirectory = "./";
        private static IDictionary<int, IList<string>> fileTagsTable = new Dictionary<int, IList<string>>();
        
        [HttpGet("File/{name}")]
        public FileModel GetFile([FromRoute] string name)
        {
            //should get to whole route of the file from the http parameters
            return new FileModel(name);
        }

        [HttpGet("[action]")]
        public IEnumerable<FileModel> Files([FromQuery] string route, [FromQuery] string searchType, [FromQuery] string value)
        {
            if (string.IsNullOrEmpty(searchType))
                return AllFiles(route);

            return AllFiles(route)
                .Where(f => searchType.Equals("Name") ? f.Name.Contains(value) : f.Tags.Contains(value)); 
        }

        [NonAction]
        private static IEnumerable<FileModel> AllFiles(string route)
        {
            string[] files = Directory.GetFiles(route);
            string[] dirs = Directory.GetDirectories(route);
            return Combine(files, dirs).Select(f => new FileModel(f));
        }
        
        [NonAction]
        private static T[] Combine<T>(params IEnumerable<T>[] items) => items.SelectMany(i => i).Distinct().ToArray();
    }
}