using ChitalkaMVC.Logic.Centuries;
using ChitalkaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChitalkaMVC.ViewComponents
{
    public class ListCenturies : ViewComponent
    {
        private readonly ICenturyManager _manager;

        public ListCenturies(ICenturyManager manager)
        {
            _manager = manager;
        }
        public async Task<IViewComponentResult> InvokeAsync(string aspFor, int centuryId)
        {
            var centuries = await _manager.GetAll();
            var Model = new ListCenturiesViewModel();
            Model.AspFor = aspFor;
            Model.Centuries = new SelectList(centuries, "Id", "Name", centuryId);
            return View(Model);
        }
    }
}
