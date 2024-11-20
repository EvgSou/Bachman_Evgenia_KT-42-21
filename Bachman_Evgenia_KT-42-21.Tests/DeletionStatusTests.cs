using BachmanEvgeniaKT_42_21.Database;
using BachmanEvgeniaKT_42_21.Interfaces.StudentsInterfaces;
using BachmanEvgeniaKT_42_21.Models;
using Microsoft.EntityFrameworkCore;
using NLog.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachman_Evgenia_KT_42_21.Tests
{
    public class DeletionStatusTests
    {
        public readonly DbContextOptions<StudentDbContext> _dbContextOptions;

        public DeletionStatusTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>()
            .UseInMemoryDatabase(databaseName: "student_db")
            .Options;
        }

        [Fact]
        public async Task GetStudentsByGroupAsync_KT4221_TwoObjects()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var studentService = new StudentService(ctx);
            var groups = new List<Group>
            {
                new Group
                {
                    GroupName = "КТ-42-21"
                },
                new Group
                {
                    GroupName = "КТ-41-21"
                },
                new Group
                {
                    GroupName = "КТ-31-21"
                }
            };
            await ctx.Set<Group>().AddRangeAsync(groups);

            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "a",
                    LastName = "a",
                    MiddleName = "a",
                    GroupId = 1,
                    DeletionStatus = false,
                },
                new Student
                {
                    FirstName = "c",
                    LastName = "c",
                    MiddleName = "b",
                    GroupId = 3,
                    DeletionStatus = true,
                },
                new Student
                {
                    FirstName = "c",
                    LastName = "c",
                    MiddleName = "b",
                    GroupId = 1,
                    DeletionStatus = true,
                }
            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();

            var filterDEL = new BachmanEvgeniaKT_42_21.Filters.StudentFilters.StudentDeletionStatusFilter
            {
                DeletionStatus = true
            };
            var studentsDelResult = await studentService.GetStudentsByDeletionStatusAsync(filterDEL, CancellationToken.None);

            // Assert
            Assert.Equal(2, studentsDelResult.Length);
        }
    }
}
