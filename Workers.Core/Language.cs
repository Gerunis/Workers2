using System;
using System.Collections.Generic;
using System.Text;

namespace Workers.Core
{
    public class Language : Models.ILanguage
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
