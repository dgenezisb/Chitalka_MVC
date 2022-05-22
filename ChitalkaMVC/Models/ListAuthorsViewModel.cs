using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChitalkaMVC.Models
{
    public class ListAuthorsViewModel
    {
        public string AspFor { get; set; }
        public SelectList Authors { get; set; }
    }
}
