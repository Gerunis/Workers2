using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workers.Models
{
    public interface IWorker
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        Gender Gender { get; set; }
        int Age { get; set; }
        IDepartment Department { get; set; }
        ILanguage Language { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
