using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazorPageAjaxDemo.Models;

namespace WebRazorPageAjaxDemo.Pages
{
    public class CustomerFormModel : PageModel
    {
        public string Message { set; get; }
        [BindProperty]
        public Customer customerInfo{ set; get; }
        public void OnGet()
        {
            if (ModelState.IsValid)
            {
                Message = "Information is OK.";
                ModelState.Clear();
            }
            else
            {
                Message = "Error on input data.";
            }
        }
    }
}
