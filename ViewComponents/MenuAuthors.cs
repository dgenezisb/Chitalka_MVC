using ChitalkaMVC.Logic.Authors;
using Microsoft.AspNetCore.Mvc;

namespace ChitalkaMVC.ViewComponents
{
    public class MenuAuthors : ViewComponent
    {
        private IAuthorManager _manager;

        public MenuAuthors(IAuthorManager manager)
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
