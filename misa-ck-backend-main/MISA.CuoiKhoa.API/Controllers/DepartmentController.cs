using Common.Entities;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BL;
using MISA.BL.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CuoiKhoa.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            // 1. Khai báo thông tin kết nối tới Database:
            var connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "Database= 15B_MS243_CukCuk_LXVIET;" +
                "User Id = dev;" +
                "Password= 12345678";

            // 2. Khởi tạo kết nối:
            IDbConnection _dbConnection = new MySqlConnection(connectionString);
            var sqlCommand = $"Proc_GetDepartments";
            var entities = _dbConnection.Query<Department>(sqlCommand, commandType: CommandType.StoredProcedure);
            //   Kiểm tra dữ liệu và trả về cho Client
            // - Nếu có dữ liệu thì trả về 200 kèm theo dữ liệu
            // - Không có dữ liệu thì trả về 204:
            if (entities.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(entities);
            }
        }
    }
}
