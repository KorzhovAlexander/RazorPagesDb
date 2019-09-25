using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesDb.Data.Repository.Interface;
using RazorPagesDb.Core;

namespace RazorPagesDb.Data.Repository
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly SchoolContext _context;

        //тащим контекст
        public StudentsRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<Student[]> GetAllStudentsAsync()
        {
            //запрос пишем
            IQueryable<Student> query = _context.Students;

            return await query.ToArrayAsync();
        }

        public async Task<Student> GetStudentAsync(int id)
        {
            //запрос с join, для следущего join просто пишем ThenInclude
            //тут используются лямбда выражения
            IQueryable<Student> query = _context.Students.Where(s => s.Id == id).Include(w => w.Homeworks);
            return await query.FirstOrDefaultAsync();
        }
    }
}