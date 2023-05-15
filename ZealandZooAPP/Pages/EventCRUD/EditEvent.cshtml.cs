using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooAPP.Services;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.EventCRUD
{
    public class EditEventModel : PageModel
    {
        private readonly EventRepoService service;

        public EditEventModel(EventRepoService repo)
        {
            service = repo;
        }

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public DateTime DateTo { get; set; }
        [BindProperty]
        public DateTime DateFrom { get; set; }
        [BindProperty]
        public int MaxGuest { get; set; }
        [BindProperty]
        public double Price { get; set; }
        public String ErrorHold { get; private set; }

        public void OnGet(int id)
        {
            Event editEvent = (Event)service.GetById(id);

            Id = editEvent.Id;
            Name = editEvent.Name;
            Description = editEvent.Description;
            DateTo = editEvent.DateTo;
            DateFrom = editEvent.DateFrom;
            MaxGuest = editEvent.MaxGuest;
            Price = editEvent.Price;
        }

        public IActionResult OnPostUpdate(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                Event even = new Event(Name,Description,DateTo,DateFrom,MaxGuest,Price);

                service.Update(id, even);

                return RedirectToPage("/Calender");
            }
            catch (Exception ex)
            {
                ErrorHold = ex.Message;

                return RedirectToPage("/Calender");
            }
        }
    }               
}
