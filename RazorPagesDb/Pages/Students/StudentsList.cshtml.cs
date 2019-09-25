using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDb.Core;
using RazorPagesDb.Data.Repository.Interface;

namespace RazorPagesDb.Pages.Students
{
    public class StudentsList : PageModel
    {
        private readonly IStudentsRepository _repository;

        public StudentsList(IStudentsRepository repository)
        {
            _repository = repository;
        }

        public Student[] Students { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                Students =  await _repository.GetAllStudentsAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}