using ChitalkaMVC.Logic.Genres;
using ChitalkaMVC.Storage.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChitalkaMVC.ViewComponents
{
    public class ListGenres : ViewComponent
    {
        private IGenreManager _manager;

        public ListGenres(IGenreManager manager)
        {
            _manager = manager;
        }
        public async Task<IViewComponentResult> InvokeAsync(List<Genre> selectedGenres)
        {
            
            var genres = await _manager.GetAll();
            int[] ids = null;
            if (selectedGenres != null)
            {
                ids = new int[selectedGenres.Count];
                for (int i = 0; i < ids.Length; i++)
                    ids[i] = selectedGenres[i].Id;
            }

            ViewBag.Genres = new MultiSelectList(genres, "Id", "Name", ids);
            return View();
        }
    }
}
