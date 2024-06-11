using Microsoft.Build.Framework;

namespace CRUDAppUsingASPCoreWebAPI.Models
{
    
    //this is the Student Model Class
        public class Student
        {

        [Required]
        public int studentId { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public int deptId { get; set; }
        }

    
}
