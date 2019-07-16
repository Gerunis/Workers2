using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Workers.Core
{
    public class WorkersDb
    {
        private readonly DbContextOptions<WorkersDbContext> _options;
        public WorkersDb(DbContextOptions<WorkersDbContext> options)
        {
            _options = options;
        }

        public IEnumerable<Worker> GetWorkers()
        {
            using (var context = new WorkersDbContext(_options))
            {
                return context.Workers.Include(x => x.Language)
                    .Include(x => x.Department);
            }
        }

        public Worker GetWorker(int id)
        {
            using (var context = new WorkersDbContext(_options))
            {
                return context.Workers
                    .Where(x => x.Id == id)
                    .Include(x => x.Language)
                    .Include(x => x.Department)
                    .FirstOrDefault();
            }
        }

        public void AddWorker(Worker worker)
        {
            using (var context = new WorkersDbContext(_options))
            {
                context.Workers.Add((Worker)worker);
                context.SaveChanges();
            }
        }

        public bool RemoveWorker(int id)
        {
            using (var context = new WorkersDbContext(_options))
            {
                var worker = context.Workers
                    .FirstOrDefault(x => x.Id == id);
                if (worker == null)
                    return false;
                context.Workers.Remove(worker);
                context.SaveChanges();
                return true;
            }
        }

        public IEnumerable<Language> GetLanguages()
        {
            using (var context = new WorkersDbContext(_options))
            {
                return context.Languages;
            }
        }

        public Language GetLanguage(int id)
        {
            using (var context = new WorkersDbContext(_options))
            {
                return context.Languages.FirstOrDefault(x=>x.Id == id);
            }
        }

        public void AddLanguage(Language language)
        {
            using (var context = new WorkersDbContext(_options))
            {
                context.Languages.Add((Language)language);
                context.SaveChanges();
            }
        }

        public IEnumerable<Department> GetDepartments()
        {
            using (var context = new WorkersDbContext(_options))
            {
                return context.Departments;
            }
        }

        public Department GetDepartment(int id)
        {
            using (var context = new WorkersDbContext(_options))
            {
                return context.Departments.FirstOrDefault(x => x.Id == id);
            }
        }

        public void AddDepartment(Department department)
        {
            using (var context = new WorkersDbContext(_options))
            {
                context.Departments.Add((Department) department);
                context.SaveChanges();
            }
        }
    }
}
