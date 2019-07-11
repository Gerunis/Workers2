using System;
using System.Collections.Generic;
using System.Text;
using Workers.Models;

namespace Workers.Core
{
    public class Worker : Models.IWorker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public IDepartment Department { get; set; }
        public ILanguage Language { get; set; }
    }
}
