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
        
        [HttpGet("[action]")]
        public IEnumerable<FileModel> Files()
        {
            string[] files = Directory.GetFiles(CurrentDirectory);
            string[] dirs = Directory.GetDirectories(CurrentDirectory);
            //don't know if there needs to be more in this method
            return Combine(files, dirs).Select(f => new FileModel(f));
        }

        [HttpGet("[action]")]
        public string RootPath()
        {
            return Directory.GetCurrentDirectory();
        }
        
        //when returning image content -> System.Convert.ToBase64String(image)
        
        [NonAction]
        private static T[] Combine<T>(params IEnumerable<T>[] items) => items.SelectMany(i => i).Distinct().ToArray();
    }
}