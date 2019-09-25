using System.Threading.Tasks;
using RazorPagesDb.Core;

namespace RazorPagesDb.Data.Repository.Interface
{
    public interface IStudentsRepository
    {

        /// Описываем какие методы будут у наших классов (наследуем дальше интерфейс для классов)
        /// Удобство в тестировании и вынесение логики
        /// Для того чтобы указать какой интерфейс определяет какой класс идет в Startup
        Task<Student[]> GetAllStudentsAsync();
        Task<Student> GetStudentAsync(int id);
    }
}