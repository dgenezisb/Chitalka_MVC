using ChitalkaMVC.Logic.UserBooks;
using ChitalkaMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChitalkaMVC.ViewComponents
{
    public class FavouriteBook : ViewComponent
    {
        private IUserBookManager _manager;

        public FavouriteBook(IUserBookManager manager)
        {
            _manager = manager;
        }
        public async Task<IViewComponentResult> InvokeAsync(int bookId)
        {
            var username = HttpContext.Session.GetString("_Username");
            var model = new FavouriteBookViewModel();
            if (username == null)
            {
                model.LoggedIn = false;
                return View(model);
            }
            else
            {
                model.LoggedIn = true;
                model.BookId = bookId;
                if (await _manager.Exists(username, bookId))
                    model.IsFavorite = true;
                else
                    model.IsFavorite = false;
            }
            return View(model);
        }
    }
}
