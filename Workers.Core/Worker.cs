using System;
using System.Collections.Generic;
using System.Text;
using Workers.Models;

namespace Workers.Core
{
    public class Worker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public Department Department { get; set; }
        public Language Language { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
