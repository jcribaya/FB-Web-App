using FB.Data;
using FB.Models.Domain;
using FB.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FB.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly FB_DBContext fB_DBContext;

        public AdminTagsController(FB_DBContext fB_DBContext)
        {
            this.fB_DBContext = fB_DBContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public IActionResult SubmitTag(AddTagRequest addTagRequest) 
        {
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };
            fB_DBContext.Tags.Add(tag);
            fB_DBContext.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("List")]
        public IActionResult List() 
        {
            var tags = fB_DBContext.Tags.ToList();
            

            return View(tags);  
        }

        [HttpGet] 
        public IActionResult Edit(Guid id)
        {
            var tag = fB_DBContext.Tags.FirstOrDefault(x => x.Id == id);

            if(tag != null)
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName
                };

                return View(editTagRequest);
            }
            
            return View(null);
        }

        [HttpPost]
        public IActionResult Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName
            };

            var existingTag = fB_DBContext.Tags.Find(tag.Id);

            if(existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                fB_DBContext.SaveChanges();
                return RedirectToAction("Edit", new { id = editTagRequest.Id });
            }

            return RedirectToAction("Edit", new {id = editTagRequest.Id});
        }

        [HttpPost]
        public IActionResult Delete(EditTagRequest editTagRequest) 
        {
            var tag = fB_DBContext.Tags.Find(editTagRequest.Id);

            if(tag != null)
            {
                fB_DBContext.Tags.Remove(tag); 
                fB_DBContext.SaveChanges();

                return RedirectToAction("List");
            }

            return RedirectToAction("Edit", new {id = editTagRequest.Id});
        }
    }
}
