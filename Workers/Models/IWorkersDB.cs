using System.Collections.Generic;

namespace Workers.Models
{
    public interface IWorkersDb
    {
        IEnumerable<IWorker> GetWorkers();
        IWorker GetWorker(int id);
        void AddWorker(IWorker worker);
        bool RemoveWorker(int id);


        IEnumerable<ILanguage> GetLanguages();
        ILanguage GetLanguage(int id);
        void AddLanguage(ILanguage language);

        IEnumerable<IDepartment> GetDepartments();
        IDepartment GetDepartment(int id);
        void AddDepartment(IDepartment department);


    }
}
