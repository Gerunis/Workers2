using System;

namespace Workers.Core
{
    public class Department : Models.IDepartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
    }
}
