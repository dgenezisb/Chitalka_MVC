using ChitalkaMVC.Logic.Authors;
using ChitalkaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChitalkaMVC.ViewComponents
{
    public class ListAuthors : ViewComponent
    {
        private readonly IAuthorManager _manager;

        public ListAuthors(IAuthorManager manager)
        {
            _manager = manager;
        }
        public async Task<IViewComponentResult> InvokeAsync(string aspFor, int authorId)
        {
            var authors = await _manager.GetAll();
            var Model = new ListAuthorsViewModel();
            Model.Authors = new SelectList(authors, "Id", "Name", authorId);
            Model.AspFor = aspFor;
            return View(Model);
        }
    }
}
