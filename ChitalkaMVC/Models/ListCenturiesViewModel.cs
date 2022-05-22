using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChitalkaMVC.Models
{
    public class ListCenturiesViewModel
    {
        public string AspFor { get; set; }
        public SelectList Centuries { get; set; }
    }
}
