using ChitalkaMVC.Logic.UserBooks;
using Microsoft.AspNetCore.Mvc;

namespace ChitalkaMVC.ViewComponents
{
    public class ListFavouriteBooks : ViewComponent
    {
        private IUserBookManager _manager;

        public ListFavouriteBooks(IUserBookManager manager)
        {
            _manager = manager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var books = await _manager.GetByUsername(HttpContext.Session.GetString("_Username"));

            return View(books);
        }
    }
}
