using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using File = LiveTagsSearch.Models.File;

namespace LiveTagsSearch.Controllers
{
    public class SearchController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.Title = "Search Page";
            
//            var filesTask = LiveSearchFilesAsync();
//            filesTask.Wait();
//
//            ViewBag.Files = filesTask.Result;
                
            return View(new List<File>
            {
                new File("packages.config"),
                new File("Web.config")
            });
        }

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
        
        [NonAction]
        private async Task<List<File>> LiveSearchFilesAsync()
        {
            List<File> files = new List<File>();
            
            //search asyncrhonously for files by name

            
            
            return files;
        }
    }
}