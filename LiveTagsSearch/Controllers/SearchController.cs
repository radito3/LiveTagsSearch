using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using File = LiveTagsSearch.Models.File;

namespace LiveTagsSearch.Controllers
{
    public class SearchController : Controller
    {

        private string CurrentDirectory = "./";
        
        public ViewResult Index()
        {
            ViewBag.Title = "Search Page";
            
//            var filesTask = LiveSearchFilesAsync();
//            filesTask.Wait();
//
//            ViewBag.Files = filesTask.Result;

            string[] files = Directory.GetFiles(CurrentDirectory);
            string[] dirs = Directory.GetDirectories(CurrentDirectory);
            
            
//            foreach (var file in files)
//            {
//                System.Diagnostics.Debug.WriteLine(file);    
//            }

            return View(Combine(files, dirs).Select(f => new File(f)));
        }

        [NonAction]
        private static T[] Combine<T>(params IEnumerable<T>[] items) => items.SelectMany(i => i).Distinct().ToArray();
        
        [ActionName("view_tags")]
        public ActionResult GetTags(List<string> tags)
        {
            //return the tags in formatted string
            return Content("");
        }
        
        [ActionName("add_tag")]
        public ActionResult AddTags(string fileName)
        {
            //Add a tag to the associated file
            return Content("");
        }
        
        [ActionName("del_tags")]
        public ActionResult DeleteTags(List<string> tags)
        {
            //Delete a tag from the associated file
            return View("Index");
        }

        //gives error
        public ActionResult Render(FileStream fs)
        {
            return new FileContentResult(System.IO.File.ReadAllBytes(fs.Name), MimeMapping.GetMimeMapping(fs.Name));
        }

        [HttpGet]
        [ActionName("img")] // so the route is /Search/img/...
        public FileContentResult Image(string name)
        {
            byte[] img = System.IO.File.ReadAllBytes("Content/file-icon.png");
            return File(img, "image/png");
        }

        [ChildActionOnly]
        public ActionResult Search()
        {
            //return the searched files
            
            return PartialView("Search", new List<File>());
        }
        
//        [NonAction]
//        private async Task<List<File>> LiveSearchFilesAsync()
//        {
//            List<File> files = new List<File>();
//            
//            //search asynchronously for files by name
//
//            
//            
//            return files;
//        }
    }
}