using Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        [MISARequired("Mã nhân viên")]
        [MISAMaxLength(maxlength:20,"Mã nhân viên")]
        public string EmployeeCode { get; set; }
        [MISAMaxLength(maxlength: 255, "Họ tên")]
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }
        [MISARequired("Tên đơn vị")]
        public Guid? DepartmentId { get; set; }
        [MISAMaxLength(maxlength: 20, "Chứng minh nhân dân")]
        public string IdentityNumber { get; set; }
        public DateTime? IdentityDate { get; set; }
        public string IdentityPlace { get; set; }
        public string JobTitle { get; set; }
        public string Address { get; set; }
        [MISAMaxLength(maxlength: 20, "Số điện thoại")]
        public string Phone { get; set; }
        [MISAMaxLength(maxlength: 20, "Số điện thoại cố định")]
        public string Telephone { get; set; }
        [MISAMaxLength(maxlength: 100, "Email")]
        public string Email { get; set; }
        public string BankAccount { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
