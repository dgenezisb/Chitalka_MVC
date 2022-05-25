using ChitalkaMVC.Logic.Centuries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChitalkaMVC.ViewComponents
{
    public class MultiListCenturies : ViewComponent
    {
        private readonly ICenturyManager _manager;
        public MultiListCenturies(ICenturyManager manager)
        {
            _manager = manager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string aspFor, IEnumerable<int> selectedItems)
        {
            var items = await _manager.GetAll();
            int[] ids = null;
            if (selectedItems.Any())
                ids = selectedItems.ToArray();
            ViewBag.AspFor = aspFor;
            ViewBag.Items = new MultiSelectList(items, "Id", "Name", ids);
            return View();
        }

    }
}
