using ChitalkaMVC.Logic.Notes;
using Microsoft.AspNetCore.Mvc;

namespace ChitalkaMVC.ViewComponents
{
    public class UserNotes : ViewComponent
    {
        private readonly INoteManager _manager;

        public UserNotes(INoteManager manager)
        {
            _manager = manager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notes = await _manager.GetByUsername(HttpContext.Session.GetString("_Username"));

            return View(notes);
        }
    }
}
