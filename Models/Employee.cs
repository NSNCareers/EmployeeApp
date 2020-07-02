using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dot.NetCoreWebApp.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }


        [Column(TypeName ="nvarchar(250)")]
        [Required(ErrorMessage ="This field is required")]
        [DisplayName("Full Name")]
        [MaxLength(30)]
        public string FullName { get; set; }


        [Column(TypeName ="varchar(10)")]
        [DisplayName("Emp. Code")]
        [RegularExpression(@"\d+")]
        [Required(ErrorMessage = "Only Numbers required")]
        public string EmpCode { get; set; }


        [Column(TypeName ="varchar(100)")]
        [MaxLength(10)]
        [DataType(DataType.Currency)]
        public string Position{ get; set; }


        [Column(TypeName ="varchar(100)")]
        [DisplayName("Office Location")]
        public string OfficeLocation { get; set; }

        [Column(TypeName = "varchar(100)")]
        [DisplayName("Email")]
        [MaxLength(30)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
