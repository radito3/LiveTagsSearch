using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiveTagsSearch.Models;

namespace LiveTagsSearch.Controllers
{
    public class SearchController : Controller
    {

        private RouteModel Model = new RouteModel { Route = "./" };
        
        //when a tag is added to a file, its hashcode is added here and the list of tags is updated
        private static IDictionary<int, IList<string>> fileTagsTable = new Dictionary<int, IList<string>>();
        //this is stateful
        //for a stateless version of the app, this information needs to be in a local file
        
        public ViewResult Index()
        {
            ViewBag.Title = "Search for files";
//            ViewBag.CurrentDirectory = CurrentDirectory;
            
//            var filesTask = LiveSearchFilesAsync();
//            filesTask.Wait();
//
//            ViewBag.Files = filesTask.Result;
            
//            foreach (var file in files)
//            {
//                System.Diagnostics.Debug.WriteLine(file);    
//            }

            return View(Model);
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

//        [HttpPost]
        public ActionResult Search()
        {
            //return the searched files
            string[] files = Directory.GetFiles(Model.Route);
            string[] dirs = Directory.GetDirectories(Model.Route);
            var result = Combine(files, dirs).Select(f => new FileModel(f));
            
            return PartialView("Search", result); //may need to redirect to Index with a new model
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