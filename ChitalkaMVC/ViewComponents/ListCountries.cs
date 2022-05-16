using ChitalkaMVC.Logic.Countries;
using Microsoft.AspNetCore.Mvc;

namespace ChitalkaMVC.ViewComponents
{
    public class ListCountries : ViewComponent
    {
        private ICountryManager _manager;

        public ListCountries(ICountryManager manager)
        {
            _manager = manager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var countries = await _manager.GetAll();
            return View(countries);
        }
    }
}
