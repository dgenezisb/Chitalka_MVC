using ChitalkaMVC.Logic.Countries;
using ChitalkaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChitalkaMVC.ViewComponents
{
    public class ListCountries : ViewComponent
    {
        private ICountryManager _manager;

        public ListCountries(ICountryManager manager)
        {
            _manager = manager;
        }
        public async Task<IViewComponentResult> InvokeAsync(string aspFor, int countryId)
        {
            var countries = await _manager.GetAll();
            var Model = new ListCountriesViewModel();
            Model.AspFor = aspFor;
            Model.Countries = new SelectList(countries, "Id", "Name", countryId);
            return View(Model);
        }
    }
}
