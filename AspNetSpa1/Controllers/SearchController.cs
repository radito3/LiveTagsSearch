using System.Collections.Generic;
using System.IO;
using System.Linq;
using AspNetSpa1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetSpa1.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private string CurrentDirectory = "./";
        private static IDictionary<int, IList<string>> fileTagsTable = new Dictionary<int, IList<string>>();
        
//        [HttpGet("[action]")]
//        public IEnumerable<FileModel> Files()
//        {
//            string[] files = Directory.GetFiles(CurrentDirectory);
//            string[] dirs = Directory.GetDirectories(CurrentDirectory);
//            //don't know if there needs to be more in this method
//            return Combine(files, dirs).Select(f => new FileModel(f));
//        }

        [HttpGet("file/{name}")]
        public FileModel GetFile([FromRoute] string name)
        {
            //should get to whole route of the file from the http parameters
            return new FileModel(name);
        }

        [HttpGet("[action]")]
        public IEnumerable<FileModel> Files([FromQuery] string route, [FromQuery] string searchType, [FromQuery] string value)
        {
//            var rr = route.Equals("undefined") ? CurrentDirectory : route;
            string[] files = Directory.GetFiles(route);
            string[] dirs = Directory.GetDirectories(route);
            return Combine(files, dirs).Select(f => new FileModel(f));
        }

        //when returning image content -> System.Convert.ToBase64String(image)
        
        [NonAction]
        private static T[] Combine<T>(params IEnumerable<T>[] items) => items.SelectMany(i => i).Distinct().ToArray();
    }
}