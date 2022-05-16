using ChitalkaMVC.Logic.Authors;
using Microsoft.AspNetCore.Mvc;

namespace ChitalkaMVC.ViewComponents
{
    public class ListAuthors : ViewComponent
    {
        private IAuthorManager _manager;

        public ListAuthors(IAuthorManager manager)
        {
            _manager = manager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var authors = await _manager.GetAll();
            return View(authors);
        }
    }
}
