using BachmanEvgeniaKT_42_21.Database;
using BachmanEvgeniaKT_42_21.Filters.StudentFilters;
using BachmanEvgeniaKT_42_21.Models;
using Microsoft.EntityFrameworkCore;

namespace BachmanEvgeniaKT_42_21.Interfaces.StudentsInterfaces
{
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudentsByFIOAsync(StudentFIOFilter filter, CancellationToken cancellationToken); //
        public Task<Student[]> GetStudentsByDeletionStatusAsync(StudentDeletionStatusFilter filter, CancellationToken cancellationToken); //
    }

    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _dbContext;
        public StudentService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);

            return students;
        }

        public Task<Student[]> GetStudentsByFIOAsync(StudentFIOFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>()
                .Where(w => (w.FirstName == filter.FIO) || (w.LastName == filter.FIO) || (w.MiddleName == filter.FIO)).ToArrayAsync(cancellationToken);
            return students;
        }

        public Task<Student[]> GetStudentsByDeletionStatusAsync(StudentDeletionStatusFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>()
                .Where(w => w.DeletionStatus == filter.DeletionStatus).ToArrayAsync(cancellationToken);
            return students;
        }
    }
}
