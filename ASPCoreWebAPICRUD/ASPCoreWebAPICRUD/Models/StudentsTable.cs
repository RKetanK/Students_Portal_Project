using System;
using System.Collections.Generic;

namespace ASPCoreWebAPICRUD.Models
{
    public partial class StudentsTable
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }
        public int DeptId { get; set; }
    }
}
