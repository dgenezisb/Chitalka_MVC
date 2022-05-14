using ChitalkaMVC.Logic.Centuries;
using Microsoft.AspNetCore.Mvc;

namespace ChitalkaMVC.ViewComponents
{
    public class MenuCenturies : ViewComponent
    {
        private ICenturyManager _manager;

        public MenuCenturies(ICenturyManager manager)
        {
            _manager = manager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var centuries = await _manager.GetAll();
            return View(centuries);
        }
    }
}
