using ChitalkaMVC.Logic.Genres;
using Microsoft.AspNetCore.Mvc;

namespace ChitalkaMVC.ViewComponents
{
    public class MenuGenres : ViewComponent
    {
        private readonly IGenreManager _manager;

        public MenuGenres(IGenreManager manager)
        {
            _manager = manager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var genres = await _manager.GetAll();
            return View(genres);
        }
    }
}
