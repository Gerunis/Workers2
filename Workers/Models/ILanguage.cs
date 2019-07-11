using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workers.Models
{
    public interface ILanguage
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
