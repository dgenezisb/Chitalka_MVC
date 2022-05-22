using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChitalkaMVC.Models
{
    public class ListCountriesViewModel
    {
        public string AspFor { get; set; }
        public SelectList Countries { get; set; }
    }
}
