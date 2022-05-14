using ChitalkaMVC.Logic.Countries;
using Microsoft.AspNetCore.Mvc;

namespace ChitalkaMVC.ViewComponents
{
    public class MenuCountries : ViewComponent
    {
        private ICountryManager _manager;

        public MenuCountries(ICountryManager manager)
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
