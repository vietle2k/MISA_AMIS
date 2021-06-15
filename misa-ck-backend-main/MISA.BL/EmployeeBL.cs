using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.BL.Exceptions;
using Common.Entities;
using MISA.DL;
using System.Text.RegularExpressions;
using MISA.DL.Interfaces;
using MISA.BL.Interfaces;
using Common.Attributes;

namespace MISA.BL
{
    public class EmployeeBL:BaseBL<Employee>, IEmployeeBL
    {
        public EmployeeBL(IBaseDL baseDL):base(baseDL)
        {

        }
        protected override void Validate(Employee entity)
        {
            base.Validate(entity);

            if (entity is Employee)
            {
                var employee = entity as Employee;
                EmployeeDL employeeDL = new EmployeeDL();
                // Validate dữ liệu:
                // 1. Đã nhập mã hay chưa? nếu chưa nhập thì đưa ra cảnh báo lỗi:
                //if (string.IsNullOrEmpty(employee.EmployeeCode))
                //{
                //    throw new GuardException<Employee>("Mã nhân viên không được phép để trống.", employee);
                //}
                // 2. Check mã khách hàng đã tồn tại hay chưa?
                var isExists = employeeDL.CheckEmployeeCodeExist(employee.EmployeeCode);
                if (isExists == true)
                {
                    throw new GuardException<Employee>("Mã nhân viên đã tồn tại trong hệ thống, vui lòng kiểm tra lại", null);
                }

                // 3. Kiểm tra Email có đúng định dạng hay không?
                var emailTemplate = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
                if (!Regex.IsMatch(employee.Email, emailTemplate))
                {
                    throw new GuardException<Employee>("Email không đúng định dạng, vui lòng kiểm tra lại", null);
                }

                // 4. Kiểm tra Mã đơn vị đã nhập hay chưa?
                //if (string.IsNullOrEmpty(employee.DepartmentId.ToString()))
                //{
                //    throw new GuardException<Employee>("Tên đơn vị không được phép để trống.", employee);
                //}    
            }
        }
    }
}
