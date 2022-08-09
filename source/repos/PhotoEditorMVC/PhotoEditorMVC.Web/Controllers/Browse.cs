using Microsoft.AspNetCore.Mvc;
using PhotoEditorMVC.Web.Models;

namespace PhotoEditorMVC.Web.Controllers
{
    [Route("Browse")]
    public class Browse : Controller
    {
        // some dummy data
        private List<Content> contentList = new List<Content>() { 
            new Content() { Id = 1, Name = "First Image", Tag = "Funny", CreatedBy = DateTime.Now },
            new Content() { Id = 2, Name = "Second Image", Tag = "Funny", CreatedBy = DateTime.Now.AddDays(1) },
            new Content() { Id = 3, Name = "Third Image", Tag = "Landscape", CreatedBy = DateTime.Now.AddDays(2) },
            new Content() { Id = 4, Name = "Fourth Image", Tag = "Uncategorized", CreatedBy = DateTime.Now.AddDays(3) },
            new Content() { Id = 5, Name = "Fifth Image", Tag = "Uncategorized", CreatedBy = DateTime.Now.AddDays(4) }
            };

        [Route("All")]
        public IActionResult ShowAllByCreationDate()
        {
            var sortedListByDate = contentList.OrderByDescending(x => x.CreatedBy).ToList();
            return View(sortedListByDate);
        }

        [Route("{Tag}")]
        public IActionResult ShowByCategory(string tag)
        {
            var selectedItemsInList = contentList.Select(x=>x).Where(x => x.Tag == tag).ToList();
            return View(selectedItemsInList);
        }
    }
}
