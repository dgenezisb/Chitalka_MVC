using ChitalkaMVC.Logic.Genres;
using Microsoft.AspNetCore.Mvc;

namespace ChitalkaMVC.ViewComponents
{
    public class ListGenres : ViewComponent
    {
        private IGenreManager _manager;

        public ListGenres(IGenreManager manager)
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
