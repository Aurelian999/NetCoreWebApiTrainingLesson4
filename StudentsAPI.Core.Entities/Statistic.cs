using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsAPI.Core.Entities
{
    public class Statistic
    {
        public string StudentName { get; set; }
        public int CommitCount { get; set; }
        public int CodeLinesCount { get; set; }
    }
}
