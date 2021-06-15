using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Entities;
using Dapper;
using MySqlConnector;
using MISA.BL.Exceptions;
using System.Data;
using MISA.BL.Interfaces;

namespace MISA.CuoiKhoa.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class EmployeeController : MISAEntityController<Employee>
    {
        public EmployeeController(IEmployeeBL baseBL):base(baseBL)
        {

        }
        /*
        [HttpGet("Paging")]
        public IActionResult GetPaging(int pageIndex, int pageSize)
        {
            // 1. Khai báo thông tin kết nối tới Database:
            var connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "Database= 15B_MS152_CukCuk_LNTUNG;" +
                "User Id = dev;" +
                "Password= 12345678";

            // 2. Khởi tạo kết nối:
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            // 3. Tương tác với Database (lấy dữ liệu, sửa dữ liệu, xóa dữ liệu)
            var sqlCommand = "Proc_GetEmployeePaging";
            var param = new
            {
                m_PageIndex = 1,
                m_PageSize = 10
            };

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@m_PageIndex", 1);
            dynamicParameters.Add("@m_PageSize", 10);

            var employees = dbConnection.Query<Employee>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);

            // 4. Kiểm tra dữ liệu và trả về cho Client
            // - Nếu có dữ liệu thì trả về 200 kèm theo dữ liệu
            // - Không có dữ liệu thì trả về 204:
            if (employees.Count() > 0)
            {
                return Ok(employees);
            }
            else
            {
                return NoContent();
            }
        }
        */
        [HttpGet("Search")]
        public IEnumerable<Employee> GetSearch(string searchField)
        {
            string _connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "Database= 15B_MS243_CukCuk_LXVIET;" +
                "User Id = dev;" +
                "Password= 12345678";
            IDbConnection _dbConnection = new MySqlConnection(_connectionString);

            var sqlCommand = $"Proc_SearchEmployee";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@SearchField", searchField);
            var entities = _dbConnection.Query<Employee>(sqlCommand, param: dynamicParameters ,commandType: CommandType.StoredProcedure);
            return entities;

        }

        [HttpGet("NewEmployeeCode")]
        public string GetNewEmployeeCode()
        {
            string _connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "Database= 15B_MS243_CukCuk_LXVIET;" +
                "User Id = dev;" +
                "Password= 12345678";
            IDbConnection _dbConnection = new MySqlConnection(_connectionString);

            var sqlCommand = $"Proc_GetMaxEmployeeCode";
            var maxCode = _dbConnection.QueryFirstOrDefault<string>(sqlCommand, commandType: CommandType.StoredProcedure);
            
            if (String.IsNullOrEmpty(maxCode))
            {
                return "NV-0000";
            }
            else
            {
                string newCode = "NV-";
                int i_maxCode = int.Parse(maxCode);

                if (maxCode.Length > i_maxCode.ToString().Length)
                {
                    int length;
                    if ((i_maxCode + 1).ToString().Length > i_maxCode.ToString().Length)
                    {
                        length = maxCode.Length - (i_maxCode + 1).ToString().Length;
                        newCode += maxCode.Substring(0, length);
                    }
                    else
                    {
                        length = maxCode.Length - i_maxCode.ToString().Length;
                        newCode += maxCode.Substring(0, length);
                    }

                }
                newCode += (int.Parse(maxCode) + 1).ToString();
                return newCode;
            } 
        }

        [HttpGet("CheckEmployeeCodeExist")]
        public bool GetCheckEmployeeCodeExist(string m_EmployeeCode)
        {
            string _connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "Database= 15B_MS243_CukCuk_LXVIET;" +
                "User Id = dev;" +
                "Password= 12345678";
            IDbConnection _dbConnection = new MySqlConnection(_connectionString);

            var sqlCommand = $"Proc_CheckEmployeeCodeExist";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@EmployeeCode", m_EmployeeCode);
            var result = _dbConnection.QueryFirstOrDefault<int>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);

            if (result == 1) return true;
            else return false;
        }
    }
}
