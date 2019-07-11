using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Workers.Models;

namespace Workers.Core
{
    class WorkersDb : IWorkersDb
    {
        private readonly DbContextOptions<WorkersDbContext> _options;
        public WorkersDb(DbContextOptions<WorkersDbContext> options)
        {
            _options = options;
        }

        public IEnumerable<IWorker> GetWorkers()
        {
            using (var context = new WorkersDbContext(_options))
            {
                return context.Workers.Include(x => x.Language)
                    .Include(x => x.Department);
            }
        }

        public IWorker GetWorker(int id)
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

        public void AddWorker(IWorker worker)
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

        public IEnumerable<ILanguage> GetLanguages()
        {
            using (var context = new WorkersDbContext(_options))
            {
                return context.Languages;
            }
        }

        public ILanguage GetLanguage(int id)
        {
            using (var context = new WorkersDbContext(_options))
            {
                return context.Languages.FirstOrDefault(x=>x.Id == id);
            }
        }

        public void AddLanguage(ILanguage language)
        {
            using (var context = new WorkersDbContext(_options))
            {
                context.Languages.Add((Language)language);
                context.SaveChanges();
            }
        }

        public IEnumerable<IDepartment> GetDepartments()
        {
            using (var context = new WorkersDbContext(_options))
            {
                return context.Departments;
            }
        }

        public IDepartment GetDepartment(int id)
        {
            using (var context = new WorkersDbContext(_options))
            {
                return context.Departments.FirstOrDefault(x => x.Id == id);
            }
        }

        public void AddDepartment(IDepartment department)
        {
            using (var context = new WorkersDbContext(_options))
            {
                context.Departments.Add((Department) department);
                context.SaveChanges();
            }
        }
    }
}
