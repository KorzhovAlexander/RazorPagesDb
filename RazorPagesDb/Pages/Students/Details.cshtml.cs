using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDb.Core;
using RazorPagesDb.Data.Repository.Interface;

namespace RazorPagesDb.Pages.Students
{
    public class Details : PageModel
    {
        private readonly IStudentsRepository _repository;

        public Details(IStudentsRepository repository)
        {
            _repository = repository;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                Student = await _repository.GetStudentAsync(id);
                return Page();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }
    }
}