using ChitalkaMVC.Logic.Genres;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChitalkaMVC.ViewComponents
{
    public class ListGenres : ViewComponent
    {
        private readonly IGenreManager _manager;

        public ListGenres(IGenreManager manager)
        {
            _manager = manager;
        }
        public async Task<IViewComponentResult> InvokeAsync(string aspFor, IEnumerable<int> selectedGenres)
        {
            
            var genres = await _manager.GetAll();
            int[] ids = null;
            if (selectedGenres.Any())
                ids = selectedGenres.ToArray();
            ViewBag.AspFor = aspFor;
            ViewBag.Genres = new MultiSelectList(genres, "Id", "Name", ids);
            return View();
        }
    }
}
